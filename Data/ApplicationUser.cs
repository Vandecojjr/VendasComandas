using Comandas.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace Comandas.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Produto>? Produtos { get; set; }
        public ICollection<Categoria>? Categorias { get; set; }
    }

}
