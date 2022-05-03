using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using X96J2O_HFT_2021222.Logic;
using X96J2O_HFT_2021222.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace X96J2O_HFT_2021222.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        IBrandLogic logic;

        public BrandController(IBrandLogic logic)
        {
            this.logic = logic;
        }


        [HttpGet]
        public IEnumerable<Brand> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Brand Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Brand value)
        {
            this.logic.Create(value);
        }

        [HttpPut]
        public void Put([FromBody] Brand value)
        {
            this.logic.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
