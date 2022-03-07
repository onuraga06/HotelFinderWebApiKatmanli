using HotelFinderBusiness.Abstract;
using HotelFinderDataAccess.Abstract;
using HotelFinderEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinderBusiness.Concrete
{
    public class HotelService : IHotelService
    {
        private IHotelRepository rep;
        public HotelService(IHotelRepository _rep)
        {
            rep = _rep;
        }
        public Hotel Add(Hotel entites)
        {
            return rep.Add(entites);
        }

        public void Delete(int id)
        {
            rep.Delete(id);
        }

        public Hotel GetByID(int id)
        {
            if (id > 0)
            {
               return rep.GetByID(id);
            }
            throw new Exception("ID 1'DEN KUCUK OLAMAZ");
        }

        public List<Hotel> GetList()
        {
            return rep.GetList();

        }

        public Hotel Update(Hotel entites)
        {
            return rep.Update(entites);
        }
    }
}
