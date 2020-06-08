namespace NorthwindDB.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<NorthwindDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(NorthwindDB context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            Category[] defaultCategories = new Category[4];
            Region[] defaultRegions = new Region[4];
            Territory[] defaultTerritories = new Territory[8];

            defaultCategories[0] = new Category() { CategoryID = 1, CategoryName = "Beverages", Description = "Soft drinks, coffees, teas, beers, and ales" };
            defaultCategories[1] = new Category() { CategoryID = 2, CategoryName = "Condiments", Description = "Sweet and savory sauces, relishes, spreads, and seasonings" };
            defaultCategories[2] = new Category() { CategoryID = 3, CategoryName = "Confections", Description = "Desserts, candies, and sweet breads" };
            defaultCategories[3] = new Category() { CategoryID = 4, CategoryName = "Dairy Products", Description = "Cheeses" };

            defaultRegions[0] = new Region() { RegionID = 1, RegionDescription = "Eastern" };
            defaultRegions[1] = new Region() { RegionID = 2, RegionDescription = "Western" };
            defaultRegions[2] = new Region() { RegionID = 3, RegionDescription = "Northern" };
            defaultRegions[3] = new Region() { RegionID = 4, RegionDescription = "Southern" };

            defaultTerritories[0] = new Territory() { TerritoryID = "1", TerritoryDescription = "Westboro", RegionID = 1 };
            defaultTerritories[1] = new Territory() { TerritoryID = "2", TerritoryDescription = "Bedford", RegionID = 2 };
            defaultTerritories[2] = new Territory() { TerritoryID = "3", TerritoryDescription = "Georgetow", RegionID = 3 };
            defaultTerritories[3] = new Territory() { TerritoryID = "4", TerritoryDescription = "Boston", RegionID = 4 };
            defaultTerritories[4] = new Territory() { TerritoryID = "5", TerritoryDescription = "Cambridge", RegionID = 1 };
            defaultTerritories[5] = new Territory() { TerritoryID = "6", TerritoryDescription = "Braintree", RegionID = 2 };
            defaultTerritories[6] = new Territory() { TerritoryID = "7", TerritoryDescription = "Providence", RegionID = 3 };
            defaultTerritories[7] = new Territory() { TerritoryID = "8", TerritoryDescription = "Hollis", RegionID = 4 };

            context.Categories.AddOrUpdate(defaultCategories);
            context.Regions.AddOrUpdate(defaultRegions);
            context.Territories.AddOrUpdate(defaultTerritories);
        }
    }
}
