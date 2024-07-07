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
        Account getByNameAndPass(string username, string password);

        Account getByName(string username);

        Account GetByID(int id);

        Account Get(int id);

        void Add(Account account, User user);
        void Update(Account account);

        List<Account> ListAdmin();

        public Buyer GetBuyerByUserID(int id);

        public List<User> ListSeller();
        public User GetUser(int id);
    }
}
