using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Models.EntityModels
{
   public class Issue
    {
        public int Id { get; set; }
      
        public int? MemberId { get; set; }
        public virtual Member Member { get; set; }

        public int?  BookId { get; set; }
        public virtual Book Book { get; set; }

        public DateTime IssueDate { get; set; }
        public DateTime ReturnDate { get; set; }


        public string Remarks { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
