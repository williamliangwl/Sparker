using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparker.Data.Models
{
    public class EventDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateTime { get; set; }
        public int EventId { get; set; }
        public int UniversityId { get; set; }

        public virtual Event Event { get; set; }
        public virtual University University{ get; set; }
        public virtual ICollection<Attendee> Attendees { get; set; }
    }
}
