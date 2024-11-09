using ma2_banco_de_dados.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace ma2_banco_de_dados.Data;

public class UserDbContext : IdentityDbContext<User>
{
    public DbSet<Artist> Artists { get; set; }
    public DbSet<MusicalGenre> MusicalGenres { get; set; }
    public DbSet<Music> Music { get; set; }
    public DbSet<Album> Album { get; set; }
    public DbSet<Playlist> Playlist { get; set; }

    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
    {
        
    }
}
