using System;
using System.Collections.Generic;
using System.Text;
using LibraryManagementSystem.Models.EntityModels;
using LibraryManagementSystem.Repositories.Contract;

namespace LibraryManagementSystem.Repositories.Repository
{
    public class PublisherRepository:Repository<Publisher>,IPublisherRepository
    {
    }
}
