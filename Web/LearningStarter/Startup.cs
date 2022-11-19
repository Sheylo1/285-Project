using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using LearningStarter.Data;
using LearningStarter.Entities;
using LearningStarter.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace LearningStarter
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
            services.AddCors();
            services.AddControllers();

            services.AddHsts(options =>
            {
                options.MaxAge = TimeSpan.MaxValue;
                options.Preload = true;
                options.IncludeSubDomains = true;
            });

            services.AddDbContext<DataContext>(options =>
            {
                // options.UseInMemoryDatabase("FooBar");
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            //TODO
            services.AddMvc();

            services
                .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.Events.OnRedirectToLogin = context =>
                    {
                        context.Response.StatusCode = 401;
                        return Task.CompletedTask;
                    };
                });

            services.AddAuthorization();

            // Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Learning Starter Server",
                    Version = "v1",
                    Description = "Description for the API goes here.",
                });

                c.CustomOperationIds(apiDesc => apiDesc.TryGetMethodInfo(out var methodInfo) ? methodInfo.Name : null);
                c.MapType(typeof(IFormFile), () => new OpenApiSchema { Type = "file", Format = "binary" });
            });

            services.AddSpaStaticFiles(config =>
            {
                config.RootPath = "learning-starter-web/build";
            });

            services.AddHttpContextAccessor();

            // configure DI for application services
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DataContext dataContext)
        {
            dataContext.Database.EnsureDeleted();
            dataContext.Database.EnsureCreated();

            app.UseHsts();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger(options =>
            {
                options.SerializeAsV2 = true;
            }); ;

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Learning Starter Server API V1");
            });

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(x => x.MapControllers());

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "learning-starter-web";
                if (env.IsDevelopment())
                {
                    spa.UseProxyToSpaDevelopmentServer("http://localhost:3001");
                }

            });
            SeedUsers(dataContext);
            SeedPostions(dataContext);
            SeedEmployees(dataContext);
            SeedSocials(dataContext);
            SeedPosts(dataContext);
            SeedComments(dataContext);
            SeedBetCategory(dataContext);
            SeedEscrowSystems(dataContext);
            SeedHouseSystems(dataContext);
            SeedTransactions(dataContext);
            SeedBet(dataContext);
            SeedTransactionUsers(dataContext);
            SeedBetTransactions(dataContext);
            SeedBetDisputes(dataContext);
           
            
        }

        private void SeedBetCategory(DataContext dataContext)
        {
            if (!dataContext.BetCategories.Any())
            {
                var seededBetCategory = new BetCategory
                {
                    Name = "Bet Name",
                };

                dataContext.BetCategories.Add(seededBetCategory);
                dataContext.SaveChanges();
            }
        }

        public void SeedBet(DataContext dataContext)
        {
            if (!dataContext.Bets.Any())
            { 
                var seededBet = new Bet
                {
                    Name = "Bet",
                    BetCategoryId = dataContext.BetCategories.FirstOrDefault().Id,
                    CreatedDate = DateTime.Now,
                    CommentId = dataContext.Comments.FirstOrDefault().Id,
                    EscrowSystemId = dataContext.EscrowSystems.FirstOrDefault().Id,
                    BetDisputeCall = false,
                };

                dataContext.Bets.Add(seededBet);
                dataContext.SaveChanges();
            }
        }
            

 
        public void SeedBetDisputes(DataContext dataContext)
        {

            if (!dataContext.BetDisputes.Any())
            {
                var seededBetDispute = new BetDispute
                {
                    BetId = dataContext.Bets.FirstOrDefault().Id,
                    Issue = "Undisputed",
                    CreatedDate = DateTime.Now,
                    ClosedDate = DateTime.Now,
                    EmployeeId = 1,
                };

                dataContext.BetDisputes.Add(seededBetDispute);
                dataContext.SaveChanges();
            }
            
            
        }
        public void SeedEscrowSystems(DataContext dataContext) 
        {
            if (!dataContext.EscrowSystems.Any())
            {
                var seededEscrowSystem = new EscrowSystem
                {
                    PaymentType = " ",
                    CreatedDate = DateTimeOffset.Now,

                };

                dataContext.EscrowSystems.Add(seededEscrowSystem);
                dataContext.SaveChanges();
            }
        }

        private void SeedPostions(DataContext dataContext)
        {
            if (!dataContext.Positions.Any())
            {

                var seededPosition = new Position
                {
                    Salary = 10000,
                    Name = "Adminsitrator"
                };

                dataContext.Positions.Add(seededPosition);
                dataContext.SaveChanges();
            }
        }

        public void SeedUsers(DataContext dataContext)
        {
            var numUsers = dataContext.Users.Count();

            if (numUsers == 0)
            {
                var seededSocial = new Social
                {
                    Notifications = 2,
                    Reminders = 1,
                    PostId = 1,

                };
                dataContext.Socials.Add(seededSocial);

                var seededPosts = new Post
                {
                    CreatedAt = DateTimeOffset.Now,
                    CommentId = 1,
                };
                dataContext.Posts.Add(seededPosts);

                var seededComments = new Comment
                {
                    CreatedAt = DateTimeOffset.Now,
                    CommentText = "Gamble & Give Me Your Money!"
                };
                dataContext.Comments.Add(seededComments);

                var seededUser = new User
                {
                    FirstName = "Admin",
                    LastName = "Admin",
                    Username = "Admin",
                    Password = "password",
                    AccountBalance = 10000,
                    Email = "admin@admin.aol",
                    PhoneNumber = "219-455-2855",
                    DateOfBirth = DateTimeOffset.Now,
                };
                dataContext.Users.Add(seededUser);
                dataContext.SaveChanges();
            }
        }
        public void SeedEmployees(DataContext dataContext)
        {
            if (!dataContext.Employees.Any())
            {
                var position = dataContext.Positions.FirstOrDefault();
                var user = dataContext.Users.FirstOrDefault();
                var seededEmployee = new Employee
                {
                    Salary = 10000,
                    Employed = true,
                    User = user,
                    Position = position
                };

                dataContext.Employees.Add(seededEmployee);
                dataContext.SaveChanges();
            }
        }

        public void SeedSocials(DataContext dataContext)
        {
            if (!dataContext.Socials.Any())
            {
                var seededPosts = new Post
                {
                    CreatedAt = DateTimeOffset.Now,
                    CommentId = dataContext.Comments.FirstOrDefault().Id,
                };
                dataContext.Posts.Add(seededPosts);

                var seededComments = new Comment
                {
                    CreatedAt = DateTimeOffset.Now,
                    CommentText = "Gamble & Give Me Your Money!"
                };
                dataContext.Comments.Add(seededComments);

                var seededSocial = new Social
                {
                    Notifications = 2,
                    Reminders = 1,
                    PostId = dataContext.Posts.FirstOrDefault().Id,

                };
                dataContext.Socials.Add(seededSocial);
                dataContext.SaveChanges();
            }


        }

        public void SeedPosts(DataContext dataContext)
        {
            if (!dataContext.Posts.Any())
            {
                var seededComments = new Comment
                {
                    CreatedAt = DateTimeOffset.Now,
                    CommentText = "Gamble & Give Me Your Money!"
                };
                dataContext.Comments.Add(seededComments);

                var seededPosts = new Post
                {
                    CreatedAt = DateTimeOffset.Now,
                    CommentId = dataContext.Comments.FirstOrDefault().Id,
                };
                dataContext.Posts.Add(seededPosts);
                dataContext.SaveChanges();
            }
        }

        public void SeedComments(DataContext dataContext)
        {
            if (!dataContext.Comments.Any())
            {
                var seededComments = new Comment
                {
                    CreatedAt = DateTimeOffset.Now,
                    CommentText = "Gamble & Give Me Your Money!"
                };
                dataContext.Comments.Add(seededComments);
                dataContext.SaveChanges();
            }
        }
       
        public void SeedBetCategories(DataContext dataContext)
        {
            if (!dataContext.BetCategories.Any())
            {
                var seededBetCategories = new BetCategory()
                {
                    Name = "Sports"
                };
                dataContext.BetCategories.Add(seededBetCategories);
                dataContext.SaveChanges();
            }
        }

        public void SeedTransactionUsers(DataContext dataContext)
        {
            if (!dataContext.TransactionsUsers.Any())
            {


                var seededTransactionUsers = new TransactionsUser()
                {
                    Amount = 500,
                    TransactionsId = dataContext.Transactions.FirstOrDefault().Id,
                    UserId = dataContext.Users.FirstOrDefault().Id,
                };
                dataContext.TransactionsUsers.Add(seededTransactionUsers);
                dataContext.SaveChanges();


            }
        }


        public void SeedEscroSystems(DataContext dataContext)
        {
            if (!dataContext.EscrowSystems.Any())
            {
                var seededEscroSystems = new EscrowSystem()
                {
                    PaymentType = "Debit",
                    CreatedDate = DateTimeOffset.Now,
                    ClosedDate = DateTimeOffset.Now,
                    DispersalCompletionDate = DateTimeOffset.Now,
                    EscrowPayout = 20

                };
                dataContext.EscrowSystems.Add(seededEscroSystems);
                dataContext.SaveChanges();
            };
        }

        public void SeedHouseSystems(DataContext dataContext)
        {
            if (!dataContext.HouseSystems.Any())
            {
                var seededHouseSystems = new HouseSystem()
                {
                    Payout = 20,
                    BetPercentage = 3,
                };
                dataContext.HouseSystems.Add(seededHouseSystems);
                dataContext.SaveChanges();
            }
        }

        public void SeedTransactions(DataContext dataContext)
        {
            if (!dataContext.Transactions.Any())
            {
                var seededTransactions = new Transaction()
                {
                    Amount = 500,
                    PaymentType = "Credit",
                    CreatedAt = DateTimeOffset.Now,
                };

                dataContext.Add(seededTransactions);
                dataContext.SaveChanges();
            }
        }

        public void SeedBets(DataContext dataContext)
        {
            if (!dataContext.Bets.Any())
            {


                var seededBets = new Bet()
                {
                    Name = "Bet",
                    BetCategoryId = dataContext.BetCategories.FirstOrDefault().Id,
                    CreatedDate = DateTimeOffset.Now,
                    ClosedDate = DateTimeOffset.Now,
                    CommentId = dataContext.Comments.FirstOrDefault().Id,
                    BetDisputeCall = false,
                    EscrowSystemId = dataContext.EscrowSystems.FirstOrDefault().Id

                };
                dataContext.Bets.Add(seededBets);
                dataContext.SaveChanges();

            }
        }


        public void SeedBetTransactions(DataContext dataContext)
        {

            if (!dataContext.BetTransactions.Any())
            {

                var seededBetTransactions = new BetTransaction()
                {
                    BetId = dataContext.Bets.FirstOrDefault().Id,
                    CreatedDate = DateTimeOffset.Now,
                    FinishedAt = DateTimeOffset.Now,
                    Amount = 100,
                    Result = "Fail",
                    HouseSystemId = dataContext.HouseSystems.FirstOrDefault().Id,
                    UserId = dataContext.Users.FirstOrDefault().Id,
                    EmployeeId = dataContext.Employees.FirstOrDefault().Id,
                    TransactionId = dataContext.Transactions.FirstOrDefault().Id
                };
                dataContext.BetTransactions.Add(seededBetTransactions);

                dataContext.SaveChanges();
            }
        }
    }
}