using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.SettingsEntities
{
    public class Room
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? UrlToScreenshot { get; set; }
        public virtual ICollection<SensorSettings> Sensors { get; set; }
    }
}
