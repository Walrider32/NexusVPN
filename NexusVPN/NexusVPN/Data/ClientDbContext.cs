using Microsoft.EntityFrameworkCore;
using NexusVPN.Models;

namespace NexusVPN.Data
{
    public class ClientDbContext : DbContext
    {
        public ClientDbContext(DbContextOptions<ClientDbContext> options) : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
    }
}
