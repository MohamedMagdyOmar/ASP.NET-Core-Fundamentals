﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private IRestaurantData restaurantData;
        public Restaurant restaurant;
        public EditModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }
        public IActionResult OnGet(int restaurantId)
        {
            restaurant = restaurantData.GetRestaurantById(restaurantId);
            if(restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();

        }
    }
}