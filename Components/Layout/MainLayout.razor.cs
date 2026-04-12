using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using FullStack2._0.Services.Interfaces;
using FullStack2._0.Data;
using FullStack2._0.Enums;

namespace FullStack2._0.Components.Layout
{
    public partial class MainLayout
    {
        [Inject] protected NavigationManager Nav { get; set; } = default!;
        [Inject] protected IOrderService OrderService { get; set; } = default!;
        [Inject] protected ICartService CartService { get; set; } = default!;
        [Inject] protected AuthenticationStateProvider AuthStateProvider { get; set; } = default!;
        [Inject] protected UserManager<ApplicationUser> UserManager { get; set; } = default!;

        protected int orderCount;
        protected int cartCount => CartService.GetItems().Count;
        protected string userDisplay = "Gæst";

        protected void GoToAdminProducts() => Nav.NavigateTo("/");
        protected void GoToAdminOrders() => Nav.NavigateTo("/");
        protected void GoToLogin() => Nav.NavigateTo("/login");

        protected void GoToCart() => Nav.NavigateTo("/");

        protected override async Task OnInitializedAsync()
        {
            await RefreshOrderCount();
        }

        protected async Task RefreshOrderCount()
        {
            orderCount = await OrderService.GetCountByStatusAsync(OrderStatus.Requested);
        }
    }
}
