using HotelFinderEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinderDataAccess.Abstract
{
   public interface IHotelRepository
    {
        List<Hotel> GetList();
        Hotel GetByID(int id);
        Hotel Add(Hotel entites);
        Hotel Update(Hotel entites);
        void Delete(int id);


    }
}
