using Sparker.Data.Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparker.Process.Abstracts
{
    public abstract class Repository<TModel, TKey> where TModel : class where TKey : IConvertible
    {
        protected AttendanceContext context = new AttendanceContext();

        public abstract IEnumerable<TModel> Get();
        public abstract TModel Get(TKey id);
        public abstract int Create(TModel entity);
        public abstract int Update(TKey id, TModel entity);
        public abstract int Delete(TKey id);
    }
}
