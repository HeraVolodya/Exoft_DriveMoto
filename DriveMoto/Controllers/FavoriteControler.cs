using AutoMapper;
using DriveMoto.DataBase;
using DriveMoto.Models;
using DriveMoto.Models.AddRequest;
using DriveMoto.Models.AddRequests;
using DriveMoto.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DriveMoto.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]

    public class FavoriteControler : Controller
    {
        private readonly APIDbContext _dbFavorites;
        private readonly IMapper _mapper;


        public FavoriteControler(APIDbContext dbFavorites, IMapper mapper)
        {
            _dbFavorites = dbFavorites;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetFavorite() => Ok(await _dbFavorites.Favorites.ToListAsync());

        [HttpPost]
        public async Task<IActionResult> AddFavorite(
        [FromBody] AddFavoriteRequest addFavoriteRequest)
        {
            try
            {
                var favorite = new Favorite()
                {
                    Id = Guid.NewGuid(),
                    UserId = addFavoriteRequest.UserId,
                    ProductId = addFavoriteRequest.ProductId

                };
                await _dbFavorites.Favorites.AddAsync(favorite);
                await _dbFavorites.SaveChangesAsync();

                var newFavorite = await _dbFavorites.Favorites
                    .Include(t => t.Product)
                    .FirstOrDefaultAsync(t => t.Id == favorite.Id);

                return Ok(_mapper.Map<FavoriteDTO>(newFavorite));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleteFavorite = _dbFavorites.Favorites.SingleOrDefault(cl => cl.Id == id);
            if (deleteFavorite == null)
                return BadRequest();
            _dbFavorites.Favorites.Remove(deleteFavorite);
            await _dbFavorites.SaveChangesAsync();
            return Ok();
        }
    }
}
