using System.ComponentModel.DataAnnotations;

namespace DesignProject.Models
{
    public class LoginUserDto
    {
        [Required(ErrorMessage = "Kullanıcı Adını Giriniz.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Şifrenizi Giriniz.")]
        public string Password { get; set; }
    }
}
