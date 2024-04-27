using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using static Domain.Entities.ProductEntity;

namespace Infrastructure.DBContext;

public class ProjectDbContext : DbContext
{
	public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options) { }
    public DbSet<UserEntity> Users { get; set; } = null!;
    public DbSet<UserRolesEntity> UserRoles { get; set; } = null!;
	public DbSet<VariablesEntity> Variables { get; set; } = null!;
	public DbSet<VariableValuesEntity> VariableValues { get; set; } = null!;
	public DbSet<RoleEntity> Roles { get; set; } = null!;

	public DbSet<ContactEntity> Contact {get; set;} = null!;

	public DbSet<CategoryEntity> Categories {get; set;} = null!;

	public DbSet<ProductEntity> Products {get; set;} = null!;

	public DbSet<CategoryProductEntity> CategoryProductEntities{get; set;} = null!;

	

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		foreach (var relationship in modelBuilder.Model.GetEntityTypes()
			.SelectMany(e => e.GetForeignKeys()))
		{
			relationship.DeleteBehavior = DeleteBehavior.NoAction;
		}

		modelBuilder.Entity<UserRolesEntity>().HasKey(x => new { x.UserId, x.RoleId });
		modelBuilder.Entity<ContactEntity>().HasNoKey();
		modelBuilder.Entity<CategoryProductEntity>()
        .HasKey(e => new { e.CategoryId, e.ProductId });

    	modelBuilder.Entity<CategoryProductEntity>()
    	    .HasOne(e => e.Category)
    	    .WithMany(e => e.CategoryProducts)
    	    .HasForeignKey(e => e.CategoryId)
    	    .OnDelete(DeleteBehavior.Cascade);

    	modelBuilder.Entity<CategoryProductEntity>()
    	    .HasOne(e => e.Product)
    	    .WithMany(e => e.CategoryProducts)
    	    .HasForeignKey(e => e.ProductId)
        	.OnDelete(DeleteBehavior.Cascade);
    }


	


// 	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
// {
//     optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MyDatabase;Trusted_Connection=True;");
// }
}