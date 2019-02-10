using System;
using System.Collections.Generic;
using System.Text;
using LibraryManagementSystem.BLL.Contract;
using LibraryManagementSystem.Models.EntityModels;
using LibraryManagementSystem.Repositories.Contract;
using LibraryManagementSystem.Repositories.Repository;

namespace LibraryManagementSystem.BLL.Manager
{
   public class BookCategoryManager:Manager<BookCategory>,IBookCategoryManager
    {
        public BookCategoryManager(BookCategoryRepository repository) : base(repository)
        {
            
        }
    }
}
