using Microsoft.EntityFrameworkCore;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ReportDAO
    {
        private static ReportDAO instance = null;
        private static readonly object instanceLock = new object();

        private ReportDAO() { }

        public static ReportDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ReportDAO();
                    }
                    return instance;
                }
            }
        }

        public List<Report> GetAllReports()
        {
            List<Report> reports = null;
            try
            {
                using (var context = new FUExchangeGoodsContext()) // Replace with your DbContext
                {
                    reports = context.Reports.Include(x => x.Buyer).ThenInclude(y => y.User).Include(t => t.Seller).ThenInclude(k => k.User).ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error retrieving all reports.", e);
            }
            return reports;
        }
    }
}
