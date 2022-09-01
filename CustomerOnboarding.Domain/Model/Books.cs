using FluentDateTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOnboarding.Domain.Model
{
    public class Books
    {
        
        public int BookId { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public bool IsBorrowed { get; set; }
        public string BorrowedBy { get; set; }
        public int BorrowerId { get; set; }
        public virtual Customer Customer { get; set; }
        public DateTime? BorrowDate { get; set; }
        public DateTime? ExpectedReturnDate { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateModified { get; set; }


    }
}
