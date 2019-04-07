using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiveTracker.Backend.Data
{
    public class TripsContext : DbContext
    {
        public TripsContext(DbContextOptions<TripsContext> options) : base(options)
        {
            if (Trips.Any()) return;
            Trips.AddRange(new List<Trip>
            {
                new Trip{
                    Name = "San Franis college",
                    StartDate = new DateTime(2019, 5, 4),
                    EndDate = new DateTime(2019, 5, 7)
                },
                new Trip{
                    Name = "Bithoor Live Meet",
                    StartDate = new DateTime(2019, 5, 14),
                    EndDate = new DateTime(2019, 5, 17)
                },
                new Trip{
                    Name = "Local Meetup",
                    StartDate = new DateTime(2019, 5, 24),
                    EndDate = new DateTime(2019, 5, 27)
                }
            });
            SaveChanges();
        }
        public DbSet<Trip> Trips {get;set;}
    }
}
