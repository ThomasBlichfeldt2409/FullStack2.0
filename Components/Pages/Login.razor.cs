namespace FullStack2._0.Components.Pages
{
    public partial class Login
    {
        protected string email = "";
        protected string password = "";
        protected string? errorMessage;

        protected async Task HandleLogin()
        {
            errorMessage = "Du kan ikke logge på endnu";
        }
    }
}
