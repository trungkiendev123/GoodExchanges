using Microsoft.EntityFrameworkCore;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance = null;
        private static readonly object instanceLock = new object();
        private AccountDAO() { }
        public static AccountDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new AccountDAO();
                    }
                    return instance;
                }

            }
        }
        public List<Account> GetAllAccounts()
        {
            List<Account> accounts = null;
            try
            {
                using (var context = new FUExchangeGoodsContext())
                {
                    accounts = context.Accounts.OrderByDescending(X => X.AccountId).ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error retrieving all accounts.", e);
            }
            return accounts;
        }

        public List<Account> GetActiveAccounts()
        {
            List<Account> accounts = null;
            try
            {
                using (var context = new FUExchangeGoodsContext())
                {
                    accounts = context.Accounts.Where(a => a.Status == 1).ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error retrieving active accounts.", e);
            }
            return accounts;
        }

        public List<Account> GetBannedAccounts()
        {
            List<Account> accounts = null;
            try
            {
                using (var context = new FUExchangeGoodsContext())
                {
                    accounts = context.Accounts.Where(a => a.Status == 0).ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error retrieving banned accounts.", e);
            }
            return accounts;
        }

        public void EditAccount(Account account)
        {
            try
            {
                using (var context = new FUExchangeGoodsContext())
                {
                    var existingAccount = context.Accounts.Find(account.AccountId);
                    if (existingAccount != null)
                    {
                        existingAccount.Username = account.Username;
                        existingAccount.Password = account.Password;
                        existingAccount.Email = account.Email;
                        existingAccount.Status = account.Status;
                        existingAccount.Role = account.Role;

                        context.SaveChanges();
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error editing account.", e);
            }
        }

        public void BanAccount(int accountId)
        {
            try
            {
                using (var context = new FUExchangeGoodsContext())
                {
                    var account = context.Accounts.Find(accountId);
                    if (account != null)
                    {
                        account.Status = 0; // 0 represents banned status
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error banning account.", e);
            }
        }
        public void ActiveAccount(int accountId)
        {
            try
            {
                using (var context = new FUExchangeGoodsContext())
                {
                    var account = context.Accounts.Find(accountId);
                    if (account != null)
                    {
                        account.Status = 1;
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error banning account.", e);
            }
        }



        public Account GetByNameAndPassword(string username, string password)
        {
            Account account = null;
            try
            {
                using (var MySale = new FUExchangeGoodsContext())
                {
                    account = MySale.Accounts.SingleOrDefault(x => x.Username.Equals(username) && x.Password.Equals(password) && x.Status == 1);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return account;
        }
        public Account GetByName(string username)
        {
            Account account = null;
            try
            {
                using (var MySale = new FUExchangeGoodsContext())
                {
                    account = MySale.Accounts.SingleOrDefault(x => x.Username.Equals(username));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return account;
        }
        public Account GetByID(int id)
        {
            Account account = null;
            try
            {
                using (var MySale = new FUExchangeGoodsContext())
                {
                    account = MySale.Accounts.Include(x => x.User).SingleOrDefault(x => x.AccountId == id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return account;
        }
        public void Update(Account account)
        {
            try
            {
                using (var context = new FUExchangeGoodsContext())
                {
                    var existingAccount = context.Accounts.Include(x => x.User).FirstOrDefault(x => x.AccountId == account.AccountId);
                    if (existingAccount != null)

                    {
                        existingAccount.Username = account.Username;
                        existingAccount.Password = account.Password;
                        existingAccount.Email = account.Email;
                        existingAccount.Role = account.Role;

                        // Update related User details
                        existingAccount.User.FirstName = account.User.FirstName;
                        existingAccount.User.LastName = account.User.LastName;
                        existingAccount.User.Address = account.User.Address;

                        context.SaveChanges();
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error updating account.", e);
            }
        }
        public Account Get(int id)
        {
            Account account = null;
            try
            {
                using (var MySale = new FUExchangeGoodsContext())
                {
                    account = MySale.Accounts.SingleOrDefault(x => x.AccountId == id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return account;
        }
        
        public User GetUser(int id)
        {
            User account = null;
            try
            {
                using (var MySale = new FUExchangeGoodsContext())
                {
                    account = MySale.Users.SingleOrDefault(x => x.UserId == id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return account;
        }
        public Buyer GetBuyerByUserID(int id)
        {
            Buyer buyer = null;
            try
            {
                using (var MySale = new FUExchangeGoodsContext())
                {
                    buyer = MySale.Buyers.SingleOrDefault(x => x.UserId == id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return buyer;
        }
        public Seller GetSellerByUserID(int id)
        {
            Seller seller = null;
            try
            {
                using (var MySale = new FUExchangeGoodsContext())
                {
                    seller = MySale.Sellers.SingleOrDefault(x => x.UserId == id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return seller;
        }

        public List<User> ListSeller()
        {
            List<User> accounts;
            try
            {

                using (var MySale = new FUExchangeGoodsContext())
                {
                    accounts = MySale.Users.Include(x => x.Account).Where(x => x.Account.Role == 1).ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return accounts;

        }
        public List<User> ListBuyer()
        {
            List<User> accounts;
            try
            {

                using (var MySale = new FUExchangeGoodsContext())
                {
                    accounts = MySale.Users.Include(x => x.Account).Where(x => x.Account.Role == 0).ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return accounts;

        }
        public List<Account> ListAdmin()
        {
            List<Account> accounts;
            try
            {

                using (var MySale = new FUExchangeGoodsContext())
                {
                    accounts = MySale.Accounts.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return accounts;

        }
        public void Add(Account account, User user)
        {
            try
            {
                Account c = Get(account.AccountId);
                if (c == null)
                {
                    using (var MySale = new FUExchangeGoodsContext())
                    {
                        MySale.Accounts.Add(account);
                        MySale.SaveChanges();
                        user.AccountId = account.AccountId;
                        MySale.Users.Add(user);
                        MySale.SaveChanges();
                        if(account.Role == 0)
                        {
                            Buyer buyer = new Buyer();
                            buyer.UserId = user.UserId;
                            MySale.Buyers.Add(buyer);
                        }
                        if (account.Role == 1)
                        {
                            Seller seller = new Seller();
                            seller.UserId = user.UserId;
                            MySale.Sellers.Add(seller);

                        }
                        MySale.SaveChanges();
                    }

                }
                else
                {
                    throw new Exception("The account is already exist");
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        

    }
}
