using BookCollection.Core;
using BookCollection.Core.Interfaces;
using BookCollection.Repository;
using BookCollection.Repository.DatabaseInitializer;
using BookCollection.Repository.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookCollection.Service
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ApplicationDbContext>();
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("Sqlite")));
            services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
            services.AddMvc();
            services.AddTransient<IReadOnlyRepository, ReadOnlyRepository>();
            services.AddTransient<IRepository, CollectionRepository>();
            services.AddTransient<IAuthorService, AuthorService>();
            services.AddTransient<IBookCollectionService, BookCollectionService>();
            services.AddTransient<IBookFormatService, BookFormatService>();
            services.AddTransient<IBookGenreService, BookGenreService>();
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<IUserService, UserService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                if (!serviceScope.ServiceProvider.GetService<ApplicationDbContext>().AllMigrationsApplied())
                {
                    serviceScope.ServiceProvider.GetService<ApplicationDbContext>().Database.Migrate();
                    serviceScope.ServiceProvider.GetService<ApplicationDbContext>().EnsureSeedData();
                }
            }

            app.UseMvc();
        }
    }
}
