using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IAccountService
    {
        Account getByNameAndPass(string username, string password);
        Account getByName(string username);

        Account Get(int id);

        public void Add(Account account,User user);

        public Account GetByID(int id);


        public void Update(Account account);

        List<Account> ListAdmin();

        public Buyer GetBuyerByUserID(int id);
    }
}
