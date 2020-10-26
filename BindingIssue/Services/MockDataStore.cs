﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BindingIssue.Models;

namespace BindingIssue.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>()
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "Item 1", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Item 2", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Item 3", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Item 4", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Item 5", Description="This is an item description." },
            };
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}