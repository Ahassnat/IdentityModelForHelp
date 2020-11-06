using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityAPI.Data;
using IdentityAPI.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace IdentityAPI
{
    public class Startup
    {
        public IConfiguration _config { get; set; }
        public Startup(IConfiguration config)
        {
            _config = config;
        }

        

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            
            services.AddDbContext<DataContext>(x 
                    =>x.UseSqlite(_config.GetConnectionString("DefaultConnection")));
            IdentityBuilder builder = services.AddIdentity<User,Role>(opt =>
           {
               opt.Password.RequireDigit = false;
               opt.Password.RequiredLength = 4;
               opt.Password.RequireNonAlphanumeric = false;
               opt.Password.RequireUppercase = false;
           }).AddEntityFrameworkStores<DataContext>()
                .AddDefaultTokenProviders();;
            // to passing some paramters like user type, role type
            // builder = new IdentityBuilder(builder.UserType, typeof(Role), builder.Services);
            // builder.AddEntityFrameworkStores<DataContext>(); // telling the identity we want to use EF as Store
            // builder.AddRoleValidator<RoleValidator<Role>>();
            // builder.AddRoleManager<RoleManager<Role>>();
            // builder.AddSignInManager<SignInManager<User>>();
        }


      

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
