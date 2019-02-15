using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Models.EntityModels
{
    public class Return
    {
        public int Id { get; set; }

        public int? MemberId { get; set; }
        public virtual Member Member { get; set; }

        public string FineAmount { get; set; }

        public string Remarks { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
