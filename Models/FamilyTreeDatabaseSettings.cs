namespace WebApi1.Models
{
    public class FamilyTreeDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string Database { get; set; } = null!;
        public string MemberCollectionName { get; set; } = null!;
    }
}
