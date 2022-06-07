#nullable disable
namespace ThanksCardAPI.Models
{
    public class Department
    {
        public long Id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }

        // 部と課のような階層構造を実現するために、自己参照(DepartmentエンティティがDepartmentエンティティとリレーションを持つ)を利用する
        // ParentId には親部署のIdが入る
        // Parent には親部署が入る
        // Children には子部署リストが入る
        public long? ParentId { get; set; }
        public virtual Department Parent { get; set; }
        public virtual ICollection<Department> Children { get; set; }

        // 1対多: Department エンティティには複数の User エンティティが属する
        public virtual ICollection<User> Users { get; set; }
    }
}
