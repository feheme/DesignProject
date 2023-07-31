using System.ComponentModel.DataAnnotations;

namespace DesignProject.Models
{
    public class CreateNewUserDto
    {
        [Required(ErrorMessage = "Ad Alanı Boş Geçilemez")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyad Alanı Boş Geçilemez")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Kullanıcı Alanı Boş Geçilemez")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Mail Alanı Boş Geçilemez")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Şifre Alanı Boş Geçilemez")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifre Tekrar Alanı Boş Geçilemez")]
        [Compare("Password", ErrorMessage = "Şifreler Uyuşmuyor")] // doğrulama işlemi
        public string ConfirmPassword { get; set; }
    }
}
