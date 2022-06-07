#nullable disable
namespace ThanksCardAPI.Models
{
    public class User
    {
        public long Id { get; set; }
        public long Cd { get; set; }
        public string Name { get; set; }
        public string KanaName { get; set; }
        public long Password { get; set; }

        // 多対1: User エンティティは1つの Department エンティティに属する
        public long? DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}
