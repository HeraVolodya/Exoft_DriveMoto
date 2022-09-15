using DriveMoto.DataBase;
using DriveMoto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net.Security;
using AutoMapper;
using DriveMoto.Models.DTOs;
using DriveMoto.Models.AddRequest;
using DriveMoto.Models.UpdateRequests;

namespace DriveMoto.Controllers
{
    [ApiController]
    [Route("/api/[controller]")] 

    public class ClientController : Controller
    {
        private readonly APIDbContext dbClients;
        private readonly IMapper _mapper;

        public ClientController(APIDbContext dbClients, IMapper mapper)
        {
            this.dbClients = dbClients;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetClients() => Ok(await dbClients.Clients.ToListAsync());
        
        
        [HttpPost]
        public async Task<IActionResult> AddClient(AddClientRequest addClientRequest)
        {
            try
            {
                var client = new Client()
                {
                    Id = Guid.NewGuid(),
                    FirstName = addClientRequest.FirstName,
                    LastName = addClientRequest.LastName,
                    Email = addClientRequest.Email,
                    Phone = addClientRequest.Phone,
                    Password = addClientRequest.Password
                };
                await dbClients.Clients.AddAsync(client);
                await dbClients.SaveChangesAsync();


                return Ok(_mapper.Map<ClientDTO>(client));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateCliaent([FromRoute] Guid id, DateTimeOffset datatime, UpdateClientRequest updateClientRequest)
        {
            try
            {
                var client = await dbClients.Clients.FindAsync(id);
                if (client != null)
                {
                    client.FirstName = updateClientRequest.FirstName;
                    client.LastName = updateClientRequest.LastName;
                    client.Phone = updateClientRequest.Phone;
                    client.Email = updateClientRequest.Email;
                    client.Password = updateClientRequest.Password;

                    await dbClients.SaveChangesAsync();
                    return Ok(_mapper.Map<ClientDTO>(client));

                }

                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        //видалення клієнта
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteClient([FromRoute] Guid id)
        {
            try
            {
                var client = await dbClients.Clients.FindAsync(id);

                if (client != null)
                {
                    dbClients.Remove(client);
                    await dbClients.SaveChangesAsync();

                    return Ok(NoContent);
                }

                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}

