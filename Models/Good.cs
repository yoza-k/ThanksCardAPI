#nullable disable
namespace ThanksCardAPI.Models
{
    public class Good
    {
        public long Id { get; set; }
        public long ThanksCardId { get; set; }
        public virtual ThanksCard ThanksCard { get; set; }
        public long UserId { get; set; }
        public virtual User User { get; set; }

       
    }
}