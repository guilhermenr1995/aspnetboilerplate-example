using Abp.Application.Services;
using Abp.Domain.Repositories;
using AutoMapper;
using SoiticTest.Models;
using SoiticTest.Movements.Dto;
using SoiticTest.Products.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Core.Logging;
using Abp.UI;
using SoiticTest.Authorization.Users;

namespace SoiticTest.Movements
{
    public class MovementAppService : ApplicationService, IMovementAppService
    {
        private readonly IMovementManager _movementManager;
        private readonly IRepository<Product> _productRepository;
        private readonly ProductManager _productManager;
        private readonly UserManager _userManager;

        public new ILogger Logger { get; set; }

        public MovementAppService(
            IMovementManager movementManager,
            IRepository<Product> productRepository,
            ProductManager productManager,
            UserManager userManager)
        {
            _movementManager = movementManager;
            _productRepository = productRepository;
            _productManager = productManager;
            _userManager = userManager;

            Logger = NullLogger.Instance;
        }

        public virtual IEnumerable<GetMovementDto> GetAll()
        {
            var getAll = _movementManager.GetAllList().ToList();

            Logger.Error("MOSTRARRRRR " + getAll.Count);

            var mapped = Mapper.Map<IEnumerable<Movement>, List<GetMovementDto>>(getAll);
            return mapped;
        }

        public async Task Create(CreateMovementDto input)
        {
            var userId = 1;

            if (AbpSession.UserId != null)
            {
                userId = unchecked((int)AbpSession.UserId);
            }

            Product product = _productManager.GetProductByID(input.Product);
            input.Signal = "-";
            input.PreviousQtd = product.Stock;
            input.CurrentQtd = (product.Stock - input.Quantity);

            if (input.CurrentQtd < 0)
            {
                throw new UserFriendlyException("A quantidade a ser retirada deve ser menor ou igual ao estoque deste produto!");
            }

            product.Stock = input.CurrentQtd;
            _productManager.Update(product);

            var saveInput = new Movement();
            
            saveInput.Product = product;
            saveInput.User = await _userManager.FindByIdAsync(userId);
            saveInput.PreviousQtd = input.PreviousQtd;
            saveInput.CurrentQtd = input.CurrentQtd;
            saveInput.Signal = "-";

            await _movementManager.Create(saveInput);
        }

        public void Update(GetMovementDto input)
        {
            Movement movement = Mapper.Map<GetMovementDto, Movement>(input);
            _movementManager.Update(movement);
        }

        public void Delete(GetMovementDto input)
        {
            _movementManager.Delete(input.Id);
        }

        public GetMovementDto GetById(GetMovementDto input)
        {
            var getMovement = _movementManager.GetMovementByID(input.Id);
            GetMovementDto movement = Mapper.Map<Movement, GetMovementDto>(getMovement);
            return movement;
        }

        public IEnumerable<ProductDto> GetProducts()
        {
            var getAll = _productManager.GetAllList().ToList();
            List<ProductDto> products = Mapper.Map<List<Product>, List<ProductDto>>(getAll);
            return products;
        }
    }
}
