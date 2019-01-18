using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace LeagueOfLegendsFindTeamApp.Models.DatabaseModels.DatabaseContext
{
    public class DbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            CreateUsers(context);
            CreateLanguages(context);
            CreateLeagues(context);
            CreatePositions(context);
            CreateQueueTypes(context);
            CreateTeamTypes(context);
            CreateRegions(context);


        }

        private static void CreateRegions(ApplicationDbContext context)
        {
            List<Region> regions = new List<Region>
            {
                new Region() {Name = "North America"},
                new Region() {Name = "EU West"},
                new Region() {Name = "EU Nordic & East"},
                new Region() {Name = "Latin America North"},
                new Region() {Name = "Latin America South"},
                new Region() {Name = "Brazil"},
                new Region() {Name = "Turkey"},
                new Region() {Name = "Russia"},
                new Region() {Name = "Oceania"},
                new Region() {Name = "Japan"},
                new Region() {Name = "Korea"}
            };
            regions.ForEach(g => context.Regions.Add(g));
            context.SaveChanges();
        }

        private static void CreateTeamTypes(ApplicationDbContext context)
        {
            List<TeamType> teamTypes = new List<TeamType>
            {
                new TeamType() {Name = "Pro"},
                new TeamType() {Name = "Semi-pro"},
                new TeamType() {Name = "For fun"},

            };
            teamTypes.ForEach(g => context.TeamTypes.Add(g));
            context.SaveChanges();
        }

        private static void CreateQueueTypes(ApplicationDbContext context)
        {
            List<QueueType> queueTypes = new List<QueueType>
            {
                new QueueType() {Name = "SoloQ"},
                new QueueType() {Name = "Flex"},
                new QueueType() {Name = "3vs.3"},
                new QueueType() {Name = "ARAM"},
                new QueueType() {Name = "Special modes"}
            };
            queueTypes.ForEach(g => context.QueueTypes.Add(g));
            context.SaveChanges();
        }

        private static void CreatePositions(ApplicationDbContext context)
        {
            List<Position> positions = new List<Position>
            {
               new Position(){Name = "Top"},
               new Position(){Name = "Mid"},
               new Position(){Name = "Jungle"},
               new Position(){Name = "AdCarry"},
               new Position(){Name = "Support"}
            };
            positions.ForEach(g => context.Positions.Add(g));
            context.SaveChanges();
        }

        private static void CreateLeagues(ApplicationDbContext context)
        {
            List<Image> ironImages = new List<Image>
            {
                new Image()
                {
                    FileName = "Iron4",
                    Url = "https://vignette.wikia.nocookie.net/leagueoflegends/images/7/70/Season_2019_-_Iron_4.png"
                },
                new Image()
                {
                    FileName = "Iron3",
                    Url = "https://vignette.wikia.nocookie.net/leagueoflegends/images/9/95/Season_2019_-_Iron_3.png"
                }, new Image()
                {
                    FileName = "Iron2",
                    Url = "https://vignette.wikia.nocookie.net/leagueoflegends/images/5/5f/Season_2019_-_Iron_2.png"
                }, new Image()
                {
                    FileName = "Iron1",
                    Url = "https://vignette.wikia.nocookie.net/leagueoflegends/images/0/03/Season_2019_-_Iron_1.png"
                },
            };
            ironImages.ForEach(g => context.Images.Add(g));
            context.SaveChanges();

            List<Image> bronzeImages = new List<Image>
            {
                new Image()
                {
                    FileName = "Bronze4",
                    Url = "https://vignette.wikia.nocookie.net/leagueoflegends/images/5/5a/Season_2019_-_Bronze_4.png"
                },
                new Image()
                {
                    FileName = "Bronze3",
                    Url = "https://vignette.wikia.nocookie.net/leagueoflegends/images/8/81/Season_2019_-_Bronze_3.png"
                }, new Image()
                {
                    FileName = "Bronze2",
                    Url = "https://vignette.wikia.nocookie.net/leagueoflegends/images/a/ac/Season_2019_-_Bronze_2.png"
                }, new Image()
                {
                    FileName = "Bronze1",
                    Url = "https://vignette.wikia.nocookie.net/leagueoflegends/images/f/f4/Season_2019_-_Bronze_1.png"
                },
            };
            bronzeImages.ForEach(g => context.Images.Add(g));
            context.SaveChanges();

            List<Image> silverImages = new List<Image>
            {
                new Image()
                {
                    FileName = "silver4",
                    Url = "https://vignette.wikia.nocookie.net/leagueoflegends/images/5/52/Season_2019_-_Silver_4.png"
                },
                new Image()
                {
                    FileName = "silver3",
                    Url = "https://vignette.wikia.nocookie.net/leagueoflegends/images/1/19/Season_2019_-_Silver_3.png"
                }, new Image()
                {
                    FileName = "silver2",
                    Url = "https://vignette.wikia.nocookie.net/leagueoflegends/images/5/56/Season_2019_-_Silver_2.png"
                }, new Image()
                {
                    FileName = "silver1",
                    Url = "https://vignette.wikia.nocookie.net/leagueoflegends/images/7/70/Season_2019_-_Silver_1.png"
                },
            };
            silverImages.ForEach(g => context.Images.Add(g));
            context.SaveChanges();

            List<Image> goldImages = new List<Image>
            {
                new Image()
                {
                    FileName = "gold4",
                    Url = "https://vignette.wikia.nocookie.net/leagueoflegends/images/c/cc/Season_2019_-_Gold_4.png"
                },
                new Image()
                {
                    FileName = "gold3",
                    Url = "https://vignette.wikia.nocookie.net/leagueoflegends/images/a/a6/Season_2019_-_Gold_3.png"
                }, new Image()
                {
                    FileName = "gold2",
                    Url = "https://vignette.wikia.nocookie.net/leagueoflegends/images/8/8a/Season_2019_-_Gold_2.png"
                }, new Image()
                {
                    FileName = "gold1",
                    Url = "https://vignette.wikia.nocookie.net/leagueoflegends/images/9/96/Season_2019_-_Gold_1.png"
                },
            };
            goldImages.ForEach(g => context.Images.Add(g));
            context.SaveChanges();

            List<Image> platinumImages = new List<Image>
            {
                new Image()
                {
                    FileName = "platinum4",
                    Url = "https://vignette.wikia.nocookie.net/leagueoflegends/images/a/ac/Season_2019_-_Platinum_4.png"
                },
                new Image()
                {
                    FileName = "platinum3",
                    Url = "https://vignette.wikia.nocookie.net/leagueoflegends/images/2/2b/Season_2019_-_Platinum_3.png"
                }, new Image()
                {
                    FileName = "platinum2",
                    Url = "https://vignette.wikia.nocookie.net/leagueoflegends/images/a/a3/Season_2019_-_Platinum_2.png"
                }, new Image()
                {
                    FileName = "platinum1",
                    Url = "https://vignette.wikia.nocookie.net/leagueoflegends/images/7/74/Season_2019_-_Platinum_1.png"
                },
            };
            platinumImages.ForEach(g => context.Images.Add(g));
            context.SaveChanges();

            List<Image> diamondImages = new List<Image>
            {
                new Image()
                {
                    FileName = "diamond4",
                    Url = "https://vignette.wikia.nocookie.net/leagueoflegends/images/e/ec/Season_2019_-_Diamond_4.png"
                },
                new Image()
                {
                    FileName = "diamond3",
                    Url = "https://vignette.wikia.nocookie.net/leagueoflegends/images/d/dc/Season_2019_-_Diamond_3.png"
                }, new Image()
                {
                    FileName = "diamond2",
                    Url = "https://vignette.wikia.nocookie.net/leagueoflegends/images/7/70/Season_2019_-_Diamond_2.png"
                }, new Image()
                {
                    FileName = "diamond1",
                    Url = "https://vignette.wikia.nocookie.net/leagueoflegends/images/9/91/Season_2019_-_Diamond_1.png"
                },
            };
            diamondImages.ForEach(g => context.Images.Add(g));
            context.SaveChanges();

            List<Image> masterImages = new List<Image>
            {
                new Image()
                {
                    FileName = "master4",
                    Url = "https://vignette.wikia.nocookie.net/leagueoflegends/images/0/01/Season_2019_-_Master_4.png"
                },
                new Image()
                {
                    FileName = "master3",
                    Url = "https://vignette.wikia.nocookie.net/leagueoflegends/images/4/46/Season_2019_-_Master_3.png"
                }, new Image()
                {
                    FileName = "master2",
                    Url = "https://vignette.wikia.nocookie.net/leagueoflegends/images/9/95/Season_2019_-_Master_2.png"
                }, new Image()
                {
                    FileName = "master1",
                    Url = "https://vignette.wikia.nocookie.net/leagueoflegends/images/1/11/Season_2019_-_Master_1.png"
                },
            };
            masterImages.ForEach(g => context.Images.Add(g));
            context.SaveChanges();

            List<Image> grandMasterImages = new List<Image>
            {
                new Image()
                {
                    FileName = "grandMaster4",
                    Url = "https://vignette.wikia.nocookie.net/leagueoflegends/images/4/42/Season_2019_-_Grandmaster_4.png"
                },
                new Image()
                {
                    FileName = "grandMaster3",
                    Url = "https://vignette.wikia.nocookie.net/leagueoflegends/images/f/f6/Season_2019_-_Grandmaster_3.png"
                }, new Image()
                {
                    FileName = "grandMaster2",
                    Url = "https://vignette.wikia.nocookie.net/leagueoflegends/images/5/58/Season_2019_-_Grandmaster_2.png"
                }, new Image()
                {
                    FileName = "grandMaster1",
                    Url = "https://vignette.wikia.nocookie.net/leagueoflegends/images/7/76/Season_2019_-_Grandmaster_1.png"
                },
            };
            grandMasterImages.ForEach(g => context.Images.Add(g));
            context.SaveChanges();

            List<Image> challengerImages = new List<Image>
            {
                new Image()
                {
                    FileName = "challenger4",
                    Url = "https://vignette.wikia.nocookie.net/leagueoflegends/images/e/e3/Season_2019_-_Challenger_4.png"
                },
                new Image()
                {
                    FileName = "challenger3",
                    Url = "https://vignette.wikia.nocookie.net/leagueoflegends/images/e/e0/Season_2019_-_Challenger_3.png"
                }, new Image()
                {
                    FileName = "challenger2",
                    Url = "https://vignette.wikia.nocookie.net/leagueoflegends/images/2/29/Season_2019_-_Challenger_2.png"
                }, new Image()
                {
                    FileName = "challenger1",
                    Url = "https://vignette.wikia.nocookie.net/leagueoflegends/images/5/5f/Season_2019_-_Challenger_1.png"
                },
            };
            challengerImages.ForEach(g => context.Images.Add(g));
            context.SaveChanges();

            List<League> leagues = new List<League>();


            for (int i = 4; i > 0; i--)
            {
                leagues.Add(new League()
                {
                    Name = "Iron " + GetRomanNumber(i),
                    Division = 9,
                    LeagueValue = 37 - (5 - i),
                    Logo = context.Images.FirstOrDefault(j => j.FileName == "iron" + i.ToString())
                });


                leagues.Add(new League()
                {
                    Name = "Bronze " + GetRomanNumber(i),
                    Division = 8,
                    LeagueValue = 33 - (5 - i),
                    Logo = context.Images.FirstOrDefault(j => j.FileName == "bronze" + i.ToString())
                });


                leagues.Add(new League()
                {
                    Name = "Silver " + GetRomanNumber(i),
                    Division = 7,
                    LeagueValue = 29 - (5 - i),
                    Logo = context.Images.FirstOrDefault(j => j.FileName == "silver" + i.ToString())
                });

                leagues.Add(new League()
                {
                    Name = "Gold " + GetRomanNumber(i),
                    Division = 6,
                    LeagueValue = 25 - (5 - i),
                    Logo = context.Images.FirstOrDefault(j => j.FileName == "gold" + i.ToString())
                });

                leagues.Add(new League()
                {
                    Name = "Platinum " + GetRomanNumber(i),
                    Division = 5,
                    LeagueValue = 21 - (5 - i),
                    Logo = context.Images.FirstOrDefault(j => j.FileName == "platinum" + i.ToString())
                });

                leagues.Add(new League()
                {
                    Name = "Diamond " + GetRomanNumber(i),
                    Division = 4,
                    LeagueValue = 17 - (5 - i),
                    Logo = context.Images.FirstOrDefault(j => j.FileName == "diamond" + i.ToString())
                });

                leagues.Add(new League()
                {
                    Name = "Master - Split " + GetRomanNumber(i),
                    Division = 3,
                    LeagueValue = 13 - (5 - i),
                    Logo = context.Images.FirstOrDefault(j => j.FileName == "master" + i.ToString())
                });

                leagues.Add(new League()
                {
                    Name = "Grandmaster - Split " + GetRomanNumber(i),
                    Division = 2,
                    LeagueValue = 9 - (5 - i),
                    Logo = context.Images.FirstOrDefault(j => j.FileName == "grandMaster" + i.ToString())
                });

                leagues.Add(new League()
                {
                    Name = "Challenger - Split " + GetRomanNumber(i),
                    Division = 1,
                    LeagueValue = 5 - (5 - i),
                    Logo = context.Images.FirstOrDefault(j => j.FileName == "challenger" + i.ToString())
                });
            }
            leagues.ForEach(g => context.Leagues.Add(g));
            context.SaveChanges();
        }

        private static void CreateLanguages(ApplicationDbContext context)
        {
            List<Language> languages = new List<Language>
            {
                new Language(){Name = "English"},
                new Language(){Name = "Polski"}
            };
            languages.ForEach(g => context.Languages.Add(g));
            context.SaveChanges();
        }

        private void CreateUsers(ApplicationDbContext context)
        {
            UserManager<ApplicationUser> userManager =
                new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            ApplicationUser user = new ApplicationUser
            {
                UserName = "Dymek",
                Blocked = false,
                Email = "Kontakt@damiandziura.pl"
            };

            userManager.Create(user, "Damian13!");

            RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            if (!roleManager.RoleExists("Admin"))
            {
                roleManager.Create(new IdentityRole("Admin"));
            }

            userManager.AddToRole(user.Id, "Admin");
        }

        private static string GetRomanNumber(int i)
        {
            switch (i)
            {
                case 1: return "I";
                case 2: return "II";
                case 3: return "III";
                case 4: return "IV";
                default: return "";
            }
        }
    }
}