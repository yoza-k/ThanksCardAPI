#nullable disable
namespace ThanksCardAPI.Models
{
    public class Comment
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public long ThanksCardId { get; set; }
        public virtual ThanksCard ThanksCard { get; set; }
    }
}