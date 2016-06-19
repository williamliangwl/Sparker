using Sparker.Data.Models;
using Sparker.Process.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparker.Process.Repositories
{
    public class RegionRepository : Repository<Region, int>
    {
        public override int Create(Region entity)
        {
            throw new NotImplementedException();
        }

        public override int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Region> Get()
        {
            return context.Regions;
        }

        public override Region Get(int id)
        {
            throw new NotImplementedException();
        }

        public override int Update(int id, Region entity)
        {
            throw new NotImplementedException();
        }
    }
}
