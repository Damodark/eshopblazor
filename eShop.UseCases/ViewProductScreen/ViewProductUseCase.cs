using eShop.CoreBusiness.Models;
using eShop.CoreBusiness.PluginInterfaces.DataStore;
using eShop.UseCases.ViewProductScreen.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.UseCases.ViewProductScreen
{
    public class ViewProductUseCase : IViewProductUseCase
    {
        private readonly IProductRepository _ProductRepository;

        public ViewProductUseCase(IProductRepository productRepository)
        {
            _ProductRepository = productRepository;
        }

        public Product Execute(int id)
        {
            return _ProductRepository.GetProduct(id);
        }
    }
}