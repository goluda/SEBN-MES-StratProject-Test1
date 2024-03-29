using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using API;

namespace MaterialyWeb.Pages
{
    public partial class Index
    {

        List<Material> materials;
        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
            if (firstRender == true)
            {
                LoadMaterials();
            }
        }

        private async void LoadMaterials()
        {
            System.Console.WriteLine("Ładowanie materiałów");

            // var cl1 = new HttpClient();
            // var dane = await cl1.GetAsync("http://localhost:5000/api/Material");
            // var dane1 = await dane.Content.ReadAsStringAsync();
            // var mat = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Material>>(dane1);

            var client = new API.Client("http://localhost:5000", new System.Net.Http.HttpClient());
            materials = await client.ApiMaterialGetAsync();
            System.Console.WriteLine($"Pobrano {materials.Count()} materialow");

            StateHasChanged();
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            System.Console.WriteLine("Inicjalizujemy komponent");
        }
        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            System.Console.WriteLine("Nastąpiła zmiana parametrów");
        }


    }
}