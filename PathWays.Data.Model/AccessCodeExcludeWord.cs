using System.ComponentModel.DataAnnotations;
using PathWays.Data.Model.Base;

namespace PathWays.Data.Model
{
    public class AccessCodeExcludeWord
    {
        public int AccessCodeExcludeWordId { get; set; }

        [StringLength(6)]
        public string ExcludeWord { get; set; }
    }
}
