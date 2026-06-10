using System;
using System.Drawing;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;
using Models.Models;
using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Data
{
    public class Seed
    {
        public Seed() { }

        public static Card[] SeedCards()
        {
            return new Card[] {
                new Card
                {
                    Id = 1,
                    Name = "Dracolosse",
                    Attack = 5,
                    Health = 8,
                    Cost = 5,
                    Rarity = CardRarity.Epic,
                    ImageUrl = "https://pm1.aminoapps.com/6906/f456d54f84291a3e3a9532251214cda80cbef906r1-335-431v2_hq.jpg"
                }, new Card
                {
                    Id = 2,
                    Name = "Rayquaza",
                    Attack = 10,
                    Health = 5,
                    Cost = 9,
                    Rarity = CardRarity.Legendary,
                    ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/384.png"
                }, new Card
                {
                    Id = 3,
                    Name = "Rondoudou",
                    Attack = 2,
                    Health = 1,
                    Cost = 1,
                    Rarity = CardRarity.Common,
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/en/2/22/Pok%C3%A9mon_Jigglypuff_art.png"
                }, new Card
                {
                    Id = 4,
                    Name = "Mewtwo",
                    Attack = 8,
                    Health = 4,
                    Cost = 6,
                    Rarity = CardRarity.Epic,
                    ImageUrl = "https://e7.pngegg.com/pngimages/993/391/png-clipart-pokemon-character-illustration-pokemon-x-and-y-pokemon-go-pokemon-black-white-mewtwo-pokemon-go-purple-mammal.png"
                }, new Card
                {
                    Id = 5,
                    Name = "Gardevoir",
                    Attack = 7,
                    Health = 7,
                    Cost = 5,
                    Rarity = CardRarity.Rare,
                    ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/282.png"
                }, new Card
                {
                    Id = 6,
                    Name = "Alakazam",
                    Attack = 4,
                    Health = 2,
                    Cost = 2,
                    Rarity = CardRarity.Common,
                    ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/065.png"
                }, new Card
                {
                    Id = 7,
                    Name = "Onix",
                    Attack = 6,
                    Health = 3,
                    Cost = 4,
                    Rarity = CardRarity.Rare,
                    ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/095.png"
                }, new Card
                {
                    Id = 8,
                    Name = "Ronflex",
                    Attack = 1,
                    Health = 9,
                    Cost = 2,
                    Rarity = CardRarity.Common,
                    ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/143.png"
                }, new Card
                {
                    Id = 9,
                    Name = "Mew",
                    Attack = 5,
                    Health = 1,
                    Cost = 2,
                    Rarity = CardRarity.Legendary,
                    ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/151.png"
                }, new Card
                {
                    Id = 10,
                    Name = "Dracofeu",
                    Attack = 6,
                    Health = 1,
                    Cost = 2,
                    Rarity = CardRarity.Rare,
                    ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/006_f2.png"
                },
                new Card { Id = 11, Name = "Pikachu", Attack = 3, Health = 2, Cost = 2, Rarity = CardRarity.Common, ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/025.png" },
                new Card { Id = 12, Name = "Evoli", Attack = 2, Health = 3, Cost = 1, Rarity = CardRarity.Common, ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/133.png" },
                new Card { Id = 13, Name = "Magicarpe", Attack = 1, Health = 4, Cost = 1, Rarity = CardRarity.Common, ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/129.png" },
                new Card { Id = 14, Name = "Lucario", Attack = 5, Health = 4, Cost = 4, Rarity = CardRarity.Rare, ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/448.png" },
                new Card { Id = 15, Name = "Givrali", Attack = 4, Health = 5, Cost = 3, Rarity = CardRarity.Rare, ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/471.png" },
                new Card { Id = 16, Name = "Tortank", Attack = 6, Health = 6, Cost = 5, Rarity = CardRarity.Epic, ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/009.png" },
                new Card { Id = 17, Name = "Florizarre", Attack = 5, Health = 7, Cost = 5, Rarity = CardRarity.Epic, ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/003.png" },
                new Card { Id = 18, Name = "Amphinobi", Attack = 7, Health = 3, Cost = 4, Rarity = CardRarity.Epic, ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/658.png" },
                new Card { Id = 19, Name = "Arceus", Attack = 9, Health = 9, Cost = 10, Rarity = CardRarity.Legendary, ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/493.png" },
                new Card { Id = 20, Name = "Dialga", Attack = 8, Health = 8, Cost = 8, Rarity = CardRarity.Legendary, ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/483.png" }
                //,new Card
                // {
                //    Id = 11,
                //    Name = "Avalanche",
                //    Attack = 0,
                //    Health = 1,
                //    Cost = 3,
                //    ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/006_f2.png"
                //}
                //,new Card
                // {
                //    Id = 12,
                //    Name = "Douleur Random",
                //    Attack = 0,
                //    Health = 1,
                //    Cost = 2,
                //    ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/006_f2.png"
                //}

            };
        }

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
            return new StartingCards[]
            {
                new StartingCards
                {
                   Id=1, CardID = SeedCards()[0].Id
                },
                new StartingCards
                {
                    Id=2, CardID = SeedCards()[3].Id
                },
                new StartingCards
                {
                    Id=3, CardID = SeedCards()[5].Id
                },
                new StartingCards
                {
                    Id=4, CardID = SeedCards()[4].Id
                },
                new StartingCards
                {
                    Id=5, CardID = SeedCards()[2].Id
                },
                new StartingCards
                {
                   Id=6, CardID = SeedCards()[9].Id
                },
                new StartingCards
                {
                    Id=7, CardID = SeedCards()[4].Id
                },
                new StartingCards
                {
                    Id=8, CardID = SeedCards()[2].Id
                },
                new StartingCards
                {
                    Id=9, CardID = SeedCards()[9].Id
                }
                //,Ajout des cartes Spell dans le Seed
                //new StartingCards
                //{
                //    Id=10, CardID = SeedCards()[11].Id
                //},
                //   new StartingCards
                //{
                //    Id=10, CardID = SeedCards()[12].Id
                //}

            };

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
            CardId = 1, // Dracolosse
            PowerId = 1 // First Strike
        },
        new CardPower
        {
            Id = 2,
            CardId = 2, // Rayquaza
            PowerId = 2, // Thorns
            Value = 3 
        },
        new CardPower
        {
            Id = 3,
            CardId = 3, // Rondoudou
            PowerId = 3, // Heal
            Value = 2 
        },
        new CardPower
        {
            Id = 4,
            CardId = 4, // Mewtwo
            PowerId = 4, // Shield
            Value = 5 
        },
        //AJOUT DES NOUVEAUX POWERS
        new CardPower
        {
            Id= 5,
            CardId =5, //Gardevoir
            PowerId = 8, //Poison Attack
            Value = 2
        },
        new CardPower
        {
            Id = 6,
            CardId = 8, //Ronflex
            PowerId = 9, //Stun Attack
            Value = 3
        },
        new CardPower
        {
            Id= 7,
            CardId =6, //Alakazam
            PowerId = 5 //Chaos
            ,Value = 0
        },
        new CardPower
        {
            Id = 8,
            CardId= 7, //Onix
            PowerId= 10, //DamageDown
            Value = 1
        },
        // new CardPower
        //{
        //    Id = 9,
        //    CardId= 11, //Avalanche
        //    PowerId= 6, //Earthquake
        //    Value = 0
        //},
        //  new CardPower
        //{
        //    Id = 10,
        //    CardId= 12, //Douleur Random
        //    PowerId= 7, //RandomPain
        //    Value = 0
        //}
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

