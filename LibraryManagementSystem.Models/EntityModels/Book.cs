using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace LibraryManagementSystem.Models.EntityModels
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Publication { get; set; }

        public int? BookCategoryId { get; set; }
        public virtual BookCategory BookCategory { get; set; }
    }
}
