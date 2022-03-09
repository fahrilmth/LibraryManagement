using System;
using System.Collections.Generic;

namespace LibraryManagement.Models
{
    public partial class Borrowing
    {
        public string Id { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public string BookId { get; set; } = null!;
        public DateTime Date { get; set; }

        public virtual Book Book { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
