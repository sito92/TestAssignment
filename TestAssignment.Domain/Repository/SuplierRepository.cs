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
    public class SuplierRepository:GenericRepository<Suplier,DataBaseContext>,ISuplierRepository
    {
        public Suplier GetSuplier(int suplierId)
        {
            return FindBy(x => x.Id == suplierId).FirstOrDefault();
        }
    }
}
