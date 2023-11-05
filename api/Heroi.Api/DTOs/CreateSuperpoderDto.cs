using System.ComponentModel.DataAnnotations;

namespace Heroi.Api.DTOs
{
    public class CreateSuperpoderDto
    {
        [Required(ErrorMessage = "Informe 1 ou mais superpoderes")]
        public int SuperpoderId { get; set; }
    }
}
