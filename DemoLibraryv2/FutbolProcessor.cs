using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Newtonsoft.Json;

namespace DemoLibraryv2
{
    public static class FutbolProcessor
    {
        public static List<FutbolModel> futbolItems { get; set; }
        //public static FutbolResultModel futbolItemsInitial { get; set; }

        public static async Task<FutbolResultModel> LoadFutbolInformation()
        {
            Configuration config = new Configuration();
            string url = "https://soccer.sportmonks.com/api/v2.0/countries/320/teams?" + config.DefaultToken;

            //Using using you optimize the Api connection by opening and closing automatically
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    var futbolItemsInitial = await response.Content.ReadAsAsync<FutbolResultModel>();
                    //var a = JsonConvert.DeserializeObject<FutbolModel>(futbolItemsInitial);
                    futbolItems = await response.Content.ReadAsAsync<List<FutbolModel>>();

                    //futbolItems.AddRange(futbolItemsInitial);
                    return futbolItemsInitial;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }


    }

    public static class ExtensionMethods
    {
        public static void AddRange(this ObservableCollection<FutbolModel> value, List<FutbolModel> list)
        {
            foreach (var dup in list)
                value.Add(dup);
        }
    }
}