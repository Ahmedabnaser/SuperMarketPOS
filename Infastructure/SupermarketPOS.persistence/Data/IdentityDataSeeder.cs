using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SupermarketPOS.Domain.Entites;
using SupermarketPOS.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketPOS.persistence.Data
{
    public   class IdentityDataSeeder
    {
        private readonly UserManager<ApplicationUser> usermanger;
        private readonly RoleManager<ApplicationRole> rolemanager;
        private readonly ILogger<IdentityDataSeeder> logger;

        public IdentityDataSeeder(UserManager<ApplicationUser> usermanger, RoleManager<ApplicationRole> rolemanager,ILogger<IdentityDataSeeder> logger)
        {
            this.usermanger = usermanger;
            this.rolemanager = rolemanager;
            this.logger = logger;
            this.rolemanager = rolemanager;
            this.usermanger = usermanger;
        }

        public   async Task SeedRolseAndAdminsAsync(IServiceProvider serviceProvider)
        {
            logger.LogInformation("Starting identity seeding: roles and admin (Idempotent)");
            try
            {
                var roles = new List<ApplicationRole>
                {
                   new ApplicationRole("Cashier"){Description = "Can process sales and manage transactions."},
                   new ApplicationRole("Admin"){Description="Full access to all system features."},
                   new ApplicationRole("Manager"){Description="Can view reports and manage staff."}
                };

                // ensure roles exist
                foreach (var role in roles)
                {
                    var roleName = role.Name ?? string.Empty;
                    logger.LogDebug("Checking role '{RoleName}'", roleName);
                    if (!await rolemanager.RoleExistsAsync(roleName))
                    {
                        logger.LogInformation("Creating role '{RoleName}'", roleName);
                        var createRoleResult = await rolemanager.CreateAsync(new ApplicationRole(roleName) { Description = role.Description });
                        if (!createRoleResult.Succeeded)
                        {
                            var errors = string.Join(",", createRoleResult.Errors.Select(e => e.Description));
                            logger.LogError("Failed to create role '{RoleName}': {Errors}", roleName, errors);
                        }
                        else
                        {
                            logger.LogInformation("Role '{RoleName}' created successfully", roleName);
                        }
                    }
                    else
                    {
                        logger.LogDebug("Role '{RoleName}' already exists", roleName);
                    }
                }

                var adminEmail = "Admin@gmail.com";
                var adminPassword = "Admin402@gmail.com";
                logger.LogDebug("Checking for existing admin user with email {Email}", adminEmail);
                var existAdmin = await usermanger.FindByEmailAsync(adminEmail);
                if (existAdmin == null)
                {
                    logger.LogInformation("Creating default admin user {Email}", adminEmail);
                    var Adminuser = new ApplicationUser
                    {
                        FirstName = "Ahmed",
                        LastName = "Abdelnaser",
                        Email = adminEmail,
                        UserName = "Ahmedabnaser",
                        NormalizedUserName = "AHMEDABNASER",
                        PhoneNumber = "01067755402",
                        EmailConfirmed = true,
                    };

                    var result = await usermanger.CreateAsync(Adminuser, adminPassword);
                    if (result.Succeeded)
                    {
                        await usermanger.AddToRoleAsync(Adminuser, "Admin");
                        logger.LogInformation("Admin user {Email} created and assigned to role 'Admin'", adminEmail);
                    }
                    else
                    {
                        var errors = string.Join(",", result.Errors.Select(e => e.Description));
                        logger.LogError("Failed to create admin user {Email}: {Errors}", adminEmail, errors);
                        throw new Exception("Failed To Create The AdminUser: " + errors);
                    }
                }
                else
                {
                    logger.LogInformation("Admin user with email {Email} already exists (Id: {Id})", adminEmail, existAdmin.Id);
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An exception occurred while seeding roles and admin");
                throw;
            }
            finally
            {
                logger.LogInformation("Finished identity seeding");
            }
        }
        public async Task SeedStaff()
        {
            logger.LogInformation("Preparing branch seed data (no DB operations performed by this method)");
            var Branches = new List<Branch>
            {
                new Branch
                {
                    Name = "Tanta Branch",
                    Address = "123 Main St, Cityville",
                    Phone = "123-456-7890",
                    Email = "TantaBranch@supermarket.test",
                    City = "Tanta"

                },
                new Branch
                {
                    Name = "Cairo Branch",
                    Address = "123 Othman Street",
                    Phone = "123-456-7890",
                    Email = "CairoBranch@supermarket.test",
                    City = "Cairo",
                }
            };

            foreach (var b in Branches)
            {
                logger.LogInformation("Prepared branch seed: {Name} ({City})", b.Name, b.City);
            }

            // NOTE: this method currently only prepares branch objects and logs them.
            // Implement adding to the database (via ApplicationDbContext or repository/unit-of-work)
            // when the repository pattern is available.

            await Task.CompletedTask;
        }
    }
}
