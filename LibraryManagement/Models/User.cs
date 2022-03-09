using System;
using System.Collections.Generic;

namespace LibraryManagement.Models
{
    public partial class User
    {
        public User()
        {
            Borrowings = new HashSet<Borrowing>();
        }

        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Class { get; set; } = null!;
        public int Nis { get; set; }
        public string Departement { get; set; } = null!;

        public virtual ICollection<Borrowing> Borrowings { get; set; }
    }
}
