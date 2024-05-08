namespace DoListMVC.Models.ViewModels
{
    public class AccountViewModel
    {
        public int Id { get; set; }

        public string? AccName { get; set; }

        public string? Name { get; set; }

        public string? LastName { get; set; }

        public string? PasswordHash { get; set; }

        public string? Salt { get; set; }

        public bool IsAdmin { get; set; }

        public int AccountModelId { get; set; }
    }
}
