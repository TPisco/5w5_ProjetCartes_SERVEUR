using System;
using System.Drawing;
using Microsoft.AspNetCore.Identity;
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
                    ImageUrl = "https://pm1.aminoapps.com/6906/f456d54f84291a3e3a9532251214cda80cbef906r1-335-431v2_hq.jpg"
                }, new Card
                {
                    Id = 2,
                    Name = "Rayquaza",
                    Attack = 10,
                    Health = 5,
                    Cost = 9,
                    ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/384.png"
                }, new Card
                {
                    Id = 3,
                    Name = "Rondoudou",
                    Attack = 2,
                    Health = 1,
                    Cost = 1,
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/en/2/22/Pok%C3%A9mon_Jigglypuff_art.png"
                }, new Card
                {
                    Id = 4,
                    Name = "Mewtwo",
                    Attack = 8,
                    Health = 4,
                    Cost = 6,
                    ImageUrl = "https://e7.pngegg.com/pngimages/993/391/png-clipart-pokemon-character-illustration-pokemon-x-and-y-pokemon-go-pokemon-black-white-mewtwo-pokemon-go-purple-mammal.png"
                }, new Card
                {
                    Id = 5,
                    Name = "Gardevoir",
                    Attack = 7,
                    Health = 7,
                    Cost = 5,
                    ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/282.png"
                }, new Card
                {
                    Id = 6,
                    Name = "Alakazam",
                    Attack = 4,
                    Health = 2,
                    Cost = 2,
                    ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/065.png"
                }, new Card
                {
                    Id = 7,
                    Name = "Onix",
                    Attack = 6,
                    Health = 3,
                    Cost = 4,
                    ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/095.png"
                }, new Card
                {
                    Id = 8,
                    Name = "Ronflex",
                    Attack = 1,
                    Health = 9,
                    Cost = 2,
                    ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/143.png"
                }, new Card
                {
                    Id = 9,
                    Name = "Mew",
                    Attack = 5,
                    Health = 1,
                    Cost = 2,
                    ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/151.png"
                }, new Card
                {
                    Id = 10,
                    Name = "Dracofeu",
                    Attack = 6,
                    Health = 1,
                    Cost = 2,
                    ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/006_f2.png"
                }
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
                    Id = 3, Name = "Heal", Description = "Soigne les cartes alliées de X incluant elle-même AVANT d’attaquer (mais les cartes ne peuvent pas avoir plus de health qu’au départ.)", Icon = "💖", HasValue = true
                },
                new Power
                {
                    Id = 4, Name = "Shield", Description = "Augmente la défense d'une carte de X", Icon = "🛡️", HasValue = true
                },

            };
        }

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
        }
    };
        }


        //public static Power[] SeedPower()
        //{
        //    return new Power[]
        //    {
        //        new Power
        //        {
        //            Id = 1, Name = "First Strike", Description = "Permet à une carte d’attaquer en « premier » et de ne pas recevoir de dégât si elle tue la carte de l’adversaire.", Icon = "🥇", HasValue = false
        //        },
        //        new Power
        //        {
        //            Id = 2, Name = "Thorns", Description = "Lorsqu’une carte défend, elle inflige X de dégâts AVANT de recevoir des dégâts. Si l’attaquant est tué par ces dégâts, l’attaque s’arrête et le défenseur ne reçoit pas de dégâts.", Icon = "🌹", HasValue = true
        //        },
        //        new Power
        //        {
        //            Id = 3, Name = "Heal", Description = "Soigne les cartes alliées de X incluant elle-même AVANT d’attaquer (mais les cartes ne peuvent pas avoir plus de health qu’au départ.)", Icon = "💖", HasValue = true
        //        },
        //        new Power
        //        {
        //            Id = 4, Name = "Shield", Description = "Augmente la défense d'une carte de X", Icon = "🛡️", HasValue = true
        //        },

        //    };
        //}

        public static GameConfig seedGameConfig()
        {
            return new GameConfig { id = 1, nbCardsToDraw = 4, QtManaParTour = 3 };
        }
    }
}

