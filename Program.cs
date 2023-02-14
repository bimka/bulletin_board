using System;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;

using BulletinBoard.Models;
using BulletinBoard.Helpers;

var builder = WebApplication.CreateBuilder();
string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));

var app = builder.Build();

app.MapGet("/", (ApplicationContext db) => db.Users.ToList());

app.MapGet("/user/{id}", (int id, ApplicationContext db) =>
{
    User? user = db.Users.FirstOrDefault(user => user.Id == id);

    if (user == null) return Results.NotFound(new { message = "Пользователь с таким id не найден" });


    return Results.Ok(user);
});

app.MapPost("/user/create", (User newUser, ApplicationContext db) =>
{
    db.Users.Add(newUser);
    db.SaveChanges(); 

    return Results.Ok(newUser);
});

app.MapPut("/user/{id}/update", (int id, User userData, ApplicationContext db) =>
{
    User? userToUpdate = db.Users.FirstOrDefault(user => user.Id == id);

    if (userToUpdate == null) return Results.NotFound(new { message = "Пользователь с таким id не найден" });

    if (userData.Name != null) userToUpdate.Name = userData.Name;      
    
    if (userData.Email != null) userToUpdate.Email = userData.Email;

    db.SaveChanges();
    return Results.Ok(userToUpdate);
});

app.MapDelete("/user/{id}/delete", (int id, ApplicationContext db) =>
{
    User? userToDelete = db.Users.FirstOrDefault(user => user.Id == id);

    if (userToDelete == null) return Results.NotFound(new { message = "Пользователь с таким id не найден" });

    db.Users.Remove(userToDelete);
    db.SaveChanges();

    return Results.Ok(userToDelete);
});

app.Run("http://localhost:4000");

