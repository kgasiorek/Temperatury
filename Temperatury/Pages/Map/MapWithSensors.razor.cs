using Application.DataModels.SettingsModels;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor;

namespace Temperatury.Pages.Map
{
    public partial class MapWithSensors
    {
        #region ElementReference
        private ElementReference Pom1;
        private ElementReference Pom2;
        private ElementReference Pom3;
        private ElementReference Pom4;
        private ElementReference Pom5;
        private ElementReference Pom6;
        private ElementReference Pom7;
        private ElementReference Pom8;
        private ElementReference Pom9;
        private ElementReference Pom10;
        private ElementReference Pom11;
        private ElementReference Pom12;
        private ElementReference Pom13;
        private ElementReference Pom14;
        private ElementReference Pom15;
        private ElementReference Pom16;
        private ElementReference Pom17;
        private ElementReference Pom18;
        private ElementReference Pom19;
        private ElementReference Pom20;
        private ElementReference Pom21;
        private ElementReference Pom22;
        private ElementReference Pom23;
        private ElementReference Pom2425;
        private ElementReference Pom2627;
        private ElementReference Pom2829;
        private ElementReference Pom30;
        private ElementReference Pom31;
        private ElementReference Pom32;
        private ElementReference Pom33;
        private ElementReference Pom34;
        private ElementReference Pom35;
        #endregion

        [CascadingParameter] public List<SensorsWithMeasurmentDataListView> Sensors { get; set; }

        [JSInvokable]
        public static async Task OnRoomSelected(string roomId)
        {
            Console.WriteLine($"Kliknięto Pomieszczenie: {roomId}");
            // Tutaj możesz zaktualizować interfejs użytkownika lub przekazać informacje do serwera
        }

        private void PokazInformacje(int idPomieszczenia)
        {
            Console.WriteLine($"Kliknięto Pomieszczenie: {idPomieszczenia}");
            // Możesz tu dodać logikę obsługi zdarzeń, np. wyświetlanie informacji o Pomieszczeniu w okienku modalnym.
        }
        private string AlarmColor(string pomOriginalName)
        {
            var SensorData = Sensors.FirstOrDefault(x => x.OriginalName.Equals(pomOriginalName));
            if (SensorData.Measurments[0].Temperature > SensorData.MinTemp && SensorData.Measurments[0].Temperature < SensorData.MaxTemp)
            {
                return "fill:green;stroke-width:8.79486;stroke-dashoffset:36.2835;opacity:0.6;cursor:pointer;";
            }
            if (SensorData.Measurments[0].Temperature < SensorData.MinTemp)
            {
                return "fill:blue;stroke-width:8.79486;stroke-dashoffset:36.2835;opacity:0.6;cursor:pointer;";
            }
            return "fill:red;stroke-width:8.79486;stroke-dashoffset:36.2835;opacity:0.6;cursor:pointer;";
        }

        private async Task OnMouseEnter(ElementReference element)
        {
            await JSRuntime.InvokeVoidAsync("svg.setStyle", element, "red", "15px");
        }

        private async Task OnMouseLeave(ElementReference element)
        {
            await JSRuntime.InvokeVoidAsync("svg.setStyle", element, "white", "0px");
        }
    }
}
