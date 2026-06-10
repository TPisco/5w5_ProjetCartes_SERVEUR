using System;
using Microsoft.AspNetCore.Identity;
using Models.Models;
using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Data
{
    public class Seed
    {
        public Seed() { }

        // National dex ids used by starting decks and special card powers.
        private static class FeaturedPokemon
        {
            public const int Dracolosse = 149;
            public const int Rayquaza = 384;
            public const int Rondoudou = 39;
            public const int Mewtwo = 150;
            public const int Gardevoir = 282;
            public const int Alakazam = 65;
            public const int Onix = 95;
            public const int Ronflex = 143;
            public const int Dracofeu = 6;
        }

        public static Card[] SeedCards() => CardSeedLoader.LoadCards();
        public static IdentityUser[] SeedUsers()
        {
            var hasher = new PasswordHasher<IdentityUser>();
            IdentityUser admin = new IdentityUser
            {
                Id = "11111111-1111-1111-1111-111111111111",
                UserName = "admin@admin.com",
                Email = "admin@admin.com",
                // La comparaison d'identity se fait avec les versions normalisés
                NormalizedEmail = "ADMIN@ADMIN.COM",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                // On encrypte le mot de passe
                PasswordHash = hasher.HashPassword(null, "Passw0rd!"),
                LockoutEnabled = true
            };

            return new IdentityUser[] { admin };
        }

        public static IdentityRole[] SeedRoles()
        {
            IdentityRole adminRole = new IdentityRole
            {
                Id = "11111111-1111-1111-1111-111111111112",
                Name = ApplicationDbContext.ADMIN_ROLE,
                NormalizedName = ApplicationDbContext.ADMIN_ROLE.ToUpper()
            };

            return new IdentityRole[] { adminRole };
        }

        public static IdentityUserRole<string>[] SeedUserRoles()
        {
            IdentityUserRole<string> userAdmin = new IdentityUserRole<string>
            {
                RoleId = "11111111-1111-1111-1111-111111111112",
                UserId = "11111111-1111-1111-1111-111111111111"
            };
            return new IdentityUserRole<string>[] { userAdmin };
        }

        public static IdentityUser[] SeedTestUsers()
        {
            return new IdentityUser[] {
                new IdentityUser()
                {
                    Id = "User1Id"
                },
                new IdentityUser
                {
                Id = "User2Id"
                }
            };
        }

        public static Player[] SeedTestPlayers()
        {
            return new Player[] {
                new Player
                {
                    Id = 1,
                    Name = "Test player 1",
                    UserId = "User1Id"

                },
                new Player
                {
                    Id = 2,
                    Name = "Test player 2",
                    UserId = "User2Id"
                }
            };
        }

     public static StartingCards[] seedStartingCards()
        {
            int[] startingCardIds =
            {
                FeaturedPokemon.Dracolosse,
                FeaturedPokemon.Mewtwo,
                FeaturedPokemon.Alakazam,
                FeaturedPokemon.Gardevoir,
                FeaturedPokemon.Rondoudou,
                FeaturedPokemon.Dracofeu,
                FeaturedPokemon.Gardevoir,
                FeaturedPokemon.Rondoudou,
                FeaturedPokemon.Dracofeu
            };

            return startingCardIds
                .Select((cardId, index) => new StartingCards
                {
                    Id = index + 1,
                    CardID = cardId
                })
                .ToArray();
        }
    public static Power[] SeedPower()
        {
            return new Power[]
            {
                new Power
                {
                    Id = 1, Name = "First Strike", Description = "Permet à une carte d’attaquer en « premier » et de ne pas recevoir de dégât si elle tue la carte de l’adversaire.", Icon = "🥇", HasValue = false
                },
                new Power
                {
                    Id = 2, Name = "Thorns", Description = "Lorsqu’une carte défend, elle inflige X de dégâts AVANT de recevoir des dégâts. Si l’attaquant est tué par ces dégâts, l’attaque s’arrête et le défenseur ne reçoit pas de dégâts.", Icon = "🌹", HasValue = true
                },
                 new Power
                {
                    Id = 5, Name = "Chaos", Description = "Inverse l'attaque et la défense de toutes les cartes en jeu", Icon = "❂", HasValue = false
                },
                new Power
                {
                    Id = 3, Name = "Heal", Description = "Soigne les cartes alliées de X incluant elle-même AVANT d’attaquer (mais les cartes ne peuvent pas avoir plus de health qu’au départ.)", Icon = "💖", HasValue = true
                },
                new Power
                {
                    Id = 4, Name = "Shield", Description = "Augmente la défense d'une carte de X", Icon = "🛡️", HasValue = true
                },
                 new Power
                 {
                        Id = 6, Name = "EarthQuakeX", Description = " Fait X dégâts à TOUTES les cartes en jeu (même les nôtres!)", Icon = "", HasValue = true, IsSpell = true
                 },
                new Power
                {
                    Id = 7 , Name = "RandomPain" , Description = "Une carte de sort qui inflige des dégâts aléatoires entre 1 et 6 à une carte ennemie.", Icon = "❓", HasValue = true, IsSpell = true
                },
                new Power
                {
                    Id= 8 , Name = "PoisonAttack", Description = "Inflige du poison à une carte ennemie." , Icon = "☠", HasValue = true
                },
                 new Power
                {
                    Id = 9 , Name = "StunnedX" , Description = "Inflige l'effet Stunned à une carte.", Icon = "💫", HasValue = true
                },
                 new Power
                {
                    Id = 10 , Name = "DamageDownAttack" , Description = "Inflige une quantité X de l'effet DamageDown à une carte.", Icon = "⬇", HasValue = true
                }

            };
        }

        //À décommenter plus tard

        public static Status[] SeedStatus()
        {
            return new Status[]
            {
                new Status
                {
                    Id = 1, Name = "PoisonX", Description= "Inflige la quantité X de dégâts à la carte affectée à la fin de son activation.Si une carte a déjà une valeur de poison et qu’elle est à nouveau attaquée, la valeur de poison est augmentée. (Stacks)", Icon= "☠"
                },
                new Status
                {
                    Id = 2, Name = "StunnedX" , Description= "Empêche une carte d’agir pendant son activation durant X tours.Recoit quand-même les dégâts de poison et des autres cartes.", Icon = "💫"
                },
                new Status
                {
                    Id = 3, Name = "DamageDownX", Description = "Un effet qui réduit les dégâts totaux d'une carte par X.", Icon = "⬇"
                }

            };

        }

        //Il n'y aura pas de SeedCardStatus(), car aucune carte n'a un status qui lui est infligé par défaut.


        public static CardPower[] SeedCardPowers()
        {
            return new CardPower[]
            {
                new CardPower
                {
                    Id = 1,
                    CardId = FeaturedPokemon.Dracolosse,
                    PowerId = 1
                },
                new CardPower
                {
                    Id = 2,
                    CardId = FeaturedPokemon.Rayquaza,
                    PowerId = 2,
                    Value = 3
                },
                new CardPower
                {
                    Id = 3,
                    CardId = FeaturedPokemon.Rondoudou,
                    PowerId = 3,
                    Value = 2
                },
                new CardPower
                {
                    Id = 4,
                    CardId = FeaturedPokemon.Mewtwo,
                    PowerId = 4,
                    Value = 5
                },
                new CardPower
                {
                    Id = 5,
                    CardId = FeaturedPokemon.Gardevoir,
                    PowerId = 8,
                    Value = 2
                },
                new CardPower
                {
                    Id = 6,
                    CardId = FeaturedPokemon.Ronflex,
                    PowerId = 9,
                    Value = 3
                },
                new CardPower
                {
                    Id = 7,
                    CardId = FeaturedPokemon.Alakazam,
                    PowerId = 5,
                    Value = 0
                },
                new CardPower
                {
                    Id = 8,
                    CardId = FeaturedPokemon.Onix,
                    PowerId = 10,
                    Value = 1
                }
            };
        }


        public static GameConfig seedGameConfig()
        {
            return new GameConfig
            {
                id = 1,
                nbCardsToDraw = 4,
                QtManaParTour = 3,
                GoldStarting = 300,
                GoldWin = 50,
                GoldLoss = 10,
                MaxDecks = 10,
                MaxCardsPerDeck = 30
            };
        }

        public static Pack[] SeedPacks()
        {
            return new Pack[]
            {
                new Pack { Id = 1, Name = "Basic", ImageUrl = "/images/pack-basic.png", Price = 50, CardCount = 3, DefaultRarity = CardRarity.Common },
                new Pack { Id = 2, Name = "Normal", ImageUrl = "/images/pack-normal.png", Price = 100, CardCount = 4, DefaultRarity = CardRarity.Common },
                new Pack { Id = 3, Name = "Super", ImageUrl = "/images/pack-super.png", Price = 200, CardCount = 5, DefaultRarity = CardRarity.Rare }
            };
        }

        public static PackProbability[] SeedPackProbabilities()
        {
            return new PackProbability[]
            {
                new PackProbability { Id = 1, PackId = 1, Rarity = CardRarity.Rare, ProbabilityPercent = 30 },
                new PackProbability { Id = 2, PackId = 2, Rarity = CardRarity.Rare, ProbabilityPercent = 30 },
                new PackProbability { Id = 3, PackId = 2, Rarity = CardRarity.Epic, ProbabilityPercent = 10 },
                new PackProbability { Id = 4, PackId = 2, Rarity = CardRarity.Legendary, ProbabilityPercent = 2 },
                new PackProbability { Id = 5, PackId = 3, Rarity = CardRarity.Epic, ProbabilityPercent = 25 },
                new PackProbability { Id = 6, PackId = 3, Rarity = CardRarity.Legendary, ProbabilityPercent = 10 }
            };
        }
    }
}

