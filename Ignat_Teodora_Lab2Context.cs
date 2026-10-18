using Microsoft.EntityFrameworkCore;

public class Ignat_Teodora_Lab2Context(DbContextOptions<Ignat_Teodora_Lab2Context> options) : DbContext(options)
{
    public DbSet<Ignat_Teodora_Lab2.Models.Book> Book { get; set; } = default!;
    public DbSet<Ignat_Teodora_Lab2.Models.Publisher> Publisher { get; set; } = default!;
    public DbSet<Ignat_Teodora_Lab2.Models.Authors> Authors { get; set; }
}
