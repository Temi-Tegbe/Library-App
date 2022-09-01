using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOnboarding.Domain.Model.DTO
{
    public class BorrowBookDTO
    {
        public string BorrowedBy { get; set; }
        public int BorrowerId { get; set; }
    }
}
