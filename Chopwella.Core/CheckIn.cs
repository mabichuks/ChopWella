using System;

namespace Chopwella.Core
{
    public class CheckIn
    {
        public virtual Staff Staff { get; set; }
        public int StaffId { get; set; }
        public bool IsChecked { get; set; }
        public DateTime DateTime { get; set; }
    }
}
