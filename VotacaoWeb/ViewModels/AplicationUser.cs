using Microsoft.AspNetCore.Identity;

namespace VotacaoWeb.ViewModels
{
    public class ApplicationUser : IdentityUser
    {
        public string NomeCompleto { get; set; }
    }
}