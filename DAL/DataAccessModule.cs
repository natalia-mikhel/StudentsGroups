using Domain;
using Microsoft.Extensions.DependencyInjection;
using Utils.Modules;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace DAL
{
    public class DataAccessModule : Module
    {
        public override void Load(IServiceCollection services)
        {
            services.AddDbContext<IDbContext, AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("MsSqlConnection")));
        }
    }
}