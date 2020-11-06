using eShop.CoreBusiness.Models;
using eShop.CoreBusiness.PluginInterfaces.DataStore;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace eShop.UseCases.SearchProductScreen
{
    public class SearchProductUseCase : ISearchProductUseCase
    {
        private readonly IProductRepository _ProductRepository;

        public SearchProductUseCase(IProductRepository productRepository)
        {
            _ProductRepository = productRepository;
        }

        public IEnumerable<Product> Execute(string filter)
        {
            return _ProductRepository.GetProducts(filter);
        }
    }
}