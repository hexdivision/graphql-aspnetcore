using System;

namespace PathWays.Data.Model.Base
{
    public abstract class BaseEntity
    {
        public DateTime? CreatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? ModifiedBy { get; set; }
    }
}
