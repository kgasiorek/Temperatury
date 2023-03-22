using Domain.SettingsEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataModels.SettingsModels
{
    public class TypeOfSensorDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public virtual ICollection<SensorsWithLastSixteenDataListView> Sensors { get; set; }
    }
}
