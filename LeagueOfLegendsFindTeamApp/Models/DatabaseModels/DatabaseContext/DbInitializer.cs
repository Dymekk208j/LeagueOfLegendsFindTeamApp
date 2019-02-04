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
            CreatePlayerIcons(context);
            CreateLanguages(context);
            CreateLeagues(context);
            CreateUsers(context);
            CreatePositions(context);
            CreateQueueTypes(context);
            CreateTeamTypes(context);
            CreateRegions(context);
            CreateChampions(context);
        }

        private void CreatePlayerIcons(ApplicationDbContext context)
        {
            string mainUrl = "http://ddragon.leagueoflegends.com/cdn/6.24.1/img/profileicon/";
            List<Image> playerIcons = new List<Image>();

            for (int i = 0; i < 28; i++)
            {
                playerIcons.Add(new Image()
                {
                    FileName = i.ToString() + ".png",
                    Title = i.ToString(),
                    ImageType = ImageType.PlayerIcon,
                    Url = mainUrl + i.ToString() + ".png"
                });
            }
          
            playerIcons.ForEach(g => context.Images.Add(g));
            context.SaveChanges();
        }

        private void CreateChampions(ApplicationDbContext context)
        {

            string mainUrl = "http://ddragon.leagueoflegends.com/cdn/6.24.1/img/champion/";
            List<Image> championsImages = new List<Image>
            {
                new Image()
                {
                    FileName = "Aatrox.png",
                    Title = "Aatrox"
                },
                new Image()
                {
                    FileName = "Ahri.png",
                    Title = "Ahri"
                },
                new Image()
                {
                    FileName = "Akali.png",
                    Title = "Akali"
                },
                new Image()
                {
                    FileName = "Alistar.png",
                    Title = "Alistar"
                },
                new Image()
                {
                    FileName = "Amumu.png",
                    Title = "Amumu"
                },
               
            };

            championsImages.ForEach(g => g.Url = mainUrl + g.FileName);
            championsImages.ForEach(g => g.ImageType = ImageType.ChampionIcon);
            championsImages.ForEach(g => context.Images.Add(g));
            context.SaveChanges();

            mainUrl = "http://ddragon.leagueoflegends.com/cdn/img/champion/loading/";
            List<Image> championsPortraits = new List<Image>
            {
                new Image()
                {
                    FileName = "Aatrox_0.jpg",
                    Title = "Aatrox portrait"
                },
                new Image()
                {
                    FileName = "Ahri_0.jpg",
                    Title = "Ahri portrait"
                },
                new Image()
                {
                    FileName = "Akali_0.jpg",
                    Title = "Akali portrait"
                },
                new Image()
                {
                    FileName = "Alistar_0.jpg",
                    Title = "Alistar portrait"
                },
                new Image()
                {
                    FileName = "Amumu_0.jpg",
                    Title = "Amumu portrait"
                },
            };

            championsPortraits.ForEach(g => g.Url = mainUrl + g.FileName);
            championsPortraits.ForEach(g => g.ImageType = ImageType.ChampionPortrait);
            championsPortraits.ForEach(g => context.Images.Add(g));
            context.SaveChanges();


            List<Champion> champions = new List<Champion>
            {
                new Champion()
                {
                    Name = "Aatrox",
                    Icon = context.Images.FirstOrDefault(j => j.FileName == "Aatrox.png"),
                    Portrait = context.Images.FirstOrDefault(j => j.FileName == "Aatrox_0.jpg")
                },
                new Champion()
                {
                    Name = "Ahri",
                    Icon = context.Images.FirstOrDefault(j => j.FileName == "Ahri.png"),
                    Portrait = context.Images.FirstOrDefault(j => j.FileName == "Ahri_0.jpg")
                },
                new Champion()
                {
                    Name = "Akali",
                    Icon = context.Images.FirstOrDefault(j => j.FileName == "Akali.png"),
                    Portrait = context.Images.FirstOrDefault(j => j.FileName == "Akali_0.jpg")
                },
                new Champion()
                {
                    Name = "Alistar",
                    Icon = context.Images.FirstOrDefault(j => j.FileName == "Alistar.png"),
                    Portrait = context.Images.FirstOrDefault(j => j.FileName == "Alistar_0.jpg")
                },
                new Champion()
                {
                    Name = "Amumu",
                    Icon = context.Images.FirstOrDefault(j => j.FileName == "Amumu.png"),
                    Portrait = context.Images.FirstOrDefault(j => j.FileName == "Amumu_0.jpg")
                }
            };



            champions.ForEach(g => context.Champions.Add(g));
            context.SaveChanges();
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
                    FileName = "Unranked",
                    Title = "Unranked",
                    Url = "https://vignette.wikia.nocookie.net/leagueoflegends/images/1/1c/Season_2013_-_Unranked.png"
                },
                new Image()
                {
                    FileName = "Iron4",
                    Title = "Iron4",
                    Url = "https://vignette.wikia.nocookie.net/leagueoflegends/images/7/70/Season_2019_-_Iron_4.png"
                },
                new Image()
                {
                    FileName = "Iron3",
                    Title = "Iron3",
                    Url = "https://vignette.wikia.nocookie.net/leagueoflegends/images/9/95/Season_2019_-_Iron_3.png"
                }, new Image()
                {
                    FileName = "Iron2",
                    Title = "Iron2",
                    Url = "https://vignette.wikia.nocookie.net/leagueoflegends/images/5/5f/Season_2019_-_Iron_2.png"
                }, new Image()
                {
                    FileName = "Iron1",
                    Title = "Iron1",
                    Url = "https://vignette.wikia.nocookie.net/leagueoflegends/images/0/03/Season_2019_-_Iron_1.png"
                },
            };

            ironImages.ForEach(g => g.ImageType = ImageType.DivisionIcon);
            ironImages.ForEach(g => context.Images.Add(g));
            context.SaveChanges();

            List<Image> bronzeImages = new List<Image>
            {
                new Image()
                {
                    FileName = "Bronze4",
                    Title = "Bronze4",
                    Url = "https://vignette.wikia.nocookie.net/leagueoflegends/images/5/5a/Season_2019_-_Bronze_4.png"
                },
                new Image()
                {
                    FileName = "Bronze3",
                    Title = "Bronze3",
                    Url = "https://vignette.wikia.nocookie.net/leagueoflegends/images/8/81/Season_2019_-_Bronze_3.png"
                }, new Image()
                {
                    FileName = "Bronze2",
                    Title = "Bronze2",
                    Url = "https://vignette.wikia.nocookie.net/leagueoflegends/images/a/ac/Season_2019_-_Bronze_2.png"
                }, new Image()
                {
                    FileName = "Bronze1",
                    Title = "Bronze1",
                    Url = "https://vignette.wikia.nocookie.net/leagueoflegends/images/f/f4/Season_2019_-_Bronze_1.png"
                },
            };
            bronzeImages.ForEach(g => g.ImageType = ImageType.DivisionIcon);
            bronzeImages.ForEach(g => context.Images.Add(g));
            context.SaveChanges();

            List<Image> silverImages = new List<Image>
            {
                new Image()
                {
                    FileName = "silver4",
                    Title = "silver4",
                    Url = "https://vignette.wikia.nocookie.net/leagueoflegends/images/5/52/Season_2019_-_Silver_4.png"
                },
                new Image()
                {
                    FileName = "silver3",
                    Title = "silver3",
                    Url = "https://vignette.wikia.nocookie.net/leagueoflegends/images/1/19/Season_2019_-_Silver_3.png"
                }, new Image()
                {
                    FileName = "silver2",
                    Title = "silver2",
                    Url = "https://vignette.wikia.nocookie.net/leagueoflegends/images/5/56/Season_2019_-_Silver_2.png"
                }, new Image()
                {
                    FileName = "silver1",
                    Title = "silver1",
                    Url = "https://vignette.wikia.nocookie.net/leagueoflegends/images/7/70/Season_2019_-_Silver_1.png"
                },
            };
            silverImages.ForEach(g => g.ImageType = ImageType.DivisionIcon);
            silverImages.ForEach(g => context.Images.Add(g));
            context.SaveChanges();

            List<Image> goldImages = new List<Image>
            {
                new Image()
                {
                    FileName = "gold4",
                    Title = "gold4",
                    Url = "https://vignette.wikia.nocookie.net/leagueoflegends/images/c/cc/Season_2019_-_Gold_4.png"
                },
                new Image()
                {
                    FileName = "gold3",
                    Title = "gold3",
                    Url = "https://vignette.wikia.nocookie.net/leagueoflegends/images/a/a6/Season_2019_-_Gold_3.png"
                }, new Image()
                {
                    FileName = "gold2",
                    Title = "gold2",
                    Url = "https://vignette.wikia.nocookie.net/leagueoflegends/images/8/8a/Season_2019_-_Gold_2.png"
                }, new Image()
                {
                    FileName = "gold1",
                    Title = "gold1",
                    Url = "https://vignette.wikia.nocookie.net/leagueoflegends/images/9/96/Season_2019_-_Gold_1.png"
                },
            };
            goldImages.ForEach(g => g.ImageType = ImageType.DivisionIcon);
            goldImages.ForEach(g => context.Images.Add(g));
            context.SaveChanges();

            List<Image> platinumImages = new List<Image>
            {
                new Image()
                {
                    FileName = "platinum4",
                    Title = "platinum4",
                    Url = "https://vignette.wikia.nocookie.net/leagueoflegends/images/a/ac/Season_2019_-_Platinum_4.png"
                },
                new Image()
                {
                    FileName = "platinum3",
                    Title = "platinum3",
                    Url = "https://vignette.wikia.nocookie.net/leagueoflegends/images/2/2b/Season_2019_-_Platinum_3.png"
                }, new Image()
                {
                    FileName = "platinum2",
                    Title = "platinum2",
                    Url = "https://vignette.wikia.nocookie.net/leagueoflegends/images/a/a3/Season_2019_-_Platinum_2.png"
                }, new Image()
                {
                    FileName = "platinum1",
                    Title = "platinum1",
                    Url = "https://vignette.wikia.nocookie.net/leagueoflegends/images/7/74/Season_2019_-_Platinum_1.png"
                },
            };
            platinumImages.ForEach(g => g.ImageType = ImageType.DivisionIcon);
            platinumImages.ForEach(g => context.Images.Add(g));
            context.SaveChanges();

            List<Image> diamondImages = new List<Image>
            {
                new Image()
                {
                    FileName = "diamond4",
                    Title = "diamond4",
                    Url = "https://vignette.wikia.nocookie.net/leagueoflegends/images/e/ec/Season_2019_-_Diamond_4.png"
                },
                new Image()
                {
                    FileName = "diamond3",
                    Title = "diamond3",
                    Url = "https://vignette.wikia.nocookie.net/leagueoflegends/images/d/dc/Season_2019_-_Diamond_3.png"
                }, new Image()
                {
                    FileName = "diamond2",
                    Title = "diamond2",
                    Url = "https://vignette.wikia.nocookie.net/leagueoflegends/images/7/70/Season_2019_-_Diamond_2.png"
                }, new Image()
                {
                    FileName = "diamond1",
                    Title = "diamond1",
                    Url = "https://vignette.wikia.nocookie.net/leagueoflegends/images/9/91/Season_2019_-_Diamond_1.png"
                },
            };
            diamondImages.ForEach(g => g.ImageType = ImageType.DivisionIcon);
            diamondImages.ForEach(g => context.Images.Add(g));
            context.SaveChanges();

            List<Image> masterImages = new List<Image>
            {
                new Image()
                {
                    FileName = "master4",
                    Title = "master4",
                    Url = "https://vignette.wikia.nocookie.net/leagueoflegends/images/0/01/Season_2019_-_Master_4.png"
                },
                new Image()
                {
                    FileName = "master3",
                    Title = "master3",
                    Url = "https://vignette.wikia.nocookie.net/leagueoflegends/images/4/46/Season_2019_-_Master_3.png"
                }, new Image()
                {
                    FileName = "master2",
                    Title = "master2",
                    Url = "https://vignette.wikia.nocookie.net/leagueoflegends/images/9/95/Season_2019_-_Master_2.png"
                }, new Image()
                {
                    FileName = "master1",
                    Title = "master1",
                    Url = "https://vignette.wikia.nocookie.net/leagueoflegends/images/1/11/Season_2019_-_Master_1.png"
                },
            };
            masterImages.ForEach(g => g.ImageType = ImageType.DivisionIcon);
            masterImages.ForEach(g => context.Images.Add(g));
            context.SaveChanges();

            List<Image> grandMasterImages = new List<Image>
            {
                new Image()
                {
                    Title = "grandMaster4",
                    FileName = "grandMaster4",
                    Url = "https://vignette.wikia.nocookie.net/leagueoflegends/images/4/42/Season_2019_-_Grandmaster_4.png"
                },
                new Image()
                {
                    FileName = "grandMaster3",
                    Title = "grandMaster3",
                    Url = "https://vignette.wikia.nocookie.net/leagueoflegends/images/f/f6/Season_2019_-_Grandmaster_3.png"
                }, new Image()
                {
                    FileName = "grandMaster2",
                    Title = "grandMaster2",
                    Url = "https://vignette.wikia.nocookie.net/leagueoflegends/images/5/58/Season_2019_-_Grandmaster_2.png"
                }, new Image()
                {
                    FileName = "grandMaster1",
                    Title = "grandMaster1",
                    Url = "https://vignette.wikia.nocookie.net/leagueoflegends/images/7/76/Season_2019_-_Grandmaster_1.png"
                },
            };
            grandMasterImages.ForEach(g => g.ImageType = ImageType.DivisionIcon);
            grandMasterImages.ForEach(g => context.Images.Add(g));
            context.SaveChanges();

            List<Image> challengerImages = new List<Image>
            {
                new Image()
                {
                    FileName = "challenger4",
                    Title = "challenger4",
                    Url = "https://vignette.wikia.nocookie.net/leagueoflegends/images/e/e3/Season_2019_-_Challenger_4.png"
                },
                new Image()
                {
                    FileName = "challenger3",
                    Title = "challenger3",
                    Url = "https://vignette.wikia.nocookie.net/leagueoflegends/images/e/e0/Season_2019_-_Challenger_3.png"
                }, new Image()
                {
                    FileName = "challenger2",
                    Title = "challenger2",
                    Url = "https://vignette.wikia.nocookie.net/leagueoflegends/images/2/29/Season_2019_-_Challenger_2.png"
                }, new Image()
                {
                    FileName = "challenger1",
                    Title = "challenger1",
                    Url = "https://vignette.wikia.nocookie.net/leagueoflegends/images/5/5f/Season_2019_-_Challenger_1.png"
                },
            };
            challengerImages.ForEach(g => g.ImageType = ImageType.DivisionIcon);
            challengerImages.ForEach(g => context.Images.Add(g));
            context.SaveChanges();

            List<League> leagues = new List<League>();
            leagues.Add(new League()
            {
                Name = "Unranked",
                Division = Division.Unranked,
                LeagueValue = 0,
                Logo = context.Images.FirstOrDefault(j => j.FileName == "Unranked")
            });

            for (int i = 4; i > 0; i--)
            {
                leagues.Add(new League()
                {
                    Name = "Iron " + GetRomanNumber(i),
                    Division = Division.Iron,
                    LeagueValue = 5 - i,
                    Logo = context.Images.FirstOrDefault(j => j.FileName == "iron" + i.ToString())
                });


                leagues.Add(new League()
                {
                    Name = "Bronze " + GetRomanNumber(i),
                    Division = Division.Bronze,
                    LeagueValue = 9 - i,
                    Logo = context.Images.FirstOrDefault(j => j.FileName == "bronze" + i.ToString())
                });


                leagues.Add(new League()
                {
                    Name = "Silver " + GetRomanNumber(i),
                    Division = Division.Silver,
                    LeagueValue = 13 - i,
                    Logo = context.Images.FirstOrDefault(j => j.FileName == "silver" + i.ToString())
                });

                leagues.Add(new League()
                {
                    Name = "Gold " + GetRomanNumber(i),
                    Division = Division.Gold,
                    LeagueValue = 17 - i, 
                    Logo = context.Images.FirstOrDefault(j => j.FileName == "gold" + i.ToString())
                });

                leagues.Add(new League()
                {
                    Name = "Platinum " + GetRomanNumber(i),
                    Division = Division.Platinum,
                    LeagueValue = 21 - i,
                    Logo = context.Images.FirstOrDefault(j => j.FileName == "platinum" + i.ToString())
                });

                leagues.Add(new League()
                {
                    Name = "Diamond " + GetRomanNumber(i),
                    Division = Division.Diamond,
                    LeagueValue = 25 - i,
                    Logo = context.Images.FirstOrDefault(j => j.FileName == "diamond" + i.ToString())
                });

                leagues.Add(new League()
                {
                    Name = "Master - Split " + GetRomanNumber(i),
                    Division = Division.Master,
                    LeagueValue = 29 - i,
                    Logo = context.Images.FirstOrDefault(j => j.FileName == "master" + i.ToString())
                });

                leagues.Add(new League()
                {
                    Name = "Grandmaster - Split " + GetRomanNumber(i),
                    Division = Division.GrandMaster,
                    LeagueValue = 33 - i,
                    Logo = context.Images.FirstOrDefault(j => j.FileName == "grandMaster" + i.ToString())
                });

                leagues.Add(new League()
                {
                    Name = "Challenger - Split " + GetRomanNumber(i),
                    Division = Division.Challenger,
                    LeagueValue = 37 - i,
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
                Email = "Kontakt@damiandziura.pl",
                GamerProfile = new GamerProfile()
                {
                    SoloQLeague = context.Leagues.First(m => m.LeagueValue == 0),
                    FlexLeague = context.Leagues.First(m => m.LeagueValue == 0),
                    League3 = context.Leagues.First(m => m.LeagueValue == 0)
                },
                ContactDetails = new Contact()
                {
                    DiscordId = "DiscordID",
                    FacebookLink = "FacebookLink",
                    PhoneNo = "123-123-123",
                    SkypeId = "SkypeID"
                },
                Person = new Person()
                {
                    FirstName = "Damian"
                }

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