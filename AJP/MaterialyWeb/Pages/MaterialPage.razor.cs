using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using API;

namespace MaterialyWeb.Pages
{
    public partial class MaterialPage
    {

        CompleteMaterial material;
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



            var client = new API.Client("http://localhost:5000", new System.Net.Http.HttpClient());
            material = await client.ApiMaterialyoldGetAsync(this.MaterialNo);

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