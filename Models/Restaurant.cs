using System.ComponentModel.DataAnnotations;

namespace SampleASPCore.Models
{
    public class Restaurant
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Field Name harus diisi")]
        //[RegularExpression(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$",ErrorMessage ="Format email tidak sesuai")]
        public string Name { get; set; }
    }
}