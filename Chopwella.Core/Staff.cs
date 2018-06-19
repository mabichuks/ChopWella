namespace Chopwella.Core
{
    public class Staff : BaseEntity
    {
        public string Email { get; set; }
        public virtual Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
