using Backend.Core.Modell.Entities;
using Backend.Core.Modell.Request;
using Flurl.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.API.Controllers
{
    public partial class BeerController
    {
        private static Beer GetBeerById(int Id)
        {
            return _data.Find(x => x.Id == Id);
        }

        private static void DeletBeer(int id)
        {
            Beer beer = _data.Find(x => x.Id == id);
            int index = _data.IndexOf(beer);
            _data.RemoveAt(index);
        }

        private static Beer AddBeer(BeerRequest beer)
        {
            long id = _data.Last().Id + 1;

            Beer newData = new Beer(beer, id);
            _data.Add(newData);

            return newData;
        }

        private static Beer UpdateBeer(Beer beer)
        {
            Beer toUpdate = _data.Find(x => x.Id == beer.Id);
            int index = _data.IndexOf(toUpdate);
            _data.RemoveAt(index);
            _data.Insert(index, beer);

            return beer;
        }

        private static async Task<List<Beer>> FetchData()
        {
            string url = "https://api.punkapi.com/v2/beers";

            List<Beer> beers = await url.GetJsonAsync<List<Beer>>();

            return beers;
        }
        
        private static List<Beer> FetchData(string filePath)
        {
            StreamReader r = new StreamReader(filePath);
            string jsonString = r.ReadToEnd();
            List<Beer> beers = JsonConvert.DeserializeObject<List<Beer>>(jsonString);

            return beers;
        }
    }
}
