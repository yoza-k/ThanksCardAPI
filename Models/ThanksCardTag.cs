#nullable disable
namespace ThanksCardAPI.Models
{
    public class ThanksCardTag
    {
        public long Id { get; set; }
        public long ThanksCardId { get; set; }
        public ThanksCard ThanksCard { get; set; }
        public long TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
