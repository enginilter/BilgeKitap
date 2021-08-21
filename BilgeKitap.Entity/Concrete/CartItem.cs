namespace BilgeKitap.Entity.Concrete
{
    public class CartItem
    {
        public int CartItemId { get; set; }
        public virtual Book Book { get; set; }
        public int BookId { get; set; }
        public virtual Cart Cart { get; set; }
        public int CartId { get; set; }
        public int Quantity { get; set; }
    }
}