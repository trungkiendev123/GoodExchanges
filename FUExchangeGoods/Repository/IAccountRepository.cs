using DAO;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IAccountRepository
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

        Account GetByID(int id);

        Account Get(int id);

        void Add(Account account, User user);

        List<Account> ListAdmin();

        public Buyer GetBuyerByUserID(int id);
        public Seller GetSellerByUserID(int id);

        public List<User> ListSeller();
        public List<User> ListBuyer();
        public User GetUser(int id);
    }
}
