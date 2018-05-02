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

        public IEnumerable<GetMovementDto> GetAll()
        {
            var getAll = _movementManager.GetAllList().ToList();
            var movementList = new List<GetMovementDto>();

            foreach (var movement in getAll)
            {
                var move = new GetMovementDto();
                move.Id = movement.Id;
                move.Product = movement.Product.Name;
                move.User = movement.User.FullName;
                move.PreviousQtd = movement.PreviousQtd;
                move.CurrentQtd = movement.CurrentQtd;
                move.Signal = movement.Signal;

                movementList.Add(move);
            }

            return movementList;
        }

        public async Task Create(CreateMovementDto input)
        {
            var userId = 1;

            if (AbpSession.UserId != null)
            {
                userId = unchecked((int)AbpSession.UserId);
            }

            User user = await _userManager.FindByIdAsync(userId);
            Product product = _productManager.GetProductByID(input.Product);
            input.PreviousQtd = product.Stock;
            input.CurrentQtd = input.Quantity;

            if (input.CurrentQtd < 0)
            {
                throw new UserFriendlyException("A quantidade a ser retirada deve ser menor ou igual ao estoque deste produto!");
            }

            product.Stock = input.CurrentQtd;
            _productManager.Update(product);

            var saveInput = new Movement();
            
            saveInput.Product = product;
            saveInput.User = user;
            saveInput.PreviousQtd = input.PreviousQtd;
            saveInput.CurrentQtd = input.CurrentQtd;

            if (saveInput.PreviousQtd < saveInput.CurrentQtd)
            {
                saveInput.Signal = "+";
            }

            else if (saveInput.PreviousQtd > saveInput.CurrentQtd)
            {
                saveInput.Signal = "-";
            }

            else
            {
                saveInput.Signal = "=";
            }

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
