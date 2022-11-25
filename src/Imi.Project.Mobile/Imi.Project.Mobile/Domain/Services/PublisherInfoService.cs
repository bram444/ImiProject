﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Imi.Project.Mobile.Domain.Models;

namespace Imi.Project.Mobile.Domain.Services
{
    public class PublisherInfoService
    {
        private static List<PublisherInfo> inMemoryPublisher = new List<PublisherInfo>
        {
            new PublisherInfo
            {
                Id= Guid.Parse("00000000-0000-0000-0000-000000000001"),
                 Country="Japan",
                  Name="Nintendo"
            }

        };
        public async Task<List<PublisherInfo>> GetAllPublisher()
        {
            return await Task.FromResult(inMemoryPublisher);
        }

        public async Task<PublisherInfo> PublisherById(Guid id)
        {
            return await Task.FromResult(inMemoryPublisher.Where(publisher => publisher.Id == id).First());
        }

        public void SavePublisher(PublisherInfo publisherInfo)
        {
            var publisherInfoEdit = PublisherById(publisherInfo.Id);
            publisherInfoEdit.Result.Name = publisherInfo.Name;
            publisherInfoEdit.Result.Country = publisherInfo.Country;
        }

        public void AddPublisher(PublisherInfo publisherInfo)
        {
            inMemoryPublisher.Add(publisherInfo);
        }

        public void RemovePublisher(Guid id)
        {
            inMemoryPublisher.Remove(PublisherById(id).Result);
        }
    }
}
