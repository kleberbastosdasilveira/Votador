using Microsoft.AspNetCore.Identity;

namespace VotacaoAPI.ViewModels
{
    public class ApplicationUser : IdentityUser
    {
        public string NomeCompleto { get; set; }
    }
}