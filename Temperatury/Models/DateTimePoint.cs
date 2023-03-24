using ChartJs.Blazor.Common;

namespace Temperatury.Models
{
    public class DateTimePoint
    {
        private DateTime time;
        private double temperature;

        public DateTimePoint(DateTime time, double temperature)
        {
            this.time = time;
            this.temperature = temperature;
        }

        public DateTime Czas { get; set; }
        public double Temperatura { get; set; }
    }
}
