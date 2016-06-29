using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparker.Web.Models
{
    public class University
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<EventDetail> EventDetails { get; set; }
    }
}
