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
    public class UserRepository : GenericRepository<User, DataBaseContext>, IUserRepository
    {
        public User GetUser(int userId)
        {
            return FindBy(x => x.Id == userId).FirstOrDefault();
        }
    }
}
