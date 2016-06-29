using Sparker.Data.Models;
using Sparker.Process.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparker.Process.Repositories
{
    public class EventDetailRepository : Repository<EventDetail, int>
    {
        public override int Create(EventDetail entity)
        {
            if (entity != null)
            {
                context.EventDetails.Add(entity);
            }
            return context.SaveChanges();
        }

        public override int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<EventDetail> Get()
        {
            throw new NotImplementedException();
        }

        public override EventDetail Get(int id)
        {
            throw new NotImplementedException();
        }

        public override int Update(int id, EventDetail entity)
        {
            throw new NotImplementedException();
        }
    }
}
