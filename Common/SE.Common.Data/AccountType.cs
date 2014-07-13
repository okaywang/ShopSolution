using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE.Common.Types
{
    public enum AccountType
    {
        AdminUser = 1,
        Shop = 2,
    }

    [Flags]
    public enum AuthorityType
    {
        [CandidateAccounts(AccountType.AdminUser)]
        Administration = 1,

        [CandidateAccounts(AccountType.Shop)]
        Bussiness = 2,

        [CandidateAccounts(AccountType.AdminUser, AccountType.Shop)]
        AdministrationAndBussiness = Administration | Bussiness
    }

    public class CandidateAccountsAttribute : Attribute
    {
        public CandidateAccountsAttribute(params AccountType[] types)
        {
            AccountTypes = types;
        }

        public AccountType[] AccountTypes { get; private set; }
    }
}
