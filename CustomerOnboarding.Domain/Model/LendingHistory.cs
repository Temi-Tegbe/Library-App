using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOnboarding.Domain.Model
{
    public class LendingHistory
    {
        public virtual Books Book { get; set; }
        public virtual Customer Customer { get; set; }
        public DateTime Date { get; set; }
        public bool Returned { get; set; }
    }
}
