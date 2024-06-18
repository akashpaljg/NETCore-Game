using GameStore.Dtos;
using GameStore.Endpoints;
using Microsoft.AspNetCore.Http.HttpResults;

var builder = WebApplication.CreateBuilder(args); // it's a builder of a server

var app = builder.Build(); // it will build a server

app.MapGameEndPoints();

app.Run(); // Run the server 
