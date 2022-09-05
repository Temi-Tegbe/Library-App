using FluentDateTime;
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
    public class Books
    {
        [Key]
        [Required]
        public long BookId { get; set; }

      
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public bool IsBorrowed { get; set; }
        public string BorrowedBy { get; set; }
        //public long? BorrowerId { get; set; }
        //[Key, ForeignKey("Customer")]

        [ForeignKey(nameof(CustomerId))]
        public long? CustomerId { get; set; }

     
        public virtual Customer Customer { get; set; }
        public DateTime? BorrowDate { get; set; }
        public DateTime? ExpectedReturnDate { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateModified { get; set; }


    }
}
