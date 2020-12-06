using System.ComponentModel.DataAnnotations;

namespace ASPNETCore5Demo.Models
{
    public partial class CourseUpdateModel
    {

        [Required]
        [StringLength(30, ErrorMessage = "Title 太長")]
        public string Title { get; set; }
        public int Credits { get; set; }
    }
}