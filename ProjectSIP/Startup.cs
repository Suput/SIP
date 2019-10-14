using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ProjectSIP.Data;
using ProjectSIP.Models.Identity;
using ProjectSIP.Models.Options;
using ProjectSIP.Services.Jwt;
using System;

namespace ProjectSIP
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
            // add options to project
            services.Configure<JwtOptions>(Configuration.GetSection(nameof(JwtOptions)));

            // Configure database
            string connection = Configuration.GetConnectionString("PostgreSQL");
            services.AddEntityFrameworkNpgsql()
                    .AddDbContext<DatabaseContext>(options =>
                        options.UseNpgsql(connection));

            // Configure identity
            services.AddIdentity<User, Role>(identityOptions =>
            {
                // configure identity options
                identityOptions.Password.RequireDigit = false;
                identityOptions.Password.RequireLowercase = false;
                identityOptions.Password.RequireUppercase = false;
                identityOptions.Password.RequireNonAlphanumeric = false;
                identityOptions.Password.RequiredLength = 6;

                identityOptions.SignIn.RequireConfirmedEmail = false;

                identityOptions.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_.@+";

                identityOptions.User.RequireUniqueEmail = true;

                identityOptions.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(0);
                identityOptions.Lockout.MaxFailedAccessAttempts = 100;
            })
                .AddEntityFrameworkStores<DatabaseContext>()
                .AddDefaultTokenProviders();

            // auto mapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // swagger for services in ClientApp
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            // Add transients for interfaces
            services.AddTransient<IJwtFactory, JwtFactory>();

            // JWT configuration
            var jwtOptions = Configuration.GetSection(nameof(JwtOptions)).Get<JwtOptions>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        // do we need to validate publisher while token is validating
                        ValidateIssuer = true,
                        // publisher
                        ValidIssuer = jwtOptions.Issuer,

                        // do we need to validate consumer
                        ValidateAudience = true,
                        // setting consumer token
                        ValidAudience = jwtOptions.Audience,
                        // do we need to validate time of existence
                        ValidateLifetime = true,

                        // setting security key
                        IssuerSigningKey = jwtOptions.SymmetricSecurityKey,
                        // validation of security key
                        ValidateIssuerSigningKey = true,
                    };
                });

            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = true;
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            }).SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseSwagger();

            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });
            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller}/{action=Index}/{id?}");
            //});

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
