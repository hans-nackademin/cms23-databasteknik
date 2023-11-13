using _03_Database_with_EntityFrameworkCore.Contexts;
using _03_Database_with_EntityFrameworkCore.Models.Entities;

namespace _03_Database_with_EntityFrameworkCore.Services;

internal class UserService
{
    private readonly DataContext context = new DataContext();

    public void CreateUser(UserEntity userEntity)
    {
        context.Users.Add(userEntity);
        context.SaveChanges();
    }
}
