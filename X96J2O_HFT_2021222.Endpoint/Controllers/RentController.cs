using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using X96J2O_HFT_2021222.Endpoint.Services;
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
        IHubContext<SignalRHub> hub;

        public RentController(IRentLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub; 
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
            this.logic.Create(value);
            this.hub.Clients.All.SendAsync("RentCreated",value);
        }

 
        [HttpPut]
        public void Update([FromBody] Rent value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("RentUpdated", value);
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var rentToDelete = logic.Read(id);
            logic.Delete(id);
            this.hub.Clients.All.SendAsync("RentDeleted", rentToDelete);
        }
    }
}
