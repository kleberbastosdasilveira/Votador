using Microsoft.AspNetCore.Identity;

namespace VotadorWeb.ViewModels
{
    public class ApplicationUser : IdentityUser
    {
        public string NomeCompleto { get; set; }
    }
}