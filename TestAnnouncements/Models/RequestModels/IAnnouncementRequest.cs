﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAnnouncements.Models.RequestModels
{
    interface IAnnouncementRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
