﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Models.Models;
using Service;

namespace FUExchangeClient.Pages.Buyer
{
    public class ShowOrderModel : PageModel
    {
        private readonly IOrderService _orderService; 

        public ShowOrderModel(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public List<Order> Orders { get; set; }

        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetInt32("user_id") == null)
            {
                return RedirectToPage("/Login");
            }

            if (HttpContext.Session.GetInt32("role") != 0)
            {
                return RedirectToPage("/AccessDenied");
            }
            int buyerId = HttpContext.Session.GetInt32("user_id").Value; 
            Orders = _orderService.GetOrdersByUserId(buyerId);
            return Page();
        }

    }
}
