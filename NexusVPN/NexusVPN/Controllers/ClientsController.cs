using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NexusVPN.Data;
using NexusVPN.Models;

namespace NexusVPN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly ClientDbContext dbContext;
        public ClientsController(ClientDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAllClients()
        {
            var allClients = dbContext.Clients.ToList();

            return Ok(allClients);
        }
        [HttpPost]
        public IActionResult AddClient(string name, string email, string phone)
        {
            var clientEntity = new Client()
            {
                Name = name,
                Email = email,
                Phone = phone
            };

            dbContext.Clients.Add(clientEntity);
            dbContext.SaveChanges();

            return Ok(clientEntity);
        }
        [HttpPut]
        [Route("{clientName}")]
        public IActionResult EditClient(string clientName, string name, string email, string phone)
        {
            var client = dbContext.Clients.FirstOrDefault(c => c.Name == clientName);

            if (client == null)
            {
                return NotFound(clientName);
            }

            client.Name = name;
            client.Email = email;
            client.Phone = phone;

            dbContext.SaveChanges();

            return Ok(client);
        }  
        [HttpDelete]
        [Route("{clientName}")]
        public IActionResult DeleteClient(string clientName)
        {
            var client = dbContext.Clients.FirstOrDefault(c => c.Name == clientName);

            if (client == null)
            {
                return NotFound(clientName);
            }

            dbContext.Clients.Remove(client);
            dbContext.SaveChanges();

            return Ok(client);
        }
    }
}
