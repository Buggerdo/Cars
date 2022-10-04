using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Cars.Models;

namespace Cars.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsAndManufacturesController : ControllerBase
    {
        CarsAndManufacturesContext _Db = new CarsAndManufacturesContext();


        [HttpPost("addManufacture")]
        public Manufacture AddManufacture(string company, string country)
        {
            Manufacture _ = new()
            {
                Company = company,
                Country = country
            };
            _Db.Manufactures.Add(_);
            _Db.SaveChanges();
            return _;
        }

        [HttpGet("id")]
        public Manufacture GetManufactureById(int id)
        {
            return _Db.Manufactures.FirstOrDefault(Manufacture => Manufacture.Id == id);
        }






        
        [HttpPost("addCar")]
        public Car AddCar(string model, string vin, string horsepower, string type, int makeId)
        {
            Car _ = new()
            {
                Model = model,
                Vin = vin,
                Horsepower = horsepower,
                Type = type,
                MakeId = makeId
            };
            _Db.Cars.Add(_);
            _Db.SaveChanges();
            return _;
        }

        [HttpGet("id")]
        public Car GetCarById(int id)
        {
            return _Db.Cars.FirstOrDefault(Car => Car.Id == id);
        }

    }
}
