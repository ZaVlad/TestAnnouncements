using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAnnouncements.Models.ViewModels
{
    public class AnnouncementViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
