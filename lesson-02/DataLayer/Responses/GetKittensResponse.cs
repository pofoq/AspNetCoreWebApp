using System.Collections.Generic;


namespace DataLayer.Responses
{
    public class GetKittensResponse
    {
        public IEnumerable<Models.KittenModel> Kittens;
    }
}
