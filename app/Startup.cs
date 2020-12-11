using app.Contracts.Repos.WrapperRepo;
using app.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace app
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

            var defaultConnection = Configuration["ConnectionStrings:DefaultConnection"];
            //services.AddDbContext<DataContext>(options => options.UseMySQL(Configuration.GetConnectionString("DefaultConnection")));

            services
                .AddDbContext<RepositoryContext>(options =>
                    options.UseSqlServer(defaultConnection, b => b.MigrationsAssembly("PaySEC.Api")));


            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "app", Version = "v1"}); });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "app v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}