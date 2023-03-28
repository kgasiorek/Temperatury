using Domain.SettingsEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataModels.SettingsModels
{
    public class RoomDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? UrlToScreenshot { get; set; }
        public virtual ICollection<SensorsWithMeasurmentDataListView> Sensors { get; set; }
    }
}
