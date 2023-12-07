using Microsoft.EntityFrameworkCore;

namespace LogixTaskApi.Models.DataBase
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<UserProfileDBModel> UserProfileDBModels { get; set; }
        public DbSet<ClassDbModel> Classes { get; set; }
        public DbSet<ClassUser> ClassUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClassUser>()
                .HasKey(cu => new { cu.UserId, cu.ClassId });

            modelBuilder.Entity<ClassUser>()
                .HasOne(cu => cu.Class)
                .WithMany(c => c.ClassUsers)
                .HasForeignKey(cu => cu.ClassId);

            modelBuilder.Entity<ClassUser>()
                .HasOne(cu => cu.User)
                .WithMany(u => u.ClassUsers)
                .HasForeignKey(cu => cu.UserId);

            modelBuilder.Entity<UserProfileDBModel>().HasData(
                            new UserProfileDBModel
                            {
                                Id = Guid.NewGuid(),
                                Email = "admin",
                                Password = "admin",
                                FirstName = "William",
                                LastName = "Lenon",
                                FullName = "William Lenon",
                                DateOfBirth = DateTime.Now.ToString("MM/dd/yyyy"),
                                Address = "859 ADAMS AVE 7",
                                IsActive = true,
                                PhoneNumber = "(999) 999 - 9999",
                                Role = "admin"
                            }
                        );

            modelBuilder.Entity<ClassDbModel>().HasData(
                new ClassDbModel
                {
                    Id = 1,
                    Name = "Introduction to C# Programming",
                    Description = "A beginner-level course for learning C# programming basics.",
                },
                new ClassDbModel
                {
                    Id = 2,
                    Name = "Advanced Python Development",
                    Description = "An advanced course covering Python programming concepts and best practices."
                },
                new ClassDbModel
                {
                    Id = 3,
                    Name = "Web Development with JavaScript",
                    Description = "Learn front-end and back-end web development using JavaScript and related technologies."
                },
                new ClassDbModel
                {
                    Id = 4,
                    Name = "Data Science with Python",
                    Description = "Explore data science and machine learning concepts using the Python programming language."
                },
                new ClassDbModel
                {
                    Id = 5,
                    Name = "Mobile App Development with Flutter",
                    Description = "Build cross-platform mobile apps using the Flutter framework and Dart programming language."
                }
            );
        }
    }
}
