using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Models.EntityModels
{
    public class Author
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Organization { get; set; }

        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public string Country { get; set; }
        public DateTime Birthdate { get; set; }
        public string Remarks { get; set; }


        public virtual List<Book> Books { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
