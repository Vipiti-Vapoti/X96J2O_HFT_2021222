using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using X96J2O_HFT_2021222.Logic;
using X96J2O_HFT_2021222.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace X96J2O_HFT_2021222.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RentController : ControllerBase
    {
        IRentLogic logic;

        public RentController(IRentLogic logic)
        {
            this.logic = logic;
        }


        [HttpGet]
        public IEnumerable<Rent> ReadAll()
        {
            return this.logic.ReadAll();
        }


        [HttpGet("{id}")]
        public Rent Read(int id)
        {
            return logic.Read(id);
        }


        [HttpPost]
        public void Create([FromBody] Rent value)
        {
            this.logic.Update(value);
        }


        [HttpPut("{id}")]
        public void Update([FromBody] Rent value)
        {
            this.logic.Update(value);
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            logic.Delete(id);
        }
    }
}
