using Sparker.Data.Access;
using Sparker.Data.Models;
using Sparker.Process.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparker.Process.Repositories
{
    public class MspRepository : Repository<Msp, int>
    {
        public override int Create(Msp entity)
        {
            if (entity != null)
            {
                context.Msps.Add(entity);
            }
            return context.SaveChanges();
        }

        public override int Delete(int id)
        {
            Msp msp = Get(id);
            if (msp != null)
            {
                context.Msps.Remove(msp);
            }
            return context.SaveChanges();
        }

        public override IEnumerable<Msp> Get()
        {
            context.Database.Connection.Open();
            return context.Msps;
        }

        public override Msp Get(int id)
        {
            return context.Msps.Find(id);
        }

        public override int Update(int id, Msp entity)
        {
            Msp msp = Get(id);
            if (msp != null && entity.Id == msp.Id)
            {
                context.Entry<Msp>(entity).State = System.Data.Entity.EntityState.Modified;
            }
            return context.SaveChanges();
        }
    }
}
