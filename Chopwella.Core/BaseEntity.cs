using System.ComponentModel.DataAnnotations;

namespace Chopwella.Core
{
    public class BaseEntity
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
