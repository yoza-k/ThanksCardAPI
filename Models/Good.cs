#nullable disable
namespace ThanksCardAPI.Models
{
    public class Good
    {
        public long Id { get; set; }
        public long CardId { get; set; }
        public virtual ThanksCard ThnaksCard { get; set; }
        public long UserId { get; set; }
        public virtual User User { get; set; }

       
    }
}