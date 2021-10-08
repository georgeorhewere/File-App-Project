using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using FileManager.Data;
using FileManager.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using FileManager.Services.Implementations;
using FileManager.Services.Interfaces;
using FileManager.API.Services;

namespace FileManager.API
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
             services.AddDbContext<FileManagerDbContext>(options =>
             options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"])            
             );
             services.AddIdentity<AppUser, IdentityRole>()
                    .AddEntityFrameworkStores<FileManagerDbContext>()
                    .AddDefaultTokenProviders();
           

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FileManager.API", Version = "v1" });
            });

            //Config
            services.AddSingleton<IJWTConfig, JWTConfig>(scope =>
             {
                 JWTConfig config = new JWTConfig();
                 config.SigningKey = Configuration["Jwt:Key"];
                 config.Issuer = Configuration["Jwt:Issuer"];
                 config.Audience = Configuration["Jwt:Issuer"];
                 config.ExpiryTimeInMinutes = 300;

                 return config;
             });
            services.AddSingleton<IServerFolderConfig, ServerFolderConfig>(scope =>
            {
                ServerFolderConfig config = new ServerFolderConfig();
                config.Folder = Configuration["Server:Folder"];
                return config;
            });

            // Add Authentication for jwt and for google
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                 .AddJwtBearer(options =>
                 {
                     options.TokenValidationParameters = new TokenValidationParameters
                     {
                         ValidateIssuer = true,
                         ValidateAudience = true,
                         ValidateLifetime = true,
                         ValidateIssuerSigningKey = true,
                         ValidIssuer = Configuration["Jwt:Issuer"],
                         ValidAudience = Configuration["Jwt:Issuer"],
                         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                     };
                 })
                 .AddGoogle("google", opt =>
            {
                var googleAuth = Configuration.GetSection("ExternalProviders:Google");
                opt.ClientId = googleAuth["ClientId"];
                opt.ClientSecret = googleAuth["ClientSecret"];
                opt.SignInScheme = IdentityConstants.ExternalScheme;
            });

            // scoped => created per web request => available till the end of this request
            services.AddScoped(typeof(ISubmissionRepository), typeof(SubmissionRepository));
            services.AddScoped(typeof(ISubmissionFileRepository), typeof(SubmissionFileRepository));
            // transient => creeated when injected or requested. -> very short life time
            services.AddTransient<ISubmissionService, SubmissionService>();





        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FileManager.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //authentication and external providers
            
            app.UseAuthentication(); 
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
