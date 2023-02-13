using BulletinBoard.Models;
using System;
using System.Xml.Linq;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<User> users = new List<User>
    {
    new() { Id = 1, Name = "Dima", Email = "dima@gmail.com", BirthDay = new DateTime(1992,04,27) },
    new() { Id = 2, Name = "Masha", Email = "masha@gmail.com", BirthDay = new DateTime(1967,06,27) },
    new() { Id = 3, Name = "Natasha", Email = "natasha@gmail.com", BirthDay = new DateTime(1989,06,07) }
    };

int id_counter = 4;

app.MapGet("/", () => users);

app.MapGet("/user/{id}", (int id) =>
{
    User? user = users.FirstOrDefault(user => user.Id == id);

    if (user == null) return Results.NotFound(new { message = "Пользователь с таким id не найден" });

    return Results.Ok(user);
});

app.MapPost("/user/create", (User newUser) =>
{
    newUser.Id = id_counter;
    users.Add(newUser);

    id_counter++;

    return Results.Ok(newUser);
});

app.MapPut("/user/{id}/update", (int id, User userData) =>
{
    User? userToUpdate = users.FirstOrDefault(user => user.Id == id);

    if (userToUpdate == null) return Results.NotFound(new { message = "Пользователь с таким id не найден" });

    if (userData.Name != null)
    {
        userToUpdate.Name = userData.Name;
    }
    if (userData.Email != null) userToUpdate.Email = userData.Email;

    return Results.Ok(userToUpdate);
});

app.MapDelete("/user/{id}/delete", (int id) =>
{
    User? userToDelete = users.FirstOrDefault(user => user.Id == id);

    if (userToDelete == null) return Results.NotFound(new { message = "Пользователь с таким id не найден" });

    users.Remove(userToDelete);

    return Results.Ok(userToDelete);
});

app.Run("http://localhost:4000");
