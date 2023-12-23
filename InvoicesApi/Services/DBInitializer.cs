using InvoicesApi.Models;

public static class DBInitializer
{
    public static void InitializeDevelopment(WebApplication app) {
        if(!app.Environment.IsDevelopment()) return;

        try {
            using (var serviceScope = app.Services.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDBContext>();
                SeedDB(context);
            }
        } catch(Exception ex) {
            var logger = app.Services.GetService<ILogger<Program>>();
            logger.LogError(ex, "An error occurred while seeding the database.");
        }
    }
    
    private static void SeedDB(AppDBContext context)
    {
        if (context.Customers.Any()) return;

        // Seed data
        context.Customers.Add(new Customer { Name = "Very Important Company" });
        context.Customers.Add(new Customer { Name = "Extermely Important Conglomeration" });
        context.SaveChanges();
    }
}
