# Generates Models/Data/pokemon_cards.json from PokeAPI (first 400 Pokemon).
# Usage: .\tools\generate-pokemon-seed.ps1

$ErrorActionPreference = 'Stop'
$outputPath = Join-Path $PSScriptRoot '..\Models\Data\pokemon_cards.json'

function Get-GameStats {
    param($Pokemon, $Species)
    $hp = ($Pokemon.stats | Where-Object { $_.stat.name -eq 'hp' }).base_stat
    $attackStat = ($Pokemon.stats | Where-Object { $_.stat.name -eq 'attack' }).base_stat
    $spAttack = ($Pokemon.stats | Where-Object { $_.stat.name -eq 'special-attack' }).base_stat
    $total = ($Pokemon.stats | Measure-Object -Property base_stat -Sum).Sum

    $health = [Math]::Max(1, [Math]::Min(10, [int][Math]::Round($hp / 15.0)))
    $attack = [Math]::Max(1, [Math]::Min(10, [int][Math]::Round(($attackStat + $spAttack) / 25.0)))
    $cost = [Math]::Max(1, [Math]::Min(10, [int][Math]::Round(($health + $attack) / 2.0)))

    $rarity = if ($Species.is_legendary -or $Species.is_mythical) { 'Legendary' }
              elseif ($total -ge 600) { 'Epic' }
              elseif ($total -ge 500) { 'Rare' }
              else { 'Common' }

    return @{ health = $health; attack = $attack; cost = $cost; rarity = $rarity }
}

Write-Host 'Fetching Pokemon list...'
$list = (Invoke-RestMethod 'https://pokeapi.co/api/v2/pokemon?limit=400&offset=0').results
$entries = New-Object System.Collections.Generic.List[object]
$count = 0

foreach ($item in $list) {
    $id = [int]($item.url.TrimEnd('/') -split '/')[-1]
    if ($id -gt 400) { continue }
    $count++
    Write-Host "[$count/400] Pokemon #$id"

    $poke = Invoke-RestMethod "https://pokeapi.co/api/v2/pokemon/$id"
    $species = Invoke-RestMethod $poke.species.url
    $frName = ($species.names | Where-Object { $_.language.name -eq 'fr' } | Select-Object -First 1).name
    if (-not $frName) {
        $frName = (Get-Culture).TextInfo.ToTitleCase($poke.name.Replace('-', ' '))
    }

    $stats = Get-GameStats -Pokemon $poke -Species $species
    $primaryType = $poke.types[0].type.name
    $entries.Add([ordered]@{
        id       = $id
        name     = $frName
        attack   = $stats.attack
        health   = $stats.health
        cost     = $stats.cost
        rarity   = $stats.rarity
        type     = $primaryType
        imageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/$('{0:D3}' -f $id).png"
    })
}

$json = $entries | ConvertTo-Json -Depth 4
[System.IO.File]::WriteAllText($outputPath, $json, [System.Text.UTF8Encoding]::new($false))
Write-Host "Wrote $($entries.Count) cards to $outputPath"
