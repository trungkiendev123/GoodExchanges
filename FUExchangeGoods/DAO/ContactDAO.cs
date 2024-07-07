using Microsoft.EntityFrameworkCore;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ContactDAO
    {
        private static ContactDAO instance = null;
        private static readonly object instanceLock = new object();

        private ContactDAO() { }

        public static ContactDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ContactDAO();
                    }
                    return instance;
                }
            }
        }

        public List<Contact> GetMessagesAsync(int userSend, int userReceive)
        {
            List<Contact> contacts = null;
            try
            {
                using (var context = new FUExchangeGoodsContext())
                {
                    contacts =  context.Contacts
                        .Where(c => (c.UserSend == userSend && c.UserReceive == userReceive) || (c.UserSend == userReceive && c.UserReceive == userSend))
                        .OrderBy(c => c.Id)
                        .ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error retrieving messages.", e);
            }
            return contacts;
        }

        public void SendMessageAsync(Contact message)
        {
            try
            {
                using (var context = new FUExchangeGoodsContext())
                {
                    context.Contacts.Add(message);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error sending message.", e);
            }
        }
    }
}
