using Major_Project.repositories;
using Microsoft.AspNetCore.Mvc;
using Major_Project.models;
using Microsoft.EntityFrameworkCore;



namespace Major_Project.controllers{
    [ApiController]
    public class PlayersController: ControllerBase{
        private readonly PlayerDbContext _context;
        public PlayersController(PlayerDbContext context){
            this._context = context;
        }
        [HttpGet("players/{username}", Name ="GetPlayer")]
        public Player? GetPlayer(string? username){
            return this._context.Players.Where(player => player.UserName == username).FirstOrDefault();
        }
        //creats character(wip)
        //[HttpPost("players/{username}", Name = "CreatePlayer")]
        //public void CreatePlayer(string? username){
        //_context.Players.Add(Player => player.UserName == username);
        // }
    }
}