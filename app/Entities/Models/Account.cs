namespace app.Entities.Models
{
    public class Account
    {
        public int AccountId { get; set; }

        public string AccountType { get; set; }

        public Owner Type { get; set; }
    }
}