using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparker.Web.Models
{
    public class Region
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Msp> Msps{ get; set; }
    }
}
