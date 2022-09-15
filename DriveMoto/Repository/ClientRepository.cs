using AutoMapper;
using DriveMoto.DataBase;
using DriveMoto.Models;
using DriveMoto.Models.AddRequest;
using DriveMoto.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DriveMoto.Repository
{
    public class ClientRepository
    {
        private readonly APIDbContext? dbClients;
        private readonly IMapper? _mapper;

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

        private IActionResult BadRequest(string message)
        {
            throw new NotImplementedException();
        }

        private IActionResult Ok(ClientDTO clientDTO)
        {
            throw new NotImplementedException();
        }
    }
}

