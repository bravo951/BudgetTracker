using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface IExpenditureRepository : IAsyncRepository<Expenditure>
    {
        //Task<User> GetIncomeForUser(int id);
    }
}
