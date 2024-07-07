using Models.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class AccountService : IAccountService
    {
        private IAccountRepository _repository;
        public AccountService()
        {
            _repository = new AccountRepository();
        }
        public List<Account> GetAllAccounts()
        {
            return _repository.GetAllAccounts();
        }
        public void UpdateAccount(Account account) {
            _repository.Update(account);

        }

        public List<Account> GetActiveAccounts()
        {
            return _repository.GetActiveAccounts();
        }

        public List<Account> GetBannedAccounts()
        {
            return _repository.GetBannedAccounts();
        }

        public void EditAccount(Account account)
        {
            _repository.EditAccount(account);
        }
        public void ActiveAccount(int accountId)
        {
            _repository.ActiveAccount(accountId);
        }

        public void BanAccount(int accountId)
        {
            _repository.BanAccount(accountId);
        }
        public Account getByNameAndPass(string username, string password)
        {
            return _repository.getByNameAndPass(username, password);
        }
        public Account getByName(string username)
        {
            return _repository.getByName(username);
        }

        public Account Get(int id) => _repository.Get(id);


        public List<Account> ListAdmin() => _repository.ListAdmin();


        public void Add(Account account, User user) => _repository.Add(account,user);

        public void Update(Account account) => _repository.Update(account);

        public Account GetByID(int id)
        {
            return _repository.GetByID(id);
        }
        public Buyer GetBuyerByUserID(int id)
        {
            return _repository.GetBuyerByUserID(id);
        }
        public Seller GetSellerByUserID(int id)
        {
            return _repository.GetSellerByUserID(id);
        }
        public List<User> ListSeller()
        {
            return _repository.ListSeller();
        }
        public List<User> ListBuyer()
        {
            return _repository.ListBuyer();
        }
        public User GetUser(int id)
        {
            return _repository.GetUser(id);
        }
    }
}
