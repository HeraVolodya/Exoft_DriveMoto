using AutoMapper;
using DriveMoto.DataBase;
using DriveMoto.Models.AddRequest;
using DriveMoto.Models.DTOs;
using DriveMoto.Models.UpdateRequests;
using DriveMoto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DriveMoto.Models.AddRequests;


namespace DriveMoto.Controllers
{
    public class AdvertisementControler : Controller
    {
        private readonly APIDbContext _dbAdvertisements;
        private readonly IMapper _mapper;

        public AdvertisementControler(APIDbContext dbAdvertisements, IMapper mapper)
        {
            _dbAdvertisements = dbAdvertisements;
            _mapper = mapper;
        }

        [HttpGet("getAdvertisement")]
        public async Task<IActionResult> GetAdvertisement() => Ok(await _dbAdvertisements.Advertisements.ToListAsync());

        [HttpPost("addAdvertisement")]
        public async Task<IActionResult> AddAdvertisement(AddAdvertisementRequest addAdvertisementRequest)
        {
            try
            {
                var advertisement = new Advertisement()
                {
                    Id = Guid.NewGuid(),
                    Text = addAdvertisementRequest.Text,
                    ImageURL = addAdvertisementRequest.ImageURL,
                   
                };
                await _dbAdvertisements.Advertisements.AddAsync(advertisement);
                await _dbAdvertisements.SaveChangesAsync();

                return Ok(_mapper.Map<AdvertisementDTO>(advertisement));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, UpdateAdvertisementRequest updateAdvertisementRequest)
        {
            try
            {
                var advertisement = await _dbAdvertisements.Advertisements.FindAsync(id);
                if (advertisement != null)
                {

                    advertisement.Text = updateAdvertisementRequest.Text;
                    advertisement.ImageURL = updateAdvertisementRequest.ImageURL;

                    await _dbAdvertisements.SaveChangesAsync();

                    return Ok(_mapper.Map<AdvertisementDTO>(advertisement));

                }
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteAdvertisement([FromRoute] Guid id)
        {
            try
            {
                var advertisement = await _dbAdvertisements.Advertisements.FindAsync(id);

                if (advertisement != null)
                {
                    _dbAdvertisements.Remove(advertisement);
                    await _dbAdvertisements.SaveChangesAsync();
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
