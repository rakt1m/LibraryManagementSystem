using System;
using System.Collections.Generic;
using System.Text;
using LibraryManagementSystem.BLL.Contract;
using LibraryManagementSystem.Models.EntityModels;
using LibraryManagementSystem.Repositories.Contract;

namespace LibraryManagementSystem.BLL.Manager
{
    public class LanguageManager:Manager<Language>,ILanguageManager
    {
        public LanguageManager(ILanguageRepository repository):base(repository)
        {
            
        }
    }
}
