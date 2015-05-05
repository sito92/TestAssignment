using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAssignment.Domain.Models.DomainModels;

namespace TestAssignment.Domain.Repository.Interfaces
{
    public interface IUserRepository:IRepository<User>
    {
        User GetUser(int userId);
    }
}
