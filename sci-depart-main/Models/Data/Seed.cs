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
            var cards = new List<Card>();
            string baseUrl = "https://assets.pokemon.com/assets/cms2/img/pokedex/full/";

            // Première Génération – liste partielle (complète jusqu'au 151)
            string[] gen1 = new string[]
            {
        "Bulbizarre", "Herbizarre", "Florizarre", "Salamèche", "Reptincel", "Dracaufeu",
        "Carapuce", "Carabaffe", "Tortank", "Chenipan", "Chrysacier", "Papilusion",
        "Aspicot", "Coconfort", "Dardargnan","Roucool", "Roucoups", "Roucarnage", 
                "Rattata", "Rattatac", "Piafabec", "Rapasdepic", "Abo", "Arbok", 
                "Pikachu", "Raichu", "Sabelette", "Sablaireau", "Nidoran♀", "Nidorina", 
                "Nidoqueen", "Nidoran♂", "Nidorino", "Nidoking", "Mélofée", "Mélodelfe",
                "Goupix", "Feunard", "Rondoudou", "Grodoudou", "Nosferapti", "Nosferalto",
                "Mystherbe", "Ortide", "Rafflesia", "Paras", "Parasect", "Mimitoss", "Aéromite",
                "Taupiqueur", "Triopikeur", "Miaouss", "Persian", "Psykokwak", "Akwakwak", "Férosinge",
                "Colossinge", "Caninos", "Arcanin", "Ptitard", "Têtarte", "Tartard", "Abra", "Kadabra",
                "Alakazam", "Machoc", "Machopeur", "Mackogneur", "Chétiflor", "Boustiflor", "Empiflor", 
                "Tentacool", "Tentacruel", "Racaillou", "Gravalanch", "Grolem", "Ponyta", "Galopa", "Ramoloss",
                "Flagadoss", "Magnéti", "Magnéton", "Canarticho", "Doduo", "Dodrio", "Otaria", "Lamantine", "Tadmorv",
                "Grotadmorv", "Kokiyas", "Crustabri", "Fantominus", "Spectrum", "Ectoplasma", "Onix", "Soporifik", "Hypnomade",
                "Krabby", "Krabboss", "Voltorbe", "Électrode", "Noeunoeuf", "Noadkoko", "Osselait", "Ossatueur", "Kicklee", "Tygnon", 
                "Excelangue", "Smogo", "Smogogo", "Rhinocorne", "Rhinoféros", "Leveinard", "Saquedeneu", "Kangourex", "Hypotrempe",
                "Hypocéan", "Poissirène", "Poissoroy", "Stari", "Staross", "M. Mime", "Insécateur", "Lippoutou", "Élektek", "Magmar",
                "Scarabrute", "Tauros", "Magicarpe", "Léviator", "Lokhlass", "Métamorph", "Évoli", "Aquali", "Voltali", "Pyroli", "Porygon",
                "Amonita", "Amonistar", "Kabuto", "Kabutops", "Ptéra", "Ronflex", "Artikodin", "Électhor", "Sulfura", "Minidraco", "Draco",
                "Dracolosse", "Mewtwo", "Mew"

                // ... ajoute ici les noms restants jusqu'au 151ème Pokémon
            };

            int id = 1;
            foreach (var name in gen1)
            {
                // Pour cet exemple, on se base sur de formules simples afin de générer des statistiques.
                // Tu pourras ajuster (ou remplacer par une lecture depuis un fichier/config) selon l’équilibrage désiré.
                int attack = 3 + (id % 5);    // formule d'exemple pour l'attaque
                int health = 4 + (id % 7);    // formule d'exemple pour la vie
                int cost = 2 + (id % 4);      // formule d'exemple pour le coût

                cards.Add(new Card
                {
                    Id = id,
                    Name = name,
                    Attack = attack,
                    Health = health,
                    Cost = cost,
                    ImageUrl = baseUrl + id.ToString("D3") + ".png"
                });
                id++;
            }

            // Deuxième Génération – liste partielle (complète jusqu'à 100 noms)
            string[] gen2 = new string[]
            {
        "Germignon", "Macronium", "Méganium",
        "Héricendre", "Feurisson", "Typhlosion",
        "Kaiminus", "Crocrodil", "Aligatueur",
                // ... ajoute ici les noms restants pour atteindre 100 Pokémon de la génération 2
            };

            foreach (var name in gen2)
            {
                int attack = 3 + (id % 5);
                int health = 4 + (id % 7);
                int cost = 2 + (id % 4);

                cards.Add(new Card
                {
                    Id = id,
                    Name = name,
                    Attack = attack,
                    Health = health,
                    Cost = cost,
                    ImageUrl = baseUrl + id.ToString("D3") + ".png"
                });
                id++;
            }

            return cards.ToArray();
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


        public static GameConfig seedGameConfig()
        {
            return new GameConfig { id = 1, nbCardsToDraw = 4, QtManaParTour = 3 };
        }
    }
}

