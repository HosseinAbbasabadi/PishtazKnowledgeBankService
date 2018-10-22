namespace Framework.Identity
{
    public class Permission
    {
        public long Code { get; set; }
        public string Name { get; set; }

        public Permission(long code, string name)
        {
            Code = code;
            Name = name;
        }
    }
}