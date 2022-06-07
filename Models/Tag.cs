#nullable disable
namespace ThanksCardAPI.Models
{
    public class Tag
    {
        public long Id { get; set; }
        public long Cd { get; set; }
        public string Name { get; set; }

        // 1対多: Category エンティティには複数の Card エンティティが属する
        public virtual ICollection<ThanksCard> ThanksCards { get; set; }
    }
}
