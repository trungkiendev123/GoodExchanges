using DAO;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ContactRepository : IContactRepository
    {
        public List<Contact> GetMessagesAsync(int userSend, int userReceive)
        {
            try
            {
                return  ContactDAO.Instance.GetMessagesAsync(userSend, userReceive);
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting messages.", ex);
            }
        }

        public void SendMessageAsync(Contact message)
        {
            try
            {
                 ContactDAO.Instance.SendMessageAsync(message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error sending message.", ex);
            }
        }
    }
}
