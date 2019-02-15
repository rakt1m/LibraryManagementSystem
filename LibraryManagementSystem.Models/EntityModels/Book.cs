using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace LibraryManagementSystem.Models.EntityModels
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Subject { get; set; }
        public string Edition { get; set; }

       
        public string Description { get; set; }
        public string Isbn { get; set; }
        
        public string Editor { get; set; }
        public string Price { get; set; }
        public int? LanguageId { get; set; }
        public virtual Language Language { get; set; }

        public int? AuthorId { get; set; }
        public virtual Author Author { get; set; }


        public int? PublisherId { get; set; }
        public virtual Publisher Publisher { get; set; }

        public int? BookCategoryId { get; set; }
        public virtual BookCategory BookCategory { get; set; }

        public string Remarks { get; set; }

        public virtual List<Issue> Issues { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
