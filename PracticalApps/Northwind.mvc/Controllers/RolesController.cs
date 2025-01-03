using Microsoft.AspNetCore.Identity; // RoleManager, UserManager
using static System.Console;
using Microsoft.AspNetCore.Mvc; // Controller, IActionResult

namespace Northwind.mvc.Controllers
{
    public class  RolesController : Controller
    {
        private string AdminRole = "Administrators";
        private string UserEmail  = "brunosrc@hotmail.com";
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<IdentityUser> userManager;

        public  RolesController(RoleManager<IdentityRole> roleManager, 
            UserManager<IdentityUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public async Task<ActionResult> Index(){
            if (!await roleManager.RoleExistsAsync(AdminRole))
            {
                await roleManager.CreateAsync(new IdentityRole(AdminRole));
            }
            IdentityUser user = await userManager.FindByEmailAsync(UserEmail);
            if (user == null){
                user = new();
                user.UserName = UserEmail;
                IdentityResult result = await userManager.CreateAsync(user, 
                    "Pa$$w0rd");
                if (result.Succeeded)
                {
                    WriteLine($"User {user.UserName} created successfully" );
                }else{
                    foreach (IdentityError error in result.Errors)
                    {
                        WriteLine(error.Description);
                    }
                }
            }
            if(!user.EmailConfirmed){
                string token = await userManager.
                    GenerateEmailConfirmationTokenAsync(user);
                IdentityResult result = await userManager.ConfirmEmailAsync(user, token);

                if (result.Succeeded){
                    WriteLine($"User {user.UserName} email cofirmed succesfully.");
                }else{
                    foreach (IdentityError error in result.Errors)
                    {
                        WriteLine(error.Description);
                    }
                }
            }
            if(!(await userManager.IsInRoleAsync(user, AdminRole))){
                IdentityResult result = await userManager.
                    AddToRoleAsync(user, AdminRole);
                if (result.Succeeded)
                {
                    WriteLine($"User {user.UserName} added to {AdminRole} successfully.");                    
                }else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        WriteLine(error.Description);
                    }
                }
            }
            return Redirect("/");

        }
    }
}