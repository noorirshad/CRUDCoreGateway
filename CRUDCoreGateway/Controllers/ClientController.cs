using CRUDCoreGateway.Data;
using CRUDCoreGateway.Model;
using CRUDCoreGateway.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CRUDCoreGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        public ApplicationDbContext _dbContext;
        public ClientController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        ///add client into system 
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        /// <response code="400">If the item is null</response>
        [HttpPost]
        [Route("add-client")]
        public IActionResult AddClient(ClientRequestViewModel model)
        {
            Client client = new Client()
            {
                ClientId = Guid.NewGuid(),
                CompanyName = model.CompanyName,
                CreatedAt = DateTime.Now,
                Email = model.Email,    
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                UpdatedAt = DateTime.Now,
                Address = model.Address,

            };
            _dbContext.Clients.Add(client);
            _dbContext.SaveChanges();
            return Ok(new ResponseViewModel { Status = "Success", Message = "Record Added Successfully", Data = client.ClientId });
        }

        /// <summary>
        ///get client details from system 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <response code="400">If the item is null</response>
        [HttpGet]
        [Route("get-client/{clientId}")]
        public IActionResult GetClient(Guid clientId)
        {
            
            var client = _dbContext.Clients.Find(clientId);
            if(client == null)
            {
                return BadRequest(new ResponseViewModel { Status = "Error", Message = "client against this Id does not exist", Data = clientId });
            }
            ClientViewModel clientViewModel = new ClientViewModel()
            {
                ClientId = client.ClientId,
                CompanyName = client.CompanyName,
                CreatedAt = client.CreatedAt,
                Email = client.Email,
                FirstName = client.FirstName,
                LastName = client.LastName,
                PhoneNumber = client.PhoneNumber,
                UpdatedAt = client.UpdatedAt,
                Address = client.Address,
            };
            return Ok(new ResponseViewModel { Status = "Success", Message = "Record get Successfully", Data = clientViewModel });
        }

        /// <summary>
        ///update client details into system 
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <response code="400">If the item is null</response>
        [HttpPut]
        [Route("update-client/{clientId}")]
        public IActionResult UpdateClient(Guid clientId, ClientRequestViewModel model)
        {

            var client = _dbContext.Clients.Find(clientId);
            if (client == null)
            {
                return BadRequest(new ResponseViewModel { Status = "Error", Message = "client against this Id does not exist", Data = clientId });
            }
            client.CompanyName = model.CompanyName;
            client.Email = model.Email;
            client.FirstName = model.FirstName;
            client.LastName = model.LastName;
            client.PhoneNumber = model.PhoneNumber;
            client.UpdatedAt = DateTime.Now;
            client.Address = model.Address;
            _dbContext.Clients.Update(client);
            _dbContext.SaveChanges();
            return Ok(new ResponseViewModel { Status = "Success", Message = "Record updated Successfully", Data = clientId});
        }

        /// <summary>
        ///delete client from system 
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        /// <response code="400">If the item is null</response>
        [HttpDelete]
        [Route("delete-client/{clientId}")]
        public IActionResult DeleteClient(Guid clientId)
        {

            var client = _dbContext.Clients.Find(clientId);
            if (client == null)
            {
                return BadRequest(new ResponseViewModel { Status = "Error", Message = "client against this Id does not exist", Data = clientId });
            }
            _dbContext.Clients.Remove(client);
            _dbContext.SaveChanges();
            return Ok(new ResponseViewModel { Status = "Success", Message = "Record Deleted Successfully", Data = clientId });
        }
    }
}
