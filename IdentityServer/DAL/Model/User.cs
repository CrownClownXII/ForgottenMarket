namespace IdentityServer.DAL.Model
{
    public class User
    {
        public long Id { get; set; }
        public string Login { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}