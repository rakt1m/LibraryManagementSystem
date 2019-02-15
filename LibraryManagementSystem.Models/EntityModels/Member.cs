using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Models.EntityModels
{
   public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Occupation { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string District { get; set; }
        public string Thana { get; set; }
        public string Zip { get; set; }
        public string Sex { get; set; }
        public string BloodGroup { get; set; }
        public string Religon { get; set; }
        public string NID { get; set; }
        public DateTime BirthDate { get; set; }

        public  string Remarks { get; set; }


        public virtual List<Issue> Issues { get; set; }
        public virtual List<Return> Returns { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
