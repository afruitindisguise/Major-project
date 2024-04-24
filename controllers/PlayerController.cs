using Major_Project.repositories;
using Microsoft.AspNetCore.Mvc;
using Major_Project.models;
using Microsoft.EntityFrameworkCore;
using Major_Project.errors;



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
        //creats a new user
        [HttpPost("players", Name = "CreatePlayer")]
        public void CreatePlayer(string? username){
            Data data = new Data
            {
                HP = 100,
                MP = 50,
                AR = 0.5,
                location = 0
            };
            Player player = new Player
            {
                UserName = username,
                Data = data
            };
            _context.Players.Add(player);
            _context.SaveChanges();
        }
        [HttpDelete("Players/",Name = "DeletePlayer")]
        public void DeletePlayer(Player user){
            _context.Players.Remove(user);
            _context.SaveChanges();
        }
    }
}