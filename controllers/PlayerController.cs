using Major_Project.repositories;
using Microsoft.AspNetCore.Mvc;
using Major_Project.models;
using Microsoft.EntityFrameworkCore;
using Major_Project.errors;
using System.Data;



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
        [HttpPost("players/{username}", Name = "CreatePlayer")]
        public void CreatePlayer(string? username){
            Player player = new Player
            {
                UserName = username,
            };
            Data data = new Data
            {
                HP = 100,
                MP = 50,
                AR = 0.5,
                location = 0
            };
            if(GetPlayer(username)?.UserName == player.UserName){
                throw new UserNameExistsError("Username already exists");
            }else{
                player.Data = data;
                _context.Players.Add(player);
                _context.SaveChanges();
            };
        }
        //deletes a user
        [HttpDelete("players/{username}",Name = "DeletePlayer")]
        public void DeletePlayer(string? username){
            var user = this._context.Players.Where(player => player.UserName == username).FirstOrDefault();
            var data = this._context.Datas.Where(data => data.Id == user.DataId).FirstOrDefault();
            _context.Datas.Remove(data);
            _context.Players.Remove(user);
            _context.SaveChanges();
        }
    }
}