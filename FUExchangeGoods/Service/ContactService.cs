using DAO;
using Models.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService()
        {
            _contactRepository = new ContactRepository();
        }

        public List<Contact> GetMessages(int userSend, int userReceive)
        {
            try
            {
                return  _contactRepository.GetMessagesAsync(userSend, userReceive);
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting messages.", ex);
            }
        }

        public void SendMessage(Contact message)
        {
            try
            {
                 _contactRepository.SendMessageAsync(message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error sending message.", ex);
            }
        }
    }
}
