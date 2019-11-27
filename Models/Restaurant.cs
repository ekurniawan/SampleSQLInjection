using System.ComponentModel.DataAnnotations;

namespace SampleASPCore.Models
{
    public class Restaurant
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Field Name harus diisi")]
        public string Name { get; set; }
    }
}