using SE.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebExpress.Core;

namespace SE.BussinessLogic
{
    public class AccountBussinessLogic : BussinessLogicBase<Account>
    {
        public AccountBussinessLogic(EfRepository<Account> accountRepository)
            : base(accountRepository)
        {

        }

        public Account GetAccountByLoginName(string loginName)
        {
            try
            {
                var entity = PrimaryRepository.Table.FirstOrDefault(p => p.LoginName == loginName);
                return entity;
            }
            catch (Exception)
            {
                return null;
            }
        }


    }
}
