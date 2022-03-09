using System;
using System.Collections.Generic;

namespace LibraryManagement.Models
{
    public partial class Book
    {
        public Book()
        {
            Borrowings = new HashSet<Borrowing>();
        }

        public string Id { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string CategoryId { get; set; } = null!;

        public virtual Category Category { get; set; } = null!;
        public virtual ICollection<Borrowing> Borrowings { get; set; }
    }
}
