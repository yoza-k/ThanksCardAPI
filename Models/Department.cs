using System.Collections.Generic;

namespace ThanksCardAPI.Models
{
    public class Department
    {
        public long Id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }

        // 1対多: Department エンティティには複数の User エンティティが属する
        public virtual ICollection<User> Users { get; set; }
    }
}
