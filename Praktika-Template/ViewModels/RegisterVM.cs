using System.ComponentModel.DataAnnotations;

namespace Praktika_Template.ViewModels
{
    public class RegisterVM
    {
        [Required, StringLength(maximumLength: 20)]
        public string Firstname { get; set; }
        [Required, StringLength(maximumLength: 20)]
        public string Lastname { get; set; }
        [Required, StringLength(maximumLength: 20)]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [Required, DataType(DataType.Password),Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

        public bool IHaveReadIAccept { get; set; }

    }
}
