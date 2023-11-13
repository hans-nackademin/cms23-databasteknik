using _01_G_EntityFrameworkCore.Contexts;
using _01_G_EntityFrameworkCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace _01_G_EntityFrameworkCore.Services;

internal class UserService
{
    private readonly DataContext _context;

	public UserService()
	{
		_context = new DataContext();
	}


	public async Task<UserEntity> CreateAsync(UserEntity userEntity)
	{
		if (! await _context.Users.AnyAsync(x => x.Email == userEntity.Email))
		{
			_context.Users.Add(userEntity);
			await _context.SaveChangesAsync();

			return userEntity;
		}

		return null!;
	}
}
