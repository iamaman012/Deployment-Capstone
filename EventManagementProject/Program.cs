
using EventManagementProject.Context;
using EventManagementProject.Interfaces.Repository;
using EventManagementProject.Interfaces.Services;
using EventManagementProject.Models;
using EventManagementProject.Repositories;
using EventManagementProject.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace EventManagementProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("MyCors", builder =>
                {
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(option =>
            {
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
                });
                option.AddSecurityRequirement(new OpenApiSecurityRequirement
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
                    new string[] { }
                }
            });
            });
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
             .AddJwtBearer(options =>
             {
                 options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                 {
                     ValidateIssuer = false,
                     ValidateAudience = false,
                     ValidateIssuerSigningKey = true,
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenKey:JWT"]))
                 };

             });

            //const string secretName1 = "dbconnectionstring";
            
            //var keyVaultName = "dbstring-aman";
            //var kvUri = $"https://{keyVaultName}.vault.azure.net";

            //var client = new SecretClient(new Uri(kvUri), new DefaultAzureCredential());
            //Console.WriteLine($"Retrieving your secret from {keyVaultName}.");
            //var secret1 = client.GetSecret(secretName1);
           
            //Console.WriteLine($"Your secret is '{secret1.Value.Value}'.");

            builder.Services.AddDbContext<EventManagementContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"));
            });
            //builder.Services.AddDbContext<EventManagementContext>(options =>
            //{
            //    options.UseSqlServer(secret1.Value.Value);
            //});

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IEventRepository, EventRepository>();
            builder.Services.AddScoped<IPvtQuotationRequestRepository, PvtQuotationRequestRepository>();
            builder.Services.AddScoped<IPvtQuotationResponseRepository, PvtQuotationResponseRepository>();
            builder.Services.AddScoped<IScheduledPrivateEventRepository, ScheduledPrivateEventRepository>();
            builder.Services.AddScoped<IPubQuotationRequestRepository, PubQuotationRequestRepository>();
            builder.Services.AddScoped<IPubQuotationResponseRepository, PubQuotationResponseRepository>();
            builder.Services.AddScoped<IScheduledPublicEventRepository, ScheduledPublicEventRepository>();
            builder.Services.AddScoped<ITicketRepository, TicketRepository>();



            builder.Services.AddScoped<IAuth, AuthService>();
            builder.Services.AddScoped<IToken, TokenService>();
            builder.Services.AddScoped<IEvent, EventService>();
            builder.Services.AddScoped<IPvtQuotationRequestService, PvtQuotationRequestService>();
            builder.Services.AddScoped<IPvtQuotationResponseService, PvtQuotationResponseService>();
            builder.Services.AddScoped<ISchedulePrivateEventService,ScheduledPrivateEventService>();
            builder.Services.AddScoped<IPubQuotationRequestService, PubQuotationRequestService>();
            builder.Services.AddScoped<IPubQuotationResponseService, PubQuotationResponseService>();
            builder.Services.AddScoped<IScheduledPublicEventService, ScheduledPublicEventService>();
            builder.Services.AddScoped<ITicketService, TicketService>();
            builder.Services.AddSingleton(new EmailService("smtp.gmail.com", 587, "amanagrawal2001.am.aa@gmail.com", "upjufivltdryzmyj"));




            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();

            app.UseAuthorization();
            app.UseCors("MyCors");


            app.MapControllers();

            app.Run();
        }
    }
}
