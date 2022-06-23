using FriendOrganizer.Model;
using System.Data.Entity.Migrations;

namespace FriendOrganizer.DataAccess.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<FriendOrganizer.DataAccess.FriendOrganizerDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FriendOrganizer.DataAccess.FriendOrganizerDbContext context)
        {
            context.Friends.AddOrUpdate(
                f => f.FirstName,
                new Friend { FirstName = "Daniel", LastName = "Doe" },
                new Friend { FirstName = "Jane", LastName = "Doe" },
                new Friend { FirstName = "Richard", LastName = "Winters" },
                new Friend { FirstName = "John", LastName = "Price" }
            );
        }
    }
}
