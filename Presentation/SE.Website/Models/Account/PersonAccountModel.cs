using SE.BussinessLogic;
using SE.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace SE.Website.Models
{
    public class PersonAccountModel : ITranslatable<AdminPerson, PersonAccountModel>, ITranslatable<PersonAccountModel, AdminPerson>
    {
        public int PersonId { get; set; }
        public int AccountId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string LoginName { get; set; }

        [Required]
        public string Department { get; set; }

        [RequiredIf("AccountId",0)]
        [MinLength(6)]
        public string Password { get; set; }

        public PersonAccountModel Translate(AdminPerson from)
        {
            var to = new PersonAccountModel();
            to.PersonId = from.Id;
            to.AccountId = from.Account.Id;
            to.Name = from.Name;
            to.LoginName = from.Account.LoginName;
            to.Department = from.Department;
            return to;
        }

        public AdminPerson Translate(PersonAccountModel from)
        {
            var bll = DependencyResolver.Current.GetService<PersonBussinessLogic>();
            var to = from.PersonId > 0 ? bll.Get(from.PersonId) : new AdminPerson();

            to.Name = from.Name;
            to.Department = from.Department;
            if (to.Account == null)
            {
                to.Account = new Account();
                to.Account.LoginName = from.LoginName;
                to.Account.Password = from.Password;
                to.Account.AccountType = Common.Types.AccountType.AdminUser;
            }
            else
            {
                to.Account.LoginName = from.LoginName;
            }

            return to;
        }
    }
}