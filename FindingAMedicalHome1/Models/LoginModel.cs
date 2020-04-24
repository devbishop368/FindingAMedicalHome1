using System.ComponentModel.DataAnnotations;

namespace FindingAMedicalHome1.Models
{
    public class LoginModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required.")]
        public string Username { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required.")]
        public string Password { get; set; }
    }
}