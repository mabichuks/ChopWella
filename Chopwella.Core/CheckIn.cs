using System;
using System.ComponentModel.DataAnnotations;

namespace Chopwella.Core
{
    public class CheckIn
    {
        public virtual Staff Staff { get; set; }
        public int StaffId { get; set; }
        public bool IsChecked { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        [Required]
        public virtual Vendor Vendor { get; set; }
        public int VendorId { get; set; }
    }
}
