using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using X96J2O_HFT_2021222.Logic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace X96J2O_HFT_2021222.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        ICarLogic carLogic;
        IRentLogic rentLogic;

        public StatController(ICarLogic carLogic, IRentLogic rentLogic)
        {
            this.carLogic = carLogic;
            this.rentLogic = rentLogic;
        }

        [HttpGet]
        public double AvgCarRentPrice()
        {
            return carLogic.AVGRentPrice();
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<string, double>> AvgPriceByBrands()
        {
            return carLogic.AVGRentPriceByBrands();
        }
        [HttpGet]
        public IEnumerable<KeyValuePair<string, double>> GetAvarageInComePerCarModellPerYearCarRentPrice(int year)
        {
            return rentLogic.GetAvarageInComePerCarModellPerYear(year);
        }
        [HttpGet]
        public IEnumerable<int> HasToPayRentFine()
        {
            return rentLogic.HasToPayFine();
        }
        [HttpGet]
        public IEnumerable<int> StillOpenRentsByCarId()
        {
            return rentLogic.StillOpenRentsByCarId();
        }
    }
}
