using Sparker.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparker.Data.Access
{
    public class AttendanceContext : DbContext
    {
        public AttendanceContext() : base("AttendanceDb")
        {
            this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventDetail> EventDetails { get; set; }
        public DbSet<Msp> Msps { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<University> Universities { get; set; }
    }
}
