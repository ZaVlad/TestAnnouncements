using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UseCases.Models;

namespace TestAnnouncements.Models.ViewModels
{
    public class AnnouncementViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
    }

    public static partial class ViewModelMapperExtensions
    {
        public static AnnouncementViewModel AsViewModel(this AnnouncementDto dto)
        {
            return new AnnouncementViewModel()
            {
                Id = dto.Id,
                Description = dto.Description,
                Title = dto.Title,
                DateAdded = dto.DateAdded
            };
        }
    }
}
