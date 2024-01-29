using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoAspMvc.Models
{
    [Table ("Usuario")]
    public class Usuario
    {
        [Column ("username")]
        [Display (Name = "Username")]
        public string userName { get; set; }
        [Column ("password")]
        [Display (Name = "Password")]
        public string password { get; set; }

        public bool Authenticate (string enteredUsername, string enteredPassword)
        {
            return userName == enteredUsername && password == enteredPassword;
        }
    }
}
