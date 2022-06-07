#nullable disable
namespace ThanksCardAPI.Models
{
    public class ThanksCard
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public long FromId { get; set; }
        public virtual User From { get; set; }
        public long ToId { get; set; }
        public virtual User To { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public long  TagId {get; set;}
        public virtual Tag Tag { get; set; }

        public virtual ICollection<Good> Goods { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
