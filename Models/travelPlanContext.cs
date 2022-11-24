using Microsoft.EntityFrameworkCore;

namespace AdessoRideShare.Models;

public class travelPlanContext : DbContext {
    public travelPlanContext(DbContextOptions<travelPlanContext> options) 
    :base(options) {

    }
    public DbSet<travelPlan> travelPlans {get; set;} = null!;
}