using System;
using System.Collections.Generic;
using System.Text;
using LibraryManagementSystem.BLL.Contract;
using LibraryManagementSystem.Models.EntityModels;
using LibraryManagementSystem.Repositories.Contract;

namespace LibraryManagementSystem.BLL.Manager
{
   public class IssueManager:Manager<Issue>,IIssueManager
    {
        public IssueManager( IIssueRepository repository):base (repository)
        {
            
        }
    }
}
