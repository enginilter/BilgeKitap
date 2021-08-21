using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BilgeKitap.Core.DependencyResolvers;
using BilgeKitap.Core.Extensions;
using BilgeKitap.Core.Utilities.IoC;
using BilgeKitap.Core.Utilities.Security.Encryption;
using BilgeKitap.Core.Utilities.Security.JWT;
using BilgeKitap.Data;
using BilgeKitap.Data.Concrete.EntityFramework;
using BilgeKitap.Entity.AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;


namespace BilgeKitap.WebAPI
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
            services.AddControllers();
           

            services.AddCors();
            services.AddSwaggerDocument();

            services.AddDbContext<BKContext>(option =>
            {
                option.UseSqlServer(Configuration.GetConnectionString("Connection"));
            });

            services.AddAutoMapper(typeof(AutoMapperProfile));
            var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();

            //Bu sistemde Authentication olarak Jwt kullanýlacak diye haber verdiðimiz yer.
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
                    };
                });
            //Eklendi
            services.AddDependencyResolvers(new ICoreModule[] 
            {
                new CoreModule()
            });
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Kendi yazdýðýmýz hata yakalama middleware'i
            app.ConfigureCustomExceptionMiddleware();

            //Bu adresten gelecek herhangi bir isteðe izin ver.
            app.UseCors(builder=>builder.WithOrigins("http://localhost:4200").AllowAnyHeader());
            app.UseHttpsRedirection();

            app.UseRouting();
            
            //Swagger
            app.UseOpenApi();
            app.UseSwaggerUi3();

            //Eklendi.
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
