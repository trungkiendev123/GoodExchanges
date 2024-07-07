using DAO;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ReportRepository : IReportRepository
    {
        public List<Report> GetAllReports()
        {
            return ReportDAO.Instance.GetAllReports();
        }
        public void AddReport(Report report)
        {
            ReportDAO.Instance.AddReport(report);
        }
    }
}
