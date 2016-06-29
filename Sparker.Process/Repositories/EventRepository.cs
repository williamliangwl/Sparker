using Sparker.Data.Models;
using Sparker.Process.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparker.Process.Repositories
{
    public class EventRepository : Repository<Event, int>
    {
        public override int Create(Event entity)
        {
            if (entity != null)
            {
                context.Events.Add(entity);
            }
            return context.SaveChanges();
        }

        public override int Delete(int id)
        {
            Event e = Get(id);
            if (e != null)
            {
                context.Events.Remove(e);
            }
            return context.SaveChanges();
        }

        public override IEnumerable<Event> Get()
        {
            return context.Events;
        }

        public override Event Get(int id)
        {
            return context.Events.Find(id);
        }

        public override int Update(int id, Event entity)
        {
            if (id == entity.Id)
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            }
            return context.SaveChanges();
        }

        public IEnumerable<Event> GetByRegion(int regionId)
        {
            return context.Events.Where(e => e.Msp.RegionId.Equals(regionId));
        }
    }
}
