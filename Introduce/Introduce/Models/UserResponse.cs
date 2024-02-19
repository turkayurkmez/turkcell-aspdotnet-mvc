using System.ComponentModel.DataAnnotations;

namespace Introduce.Models
{
    public class UserResponse
    {
        [Required(ErrorMessage = "Lütfen adınızı girmeyi unutmayın")]
        [MinLength(2, ErrorMessage = "En az iki harf olmalı!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Lütfen epostanızı girmeyi unutmayın")]
        [EmailAddress(ErrorMessage = "Bu ne biçim eposta?")]
        public string Email { get; set; }
        public bool? IsParticipate { get; set; }

    }
}
