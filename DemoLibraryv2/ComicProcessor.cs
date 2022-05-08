using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibraryv2
{
    /// <summary>
    /// Receives the API by the Url, your job is to collect the Json get by this Url
    /// </summary>
    public class ComicProcessor
    {
        public static int MaxComicNumber { get; set; }

        public static async Task<ComicModel> LoadComic(int comicNumber = 0)
        {
            string url = "";

            if (comicNumber > 0)
            {
                url = $"https://xkcd.com/{ comicNumber }/info.0.json";
            }
            else
            {
                url = "https://xkcd.com/1/info.0.json";
            }


            //Using using you optimize the Api connection by opening and closing automatically
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    ComicModel comic = await response.Content.ReadAsAsync<ComicModel>();

                    if (comicNumber == 0)
                    {
                        MaxComicNumber = comic.Num;
                    }


                    return comic;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }

        }
    }
}
