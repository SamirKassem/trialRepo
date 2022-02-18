using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace trial.Data
{
    public class AppDbInititalizer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                // EF Core will generate the id's since the is set as the primary key.
                if (!context.Books.Any())
                {
                    context.Books.AddRange(new Models.Book()
                    {
                        Title = "1st Book Title",
                        Description = "1st Book Description",
                        isRead = true,
                        dateRead = System.DateTime.Now.AddDays(-10),
                        Genre = "Bio",
                        coverUrl = "https:...",
                        DateAdded = System.DateTime.Now
                    }, new Models.Book()
                    {
                        Title = "2md Book Title",
                        Description = "2md Book Description",
                        isRead = true,
                        dateRead = System.DateTime.Now.AddDays(-10),
                        Genre = "Bio",
                        coverUrl = "https:...",
                        DateAdded = System.DateTime.Now
                    });
                    context.SaveChanges();
                }
            }

        }
    }
}
