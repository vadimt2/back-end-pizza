using Common;
using Common.Interfaces;
using System.Threading.Tasks;

namespace Infrastructure
{
    public interface IUnitOfWork
    {
        IRepository<User> UserRepo { get;  }

        IRepository<Role> RoleRepo { get; }

        IRepository<Category> CategoryRepo { get; }

        IRepository<CategoryItems> CatItemsRepo { get; }

        IRepository<Item> ItemRepo { get; }

        IRepository<Image> ImageRepo { get; }

        IRepository<IImage> ImgItemRpo{ get; }

        IRepository<Shipping> ShippingRepo { get; }

        IRepository<Order> OrderRepo { get; }

        IRepository<BellingAndShippInfo> BellingAndShippInfoRepo { get; }

        IRepository<OrderDetails> OrderDetailsRepo { get; }




    }
}
