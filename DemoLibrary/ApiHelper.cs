using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace DemoLibrary
{
    public static class ApiHelper
    {
        /// <summary>
        /// Para incializar cliente
        /// </summary>
        public static HttpClient ApiClient { get; set; }
        public static void IntializeClient()
        {
            ApiClient = new HttpClient();
            //ApiClient.BaseAddress = new Uri("direccion de la API");
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

    }
}
