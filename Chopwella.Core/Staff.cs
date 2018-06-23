namespace Chopwella.Core
{
    public class Staff : BaseEntity
    {
        public string StaffId { get; set; }
        public string Email { get; set; }
        public virtual Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
