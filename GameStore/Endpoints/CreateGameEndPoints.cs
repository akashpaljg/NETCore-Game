using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameStore.Dtos;

namespace GameStore.Endpoints
{
    public static class CreateGameEndPoints
    {
        private static readonly List<GameDto> games = [
            new (
                1,
                "Mini Militia",
                "Advetnure",
                0.00M,
                new DateOnly(2024,7,30)
            ),
            new (
                2,
                "Temple Run",
                "Advetnure",
                0.00M,
                new DateOnly(2014,7,30)
            ),
            new (
                3,
                "Hill Climb Racing",
                "Advetnure",
                0.00M,
                new DateOnly(2014,7,30)
            )
        ];

        const string GetGame = "GetGame";

        public static RouteGroupBuilder MapGameEndPoints(this WebApplication app){
            var group = app.MapGroup("games");
            app.MapGet("games",()=> games);

            group.MapGet("/{id}", (int id) => {
                var game = games.FirstOrDefault(s => s.Id == id);
                if (game == null) {
                    return Results.NotFound();
                }
                return Results.Ok(game); 
            }).WithName(GetGame); 

            group.MapPost("/",(CreateGameDto game)=>{
                GameDto newGame = new (
                    games.Count+1,
                    game.name,
                    game.Genre,
                    game.Price,
                    game.Releasedate
                );
                games.Add(newGame); 
                return Results.CreatedAtRoute(GetGame,new { Id = newGame.Id },newGame);
            });

            group.MapPut("/{id}",(int id,UpdatedGameDto game)=>{
                var index = games.FindIndex(s=>s.Id == id);
                if(index == -1){
                    return Results.NotFound();
                }
                games[index] = new GameDto (
                    id,
                    game.name,
                    game.Genre,
                    game.Price,
                    game.Releasedate
                );

                // gameExist.name = game.name;
                // gameExist.Genre = game.Genre;
                // gameExist.Price = game.Price;
                // gameExist.Releasedate = game.Releasedate;
                
                // games.Add(newGame);
                return Results.NoContent();
            });

            group.MapDelete("/{id}",(int id) => {
                var stockModel = games.FirstOrDefault(s=>s.Id == id);
                if(stockModel == null){
                    return Results.NotFound();
                }
                games.Remove(stockModel);
                return Results.NoContent();
            }
        );
        return group;
    }
}
}