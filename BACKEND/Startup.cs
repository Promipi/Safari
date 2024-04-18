using AutoMapper;
using BACKEND.Mapper;
using BACKEND.Models;
using BACKEND.Persistence;
using BACKEND.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace BACKEND
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
           
            
            services.AddDbContext<SafariDbContext>(opt =>
            {
                opt.UseSqlServer("Server=tcp:promi.database.windows.net,1433;Initial Catalog=Safari;Persist Security Info=False;User ID=promi;Password=gtx750ti!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;", b => b.MigrationsAssembly("BACKEND"));
            });

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Safari.API", Version = "v1" });
            });

            services.AddIdentity<User, IdentityRole>(opt =>
            {    //we config the identity
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequiredUniqueChars = 0;
                opt.Password.RequireUppercase = true;
                opt.Lockout = new LockoutOptions() { AllowedForNewUsers = false };
            }).AddEntityFrameworkStores<SafariDbContext>().AddDefaultTokenProviders();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).
           AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options => {
               options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
               {
                   ValidateIssuer = false,
                   ValidateAudience = false,
                   ValidateLifetime = true,
                   ValidateIssuerSigningKey = true,
                   IssuerSigningKey = new SymmetricSecurityKey(
                   Encoding.UTF8.GetBytes("this is my custom Secret key for authentication"))
               };
           });

            services.AddSingleton(new MapperConfiguration(m => {
                m.AddProfile(new MapperProfile());
            }).CreateMapper());
            
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IEventoRepository, EventoRepository>();
           

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "hola v1"));

            app.UseRouting();

            app.UseCors();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
