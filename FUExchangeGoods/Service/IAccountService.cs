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
        public void Update(Account account);
        List<Account> GetAllAccounts();
        List<Account> GetActiveAccounts();
        List<Account> GetBannedAccounts();
        void EditAccount(Account account);
        void BanAccount(int accountId);
        void ActiveAccount(int accountId);
        Account getByNameAndPass(string username, string password);
        Account getByName(string username);

        Account Get(int id);

        public void Add(Account account,User user);

        public Account GetByID(int id);


        List<Account> ListAdmin();
        public List<User> ListBuyer();

        public Buyer GetBuyerByUserID(int id);
        public Seller GetSellerByUserID(int id);

        public List<User> ListSeller();
        public User GetUser(int id);
    }
}
