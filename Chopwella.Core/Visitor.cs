namespace Chopwella.Core
{
    public class Visitor : BaseEntity
    {
        public virtual Staff Staff { get; set; }
        public int StaffId { get; set; }
    }
}
