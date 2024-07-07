﻿using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IContactService
    {
        public List<Contact> GetMessages(int userSend, int userReceive);
        public void SendMessage(Contact message);
    }
}
