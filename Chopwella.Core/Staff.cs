using System.ComponentModel.DataAnnotations;

namespace Chopwella.Core
{
    public class Staff : BaseEntity
    {
        public string StaffId { get; set; }
        [Required(ErrorMessage = "Email is Required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public virtual Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
