using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOnboarding.Domain.Model
{
    public class LendingHistory
    {
        [Key]
        [Required]
        public long LendingHistoryId { get; set; }
        public  long? BookId { get; set; }
        //[JsonIgnore]
        public virtual Books Book { get; set; }
        public long? CustomerId { get; set; }
        //[JsonIgnore]
        public virtual Customer Customer { get; set; }
        public DateTime Date { get; set; }
        public bool Returned { get; set; }
    }
}
