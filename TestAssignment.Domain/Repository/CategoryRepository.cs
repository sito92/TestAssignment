using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAssignment.Domain.Context;
using TestAssignment.Domain.Models.DomainModels;
using TestAssignment.Domain.Repository.Interfaces;

namespace TestAssignment.Domain.Repository
{
    public class CategoryRepository:GenericRepository<Category,DataBaseContext>,ICategoryRepository
    {

        public Category GetCategory(int categoryId)
        {
            return FindBy(x => x.Id == categoryId).FirstOrDefault();
        }
    }
}
