namespace TapestryWorld.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Linq;
    using System.Web;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using TapestryWorld.Data.Common;
    using TapestryWorld.Data.Models;

    using TapestryImage = TapestryWorld.Data.Models.Image;
    using Image = System.Drawing.Image;

    internal sealed class Configuration : DbMigrationsConfiguration<TapestryWorldDbContext>
    {
        private UserManager<User> userManager;
        private readonly RandomDataGenerator random;

        public string LionImagePath = HttpContext.Current.Server.MapPath(@"~/Content/Images/African Lions In The Savannah Grasses.jpg");
        public string GothicImagePath = HttpContext.Current.Server.MapPath(@"~/Content/Images/Gothic Prayer.jpg");
        public string LandscapeImagePath = HttpContext.Current.Server.MapPath(@"~/Content/Images/Aurora Cabin.jpg");
        public string ViewFromTheWindowImagePath = HttpContext.Current.Server.MapPath(@"~/Content/Images/A View From The Window.jpg");
        public string AngelAndKittyImagePath = HttpContext.Current.Server.MapPath(@"~/Content/Images/Angel and Kitty.jpg");
        public string CleopatraImagePath = HttpContext.Current.Server.MapPath(@"~/Content/Images/Cleopatra.jpg");
        public string FlowersFarceImagePath = HttpContext.Current.Server.MapPath(@"~/Content/Images/Flowers Face.jpg");
        public string IndianWithLeopardImagePath = HttpContext.Current.Server.MapPath(@"~/Content/Images/Indian With Leopard.jpg");

        public string StitchedLandscapeImagePath = HttpContext.Current.Server.MapPath(@"~/Content/Images/Stitched Tapestries/Aurora cabin.jpg");
        public string StitchedWindowImagePath = HttpContext.Current.Server.MapPath(@"~/Content/Images/Stitched Tapestries/A view from the window.jpg");
        public string StitchedAngelImagePath = HttpContext.Current.Server.MapPath(@"~/Content/Images/Stitched Tapestries/Angel and kitty.jpg");
        public string StitchedCleopatra = HttpContext.Current.Server.MapPath(@"~/Content/Images/Stitched Tapestries/Cleopatra.jpg");
        public string StitchedFlowersFaceImagePath = HttpContext.Current.Server.MapPath(@"~/Content/Images/Stitched Tapestries/Flowers Face.jpg");
        public string StitchedGothicPrayerImagePath = HttpContext.Current.Server.MapPath(@"~/Content/Images/Stitched Tapestries/Gothic prayer.jpg");
        public string StitchedIndianImagePath = HttpContext.Current.Server.MapPath(@"~/Content/Images/Stitched Tapestries/Indian With Leopard.jpg");

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            this.random = new RandomDataGenerator();
        }

        protected override void Seed(TapestryWorldDbContext context)
        {
            this.userManager = new UserManager<User>(new UserStore<User>(context));
            this.SeedRoles(context);
            this.SeedUsers(context);
            this.SeedTapestriesWithCategories(context);
            this.SeedStitchedTapestries(context);
            this.SeedComments(context);
        }

        private void SeedStitchedTapestries(TapestryWorldDbContext context)
        {
            if (context.StitchedTapestries.Any())
            {
                return;
            }

            List<StitchedTapestry> tapestries = new List<StitchedTapestry>()
            {
                new StitchedTapestry()
                {
                     Image = new TapestryImage()
                     {
                        Content = ConvertImageToByteArray(StitchedLandscapeImagePath)
                     },
                     Author = context.Users.FirstOrDefault()
                },
                new StitchedTapestry()
                {
                     Image = new TapestryImage()
                     {
                          Content = ConvertImageToByteArray(StitchedAngelImagePath)
                     },
                      Author = context.Users.FirstOrDefault()
                },
                 new StitchedTapestry()
                {
                     Image = new TapestryImage()
                     {
                          Content = ConvertImageToByteArray(StitchedCleopatra)
                     },
                      Author = context.Users.FirstOrDefault()
                },
                 new StitchedTapestry()
                {
                     Image = new TapestryImage()
                     {
                          Content = ConvertImageToByteArray(StitchedFlowersFaceImagePath)
                     },
                      Author = context.Users.FirstOrDefault()
                },
                 new StitchedTapestry()
                {
                     Image = new TapestryImage()
                     {
                          Content = ConvertImageToByteArray(StitchedGothicPrayerImagePath)
                     },
                      Author = context.Users.FirstOrDefault()
                },
                 new StitchedTapestry()
                {
                     Image = new TapestryImage()
                     {
                          Content = ConvertImageToByteArray(StitchedIndianImagePath)
                     },
                      Author = context.Users.FirstOrDefault()
                },
                 new StitchedTapestry()
                {
                     Image = new TapestryImage()
                     {
                          Content = ConvertImageToByteArray(StitchedWindowImagePath)
                     },
                      Author = context.Users.FirstOrDefault()
                }
            };

            context.StitchedTapestries.AddOrUpdate(tapestries.ToArray());
            context.SaveChanges();
        }

        private void SeedComments(TapestryWorldDbContext context)
        {
            if (context.Comments.Any())
            {
                return;
            }

            foreach (var tapestry in context.StitchedTapestries)
            {
                for (int i = 0; i < 10; i++)
                {
                    tapestry.Comments.Add(new Comment()
                    {
                        Content = this.random.GetRandomStringWithRandomLength(10, 100),
                        Author = context.Users.FirstOrDefault()
                    });
                }
            }

            context.SaveChanges();
        }

        private void SeedTapestriesWithCategories(TapestryWorldDbContext context)
        {
            if (context.Tapestries.Any())
            {
                return;
            }

            List<Category> categories = new List<Category>()
            {
              new Category()
              {
                  Name = "Classics"
              },
              new Category()
              {
                  Name = "Religious"
              }, 
              new Category()
              {
                  Name = "Animals"
              },
              new Category()
              {
                  Name = "Flowers"
              },
              new Category()
              {
                  Name = "Landscapes"
              }
            };

            List<Tapestry> tapestries = new List<Tapestry>()
            {
                 new Tapestry
                 {
                     Name = "African Lion",
                     Price = (decimal)30.99,
                     Dimension = new Dimension()
                     {
                         Width = 46,
                         Height = 25,                    
                     },
                     DesignerName = "Domald Grant",
                     Category = categories[2],
                     StitchType = StitchType.Crossstitch,
                     Image = new TapestryImage()
                     {
                         Content = ConvertImageToByteArray(LionImagePath)
                     }
                 },
                 new Tapestry
                 {
                     Name = "Gothic prayer",
                     Price = (decimal)46.00,
                     Dimension = new Dimension()
                     {
                         Width = 31,
                         Height = 42,                    
                     },
                     DesignerName = "Ani Yoveva",
                     Category = categories[1],
                     StitchType = StitchType.Crossstitch,
                     Image = new TapestryImage()
                     {
                        Content = ConvertImageToByteArray(GothicImagePath)
                     }
                 },
                 new Tapestry
                 {
                     Name = "Aurora Cabin",
                     Price = (decimal)33.99,
                     Dimension = new Dimension()
                     {
                         Width = 41,
                         Height = 30,                    
                     },
                     DesignerName = "Kim Norlien",
                     Category = categories[4],
                     StitchType = StitchType.Crossstitch,
                     Image = new TapestryImage()
                     {
                        Content = ConvertImageToByteArray(LandscapeImagePath)
                     }
                 },
                 new Tapestry
                 {
                     Name = "A view from the window",
                     Price = (decimal)21.99,
                     Dimension = new Dimension()
                     {
                         Width = 28,
                         Height = 35,                    
                     },
                     DesignerName = "Nancy Rossi ",
                     Category = categories[4],
                     StitchType = StitchType.Crossstitch,
                     Image = new TapestryImage()
                     {
                        Content = ConvertImageToByteArray(ViewFromTheWindowImagePath)
                     }
                 },
                 new Tapestry
                 {
                      Name = "Angel and kitty",
                      Price = (decimal)155.00,
                      Dimension = new Dimension()
                      {
                           Width = 47,
                           Height = 65
                      },
                      DesignerName = "Maria Todorva",
                      Category = categories[2],
                      StitchType = StitchType.HalfStitch,
                      Image = new TapestryImage()
                      {
                          Content = ConvertImageToByteArray(AngelAndKittyImagePath)
                      }
                 },
                 new Tapestry
                 {
                      Name = "Flowers face",
                      Price = (decimal)44.09,
                      Dimension = new Dimension()
                      {
                           Width = 27,
                           Height = 28
                      },
                      DesignerName = "Lanarte",
                      Category = categories[3],
                      StitchType = StitchType.Crossstitch,
                      Image = new TapestryImage()
                      {
                          Content = ConvertImageToByteArray(FlowersFarceImagePath)
                      }
                 },
                 new Tapestry
                 {
                      Name = "Cleopatra",
                      Price = (decimal)122,
                      Dimension = new Dimension()
                      {
                           Width = 67,
                           Height = 49
                      },
                      DesignerName = "Vachevi",
                      Category = categories[0],
                      StitchType = StitchType.HalfStitch,
                      Image = new TapestryImage()
                      {
                          Content = ConvertImageToByteArray(CleopatraImagePath)
                      }
                 },
                 new Tapestry
                 {
                      Name = "Indian girl with leopard",
                      Price = (decimal)99.00,
                      Dimension = new Dimension()
                      {
                           Width = 64,
                           Height = 40
                      },
                      DesignerName = "Maria Todorva",
                      Category = categories[2],
                      StitchType = StitchType.HalfStitch,
                      Image = new TapestryImage()
                      {
                          Content = ConvertImageToByteArray(IndianWithLeopardImagePath)
                      }
                 }
            };

            context.Tapestries.AddOrUpdate(tapestries.ToArray());
            context.Categories.AddOrUpdate(categories.ToArray());
        }

        private void SeedRoles(TapestryWorldDbContext context)
        {
            context.Roles.AddOrUpdate(x => x.Name, new IdentityRole(GlobalConstants.AdminRole));
            context.SaveChanges();
        }

        private void SeedUsers(TapestryWorldDbContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

            for (int i = 0; i < 10; i++)
            {
                var user = new User
                {
                    Email = string.Format("{0}@{1}.com", this.random.GetRandomStringWithRandomLength(6, 16), this.random.GetRandomStringWithRandomLength(6, 16)),
                    UserName = this.random.GetRandomStringWithRandomLength(6, 16)
                };

                this.userManager.Create(user, "123456");
            }

            var adminUser = new User
            {
                Email = "admin@mysite.com",
                UserName = "Administrator",
            };

            this.userManager.Create(adminUser, "123456");
            this.userManager.AddToRole(adminUser.Id, GlobalConstants.AdminRole);
        }

        private static byte[] ConvertImageToByteArray(string fileName)
        {
            Bitmap bitMap = new Bitmap(fileName);
            ImageFormat bmpFormat = bitMap.RawFormat;
            var imageToConvert = Image.FromFile(fileName);
            using (MemoryStream ms = new MemoryStream())
            {
                imageToConvert.Save(ms, bmpFormat);
                return ms.ToArray();
            }
        }
    }
}
