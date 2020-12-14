using System.ComponentModel.DataAnnotations;

namespace shopapp.ui.Model
{
    public class LoginModel
    {
        [Required]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}