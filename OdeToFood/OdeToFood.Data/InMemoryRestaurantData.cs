﻿using System;
using System.Collections.Generic;
using System.Text;
using OdeToFood.Core;
using System.Linq;

namespace OdeToFood.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant {Id= 1, Name="Adonis", Location="Etobicoke", Cuisine = CuisineType.Italian},
                new Restaurant {Id= 2, Name="Karahi", Location="York", Cuisine = CuisineType.Mexican},
                new Restaurant {Id= 3, Name="Masrawy", Location="Mississauga", Cuisine = CuisineType.Indian}
            };
        }
        public IEnumerable<Restaurant> GetAll()
        {
            return from r in restaurants
                   orderby r.Name
                   select r;
        }

        public Restaurant GetRestaurantById(int Id)
        {
            return restaurants.SingleOrDefault(r => r.Id == Id);
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name=null)
        {
            return from r in restaurants
                   where String.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }
    }
}
