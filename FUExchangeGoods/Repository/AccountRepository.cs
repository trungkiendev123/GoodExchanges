using DAO;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AccountRepository : IAccountRepository
    {
        public void Update(Account account) => AccountDAO.Instance.Update(account);
        public List<Account> GetAllAccounts()
        {
            return AccountDAO.Instance.GetAllAccounts();
        }

        public List<Account> GetActiveAccounts()
        {
            return AccountDAO.Instance.GetActiveAccounts();
        }

        public List<Account> GetBannedAccounts()
        {
            return AccountDAO.Instance.GetBannedAccounts();
        }

        public void EditAccount(Account account)
        {
            AccountDAO.Instance.EditAccount(account);
        }
        public void ActiveAccount(int accountId)
        {
            AccountDAO.Instance.ActiveAccount(accountId);
        }

        public void BanAccount(int accountId)
        {
            AccountDAO.Instance.BanAccount(accountId);
        }
        public Account getByNameAndPass(string username, string password) => AccountDAO.Instance.GetByNameAndPassword(username, password);

        public Account getByName(string username) => AccountDAO.Instance.GetByName(username);

        public Account GetByID(int id) => AccountDAO.Instance.GetByID(id);

        public Account Get(int id) => AccountDAO.Instance.Get(id);

        public List<Account> ListAdmin() => AccountDAO.Instance.ListAdmin();

        public void Add(Account account,User user) => AccountDAO.Instance.Add(account, user);


        public Buyer GetBuyerByUserID(int id) => AccountDAO.Instance.GetBuyerByUserID(id);

        public List<User> ListSeller() => AccountDAO.Instance.ListSeller();
        public User GetUser(int id) => AccountDAO.Instance.GetUser(id);
    }
}
