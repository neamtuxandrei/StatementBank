using StatementBank.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatementBank.DataAccess
{
    public interface IAccountRepository
    {
        List<Account> GetAccounts();
    }
}
