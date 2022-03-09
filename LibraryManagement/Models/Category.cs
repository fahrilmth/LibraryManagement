using System;
using System.Collections.Generic;

namespace LibraryManagement.Models
{
    public partial class Category
    {
        public Category()
        {
            Books = new HashSet<Book>();
        }

        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;

        public virtual ICollection<Book> Books { get; set; }
    }
}
