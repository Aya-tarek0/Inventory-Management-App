
using InventorySystem.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using InventorySystem.Interfaces;
using InventorySystem.Repository;
using InventorySystem.CQRS.Handler.Product;
using AutoMapper;
using Microsoft.OpenApi.Models;
using Hangfire;
using InventorySystem.CQRS.Commands.Notifications;
using InventorySystem.DTO.Notifications;
using InventorySystem.Service;
namespace InventorySystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
              .AddEntityFrameworkStores<InventoryContext>().
              AddDefaultTokenProviders(); 
            builder.Services.AddDbContext<InventoryContext>(option => {
                option.UseSqlServer(builder.Configuration.GetConnectionString("db"));
            });
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddAutoMapper(typeof(Program).Assembly);
            builder.Services.AddScoped<LowStockNotificationService>();
            builder.Services.AddScoped<ArchiveOldTransactionsService>();



            builder.Services.AddHangfire(config =>
            {
                config.UseSqlServerStorage(builder.Configuration.GetConnectionString("db")); 
            });

            builder.Services.AddHangfireServer();
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new()
                {
                    ValidateIssuer = true,
                    ValidIssuer = builder.Configuration["JWT:Iss"],
                    ValidateAudience = false,
                    ValidAudience = builder.Configuration["JWT:Aud"],
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
                };
            });

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen();
            builder.Services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Inventory Management API",
                    Description = "API for handling Inventory Transactions"
                });

                swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer ey...\"",
                });

                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });


            builder.Services.AddMediatR(typeof(GetAllProductsHandler));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.UseHangfireDashboard("/hangfire");

            app.MapControllers();

            //BackGround Job Log Daily Notification Fory Products In Inventory Under Low Stock
            RecurringJob.AddOrUpdate<LowStockNotificationService>(
          "DailyCheckToLowStock",
          e => e.ExecuteFunction(),
          Cron.Daily
      );

            //BackGround Job To Archive Transaction Older Than one Year

            RecurringJob.AddOrUpdate<ArchiveOldTransactionsService>(
                     "archiveOldTransactions",
                      e=> e.ExecuteFun(),
                      Cron.Daily
                             );

            app.Run();

        }
    }
}
