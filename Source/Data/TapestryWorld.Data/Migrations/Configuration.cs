namespace TapestryWorld.Data.Migrations
{
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Linq;
    using System.Web;

    using TapestryWorld.Data.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TapestryWorldDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;

            // TODO: Remove in production
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TapestryWorldDbContext context)
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
                 Image = ConvertImageToByteArray(lionImagePath)
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
                 Image = ConvertImageToByteArray(gothicImagePath)
             },
            };

            context.Tapestries.AddOrUpdate(tapestries.ToArray());
            context.Categories.AddOrUpdate(categories.ToArray());
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
