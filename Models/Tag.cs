using System.Collections.Generic;

namespace ThanksCardAPI.Models
{
    public class Tag
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ThanksCardTag> ThanksCardTags { get; set; }
    }
}
