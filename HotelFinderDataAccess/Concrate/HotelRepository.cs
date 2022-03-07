using HotelFinderDataAccess.Abstract;
using HotelFinderEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinderDataAccess.Concrate
{
    public class HotelRepository : IHotelRepository
    {

        public Hotel Add(Hotel entites)
        {
            using (var db = new HotelDbContext())
            {
                db.Hotels.Add(entites);
                db.SaveChanges();
                return entites;
            }
        }
        public void Delete(int id)
        {
            using (var db = new HotelDbContext())
            {
                var x = GetByID(id);
                db.Hotels.Remove(x);
                db.SaveChanges();
            }
        }
        public Hotel GetByID(int id)
        {
            using (var db = new HotelDbContext())
            {
                return db.Hotels.FirstOrDefault(x => x.Id == id);
            }
        }
        public List<Hotel> GetList()
        {
            using (var db = new HotelDbContext())
            {
                return db.Hotels.ToList();

            }

        }
        public Hotel Update(Hotel entites)
        {
            using (var db = new HotelDbContext())
            {
                db.Hotels.Update(entites);
                db.SaveChanges();
                return entites;
            }
        }
    }
}
