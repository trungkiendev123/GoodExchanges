using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;

namespace FUExchangeClient.Pages.Admin
{
    public class DashboardModel : PageModel
    {
        private readonly IOrderRepository _orderRepository;

        public DashboardModel(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public int DoneTransactionsCount { get; set; }
        public int CancelledTransactionsCount { get; set; }

        public void OnGet()
        {
            DoneTransactionsCount = _orderRepository.getTransactionByStatus(2);
            CancelledTransactionsCount = _orderRepository.getTransactionByStatus(3);
        }
    }
}
