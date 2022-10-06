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
            Manufacture m = new()
            {
                Company = company,
                Country = country
            };
            _Db.Manufactures.Add(m);
            _Db.SaveChanges();
            return m;
        }

        [HttpPost("addCar")]
        public Car AddCar(string model, string vin, string horsepower, string type, int makeId)
        {
            Car car = new()
            {
                Model = model,
                Vin = vin,
                Horsepower = horsepower,
                Type = type,
                MakeId = makeId
            };
            _Db.Cars.Add(car);
            _Db.SaveChanges();
            return car;
        }

        [HttpGet("getManufactures")]
        public IActionResult GetManufactures()
        {
            return Ok(_Db.Manufactures);
        }

        [HttpGet("getCars")]
        public IActionResult GetCars()
        {
            return Ok(_Db.Cars);
        }

        [HttpGet("manufactureId")]
        public Manufacture GetManufactureById(int id)
        {
            return _Db.Manufactures.FirstOrDefault(Manufacture => Manufacture.Id == id);
        }

        [HttpGet("manufactureCompany")]
        public Manufacture GetManufactureByCompany(string company)
        {
            return _Db.Manufactures.FirstOrDefault(Manufacture => Manufacture.Company.ToLower() == company.ToLower());
        }

        [HttpGet("manufactureCountry")]
        public Manufacture GetManufactureByCountry(string country)
        {
            return _Db.Manufactures.FirstOrDefault(Manufacture => Manufacture.Country.ToLower() == country.ToLower());
        }

        [HttpGet("carId")]
        public Car GetCarById(int id)
        {
            return _Db.Cars.FirstOrDefault(Car => Car.Id == id);
        }

        [HttpGet("carMake")]
        public IActionResult GetCarByMake(string company)
        {
            return Ok(_Db.Cars.Where(Car => Car.Make.Company.ToLower() == company.ToLower()));
        }

        [HttpGet("carModel")]
        public IActionResult GetCarByModel(string model)
        {
            return Ok(_Db.Cars.Where(Car => Car.Model.ToLower() == model.ToLower()));
        }

        [HttpPut("updateManufacture")]
        public Manufacture UpdateManufacture(int id, string company, string country)
        {
            Manufacture m = _Db.Manufactures.FirstOrDefault(Manufacture => Manufacture.Id == id);
            m.Company = company;
            m.Country = country;
            _Db.SaveChanges();
            return m;
        }

        [HttpPut("updateCar")]
        public Car UpdateCar(int id, string model, string vin, string horsepower, string type, int makeId)
        {
            Car car = _Db.Cars.FirstOrDefault(Car => Car.Id == id);
            car.Model = model;
            car.Vin = vin;
            car.Horsepower = horsepower;
            car.Type = type;
            car.MakeId = makeId;
            _Db.SaveChanges();
            return car;
        }

        [HttpDelete("deleteManufacture")]
        public void DeleteManufacture(int id)
        {
            _Db.Manufactures.Remove(_Db.Manufactures.FirstOrDefault(Manufacture => Manufacture.Id == id));
            _Db.SaveChanges();
        }

        [HttpDelete("deleteCar")]
        public void DeleteCar(int id)
        {
            _Db.Cars.Remove(_Db.Cars.FirstOrDefault(Car => Car.Id == id));
            _Db.SaveChanges();
        }

        [HttpPatch("updateManufactureCountry")]
        public Manufacture UpdateManufactureCountry(int id, string country)
        {
            Manufacture m = _Db.Manufactures.FirstOrDefault(Manufacture => Manufacture.Id == id);
            m.Country = country;
            _Db.SaveChanges();
            return m;
        }
    }
}
