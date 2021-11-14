using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UseCases.Models;

namespace TestAnnouncements.Models.ViewModels
{
    public class AnnouncementDetailViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public IList<string> SameAnnouncements { get; set; }
    }
    public static partial class ViewModelMapperExtensions
    {
        public static AnnouncementDetailViewModel AsViewModel(this AnnouncementDetailDto dto)
        {
            return new AnnouncementDetailViewModel()
            {
                Id = dto.Id,
                DateAdded = dto.DateAdded,
                Description = dto.Description,
                Title = dto.Title,
                SameAnnouncements = dto.SameAnnouncements
            };
        }
    }
}
