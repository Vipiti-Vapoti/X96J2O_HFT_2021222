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
    public class CarController : Controller
    {
        ICarLogic logic;
        IHubContext<SignalRHub> hub;
        public CarController(ICarLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Car> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Car Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Car value)
        {
            this.logic.Create(value);
            this.hub.Clients.All.SendAsync("CarCreated", value);
        }

        [HttpPut]
        public void Update([FromBody] Car value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("CarUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var carToDelete = logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("CarDeleted", carToDelete);
        }
    }
}
