using System.ComponentModel.DataAnnotations;

namespace Data.Base
{
    public class AbstractEntity : IEntity
    {
        [Key]
        public long Id { get; set; }
        public DateTime? CreatedTime { get; set; }
        public bool IsNew => Id == 0;
    }
}
