using DataLayer.Interfaces;
using DataLayer.Models;
using DataLayer.Requests;
using DataLayer.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataLayer.Repositories
{
    public class KittensRepository : IKittensRepository
    {
        public KittenModel GetKittenById(int id)
        {
            throw new NotImplementedException();
        }

        public GetKittensResponse GetKittens()
        {
            throw new NotImplementedException();
        }

        public bool SaveKitten(SaveKittenRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
