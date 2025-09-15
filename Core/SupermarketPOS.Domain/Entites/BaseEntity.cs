
namespace SupermarketPOS.Domain.Entites
{
    public class BaseEntity
    {
        public int Id { get; private set; }
        public bool IsDeleted { get; private set; }

        public DateTime? DeletedOnUtc { get; private set; }

        public void Delete()
        {
            IsDeleted = true;
            DeletedOnUtc = DateTime.UtcNow;
        }

        public void Restore()
        {
            IsDeleted = false;
            DeletedOnUtc = null;
        }
    }
}
