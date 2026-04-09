using FullStack2._0.Data;

namespace FullStack2._0.Models
{
    public class UserLikedProduct
    {
        public string UserId { get; set; } = null!;
        public int ProductId { get; set; }

        public ApplicationUser User { get; set; } = null!;
        public Product Product { get; set; } = null!;
    }
}
