using Common;
using Common.Interfaces;
using Infrastructure;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppContext _appContext;

        private IRepository<User> _userRepo;
        private IRepository<Role> _roleRepo;
        private IRepository<Category> _categoryRepo;
        private IRepository<CategoryItems> _catItemsRepo;
        private IRepository<Item> _itemRepo;
        private IRepository<Image> _imageRepo;
        private IRepository<IImage> _imgItemRpo;
        private IRepository<Shipping> _shippingRepo;
        private IRepository<Order> _orderRepo;
        private IRepository<BellingAndShippInfo> _bellingAndShippInfoRepo;
        private IRepository<OrderDetails> _orderDetailsRepo;




        public UnitOfWork(AppContext appContext)
        {
            _appContext = appContext;
        }

        public IRepository<User> UserRepo 
        {
            get
            {
                if(_userRepo == null)
                    _userRepo = new Repository<User>(_appContext);

                return _userRepo;
            } 
        }

        public IRepository<Role> RoleRepo
        {
            get
            {
                if (_roleRepo == null)
                    _roleRepo = new Repository<Role>(_appContext);

                return _roleRepo;
            }
        }

        public IRepository<Category> CategoryRepo
        {
            get
            {
                if (_categoryRepo == null)
                    _categoryRepo = new Repository<Category>(_appContext);

                return _categoryRepo;
            }
        }


        public IRepository<CategoryItems> CatItemsRepo
        {
            get
            {
                if (_catItemsRepo == null)
                    _catItemsRepo = new Repository<CategoryItems>(_appContext);

                return _catItemsRepo;
            }
        }

        public IRepository<Item> ItemRepo
        {
            get
            {
                if (_itemRepo == null)
                    _itemRepo = new Repository<Item>(_appContext);

                return _itemRepo;
            }
        }

        public IRepository<Image> ImageRepo
        {
            get
            {
                if (_imageRepo == null)
                    _imageRepo = new Repository<Image>(_appContext);

                return _imageRepo;
            }
        }

        public IRepository<IImage> ImgItemRpo
        {
            get
            {
                if (_imgItemRpo == null)
                    _imgItemRpo = new Repository<IImage>(_appContext);

                return _imgItemRpo;
            }
        }

        public IRepository<Shipping> ShippingRepo
        {
            get
            {
                if (_shippingRepo == null)
                    _shippingRepo = new Repository<Shipping>(_appContext);

                return _shippingRepo;
            }
        }

        public IRepository<Order> OrderRepo
        {
            get
            {
                if (_orderRepo == null)
                    _orderRepo = new Repository<Order>(_appContext);

                return _orderRepo;
            }
        }

        public IRepository<BellingAndShippInfo> BellingAndShippInfoRepo
        {
            get
            {
                if (_bellingAndShippInfoRepo == null)
                    _bellingAndShippInfoRepo = new Repository<BellingAndShippInfo>(_appContext);

                return _bellingAndShippInfoRepo;
            }
        }

        public IRepository<OrderDetails> OrderDetailsRepo
        {
            get
            {
                if (_orderDetailsRepo == null)
                    _orderDetailsRepo = new Repository<OrderDetails>(_appContext);

                return _orderDetailsRepo;
            }
        }

    }

   }

