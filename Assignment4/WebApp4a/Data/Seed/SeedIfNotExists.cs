using Bogus;
using Microsoft.EntityFrameworkCore;
using ModelLibrary.Models.Candidates;
using ModelLibrary.Models.Certificates;
using ModelLibrary.Models.Exams;
using ModelLibrary.Models.Questions;
using WebApp4a.GiannisServices;


namespace WebApp4a.Data.Seed
{
    public static class SeedIfNotExists
    {
        public static void SeedIfEmpty(WebApplication? app)
        {

            using (var scope = app.Services.CreateScope())
            {
                var service = scope.ServiceProvider;
                try
                {
                    var context = service.GetRequiredService<ApplicationDbContext>();
                    DbSeed.Initialise(context);

                }
                catch (Exception ex)
                {
                    var logger = service.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }

                try
                {
                    var context1 = service.GetRequiredService<ApplicationDbContext>();
                    AddCalculated(context1);

                }
                catch (Exception ex)
                {
                    var logger = service.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }

            }

            void AddCalculated(ApplicationDbContext db)
            {
                using (var scope = app.Services.CreateScope())
                {
                    var service = scope.ServiceProvider;

                    try
                    {
                        var db1 = service.GetRequiredService<ApplicationDbContext>();
                        var certs = db1.Certificates;
                        for (int j = 1; j < certs.ToList().Count()+1; j++)
                        {
                            var maxMarksList = certs.Where(i => i.Id == j)
                                .Include(x => x.Topics)
                                .ToList();  //.ThenInclude(c => c.)
                            foreach (var item in maxMarksList)
                            {
                                item.MaxMark = 0;
                                foreach (var topic in item.Topics)
                                {
                                    item.MaxMark = item.MaxMark + topic.MaxMarks;
                                }
                                    db1.SaveChanges();
                            }
                        }

                        for (int j = 1; j < certs.ToList().Count() + 1; j++)
                        {
                            var cert = certs.Where(i => i.Id == j).FirstOrDefault();
                            var result = cert.MaxMark * (65 / 100.0);
                            cert.PassingMark = Convert.ToInt32(result);
                            db1.SaveChanges();
                        }
                    }
                    catch (Exception ex)
                    {
                        var logger = service.GetRequiredService<ILogger<Program>>();
                        logger.LogError(ex, "An error occurred creating the DB.");
                    }
                }
            }
        }
    }
}
