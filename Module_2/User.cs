namespace ObuvApp
{
    public class User
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string RoleName { get; set; }

        public string FullName =>
            $"{LastName} {FirstName} {MiddleName}".Trim();
    }
}
