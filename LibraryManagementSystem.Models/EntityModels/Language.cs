using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace LibraryManagementSystem.Models.EntityModels
{
   public class Language
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Book> Books { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
