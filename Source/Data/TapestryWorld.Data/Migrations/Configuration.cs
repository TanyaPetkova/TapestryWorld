namespace TapestryWorld.Data.Migrations
{
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

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;

            // TODO: Remove in production
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TapestryWorldDbContext context)
        {
            this.userManager = new UserManager<User>(new UserStore<User>(context));
            this.SeedRoles(context);
            //this.SeedUsers(context);
            this.SeedTapestriesWithCategories(context);
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

            string lionImagePath = HttpContext.Current.Server.MapPath(@"~/Content/Images/African Lions In The Savannah Grasses.jpg");
            string gothicImagePath = HttpContext.Current.Server.MapPath(@"~/Content/Images/Gothic Prayer.jpg");
            string landscapeImagePath = HttpContext.Current.Server.MapPath(@"~/Content/Images/Aurora Cabin.jpg");
            string viewFromTheWindowImagePath = HttpContext.Current.Server.MapPath(@"~/Content/Images/A View From The Window.jpg");

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
                     Content = ConvertImageToByteArray(lionImagePath)
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
                    Content = ConvertImageToByteArray(gothicImagePath)
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
                    Content = ConvertImageToByteArray(landscapeImagePath)
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
                    Content = ConvertImageToByteArray(viewFromTheWindowImagePath)
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
                    UserName = this.random.GetRandomStringWithRandomLength(6, 16),
                    Email = string.Format("{0}@{1}.com", this.random.GetRandomStringWithRandomLength(5, 10), this.random.GetRandomStringWithRandomLength(5, 10))
                };

                this.userManager.Create(user, "123456");
            }

            var adminUser = new User
            {
                Email = "admin@mysite.com",
                UserName = "Administrator"
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
