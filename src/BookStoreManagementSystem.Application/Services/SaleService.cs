using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using BookStoreManagementSystem.Application.Mapper;
using BookStoreManagementSystem.Domain.Model;
using BookStoreManagementSystem.Interfaces;
using BookStoreManagementSystem.Interfaces.Repository;
using BookStoreManagementSystem.Interfaces.ViewModel;

namespace BookStoreManagementSystem.Application.Services
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _repository;

        public SaleService(ISaleRepository repository)
        {
            _repository = repository;
        }

        public SaleViewModel Add(SaleViewModel viewModel)
        {
            try
            {
                viewModel.Id = Guid.NewGuid();
                viewModel.InvoiceDate = DateTime.Now.Date;
                viewModel.InvoiceNumber = $"INV-{DateTime.Now.Year}+{DateTime.Now.Month}+{DateTime.Now.Day}+{DateTime.Now.Hour}+{DateTime.Now.Minute}+{DateTime.Now.Second}";
                _repository.Add(SaleMapper.ToDbModel(viewModel));
                return viewModel;
            }
            catch (Exception e)
            {
                return new SaleViewModel();
            };
        }

        public void Delete(Guid id)
        {
            _repository.Delete(id);
        }

        public SaleViewModel GetSaleByCustomerId(Guid customerId)
        {
            var data = _repository.GetSaleByCustomerId(customerId);
            return data == null ? null : SaleMapper.ToViewModel(data);
        }

        public SaleListViewModel GetSaleByDate(DateTime invoiceDate)
        {
            var returnList = new SaleListViewModel();
            returnList.Sales = new List<SaleViewModel>();
            var data = _repository.GetSaleByDate(invoiceDate);
            foreach (var item in data)
            {
                returnList.Sales.Add(SaleMapper.ToViewModel(item));
            }
            return returnList;
        }

        public SaleViewModel GetSaleById(Guid id)
        {
            var data = _repository.GetSaleById(id);
            return data == null ? null : SaleMapper.ToViewModel(data);
        }

        public SaleViewModel GetSaleByInvoiceNo(string invoiceNo)
        {
            var data = _repository.GetSaleByInvoiceNo(invoiceNo);
            return data == null ? null : SaleMapper.ToViewModel(data);
        }

        public SaleListViewModel GetSales()
        {
            var returnList = new SaleListViewModel();
            returnList.Sales = new List<SaleViewModel>();
            var data = _repository.GetSales();
            foreach (var item in data)
            {
                returnList.Sales.Add(SaleMapper.ToViewModel(item));
            }
            return returnList;
        }

        public SaleViewModel Update(SaleViewModel viewModel)
        {
            try
            {
                _repository.Update(SaleMapper.ToDbModel(viewModel));
                return viewModel;
            }
            catch (Exception e)
            {
                return new SaleViewModel();
            }
        }

        public SaleViewModel CalculateAmount(SaleViewModel viewModel)
        {
            try
            {

                viewModel.Amount = (viewModel.SellingPrice * viewModel.Quantity) - viewModel.Discount;
                return viewModel;
            }
            catch (Exception e)
            {
                return new SaleViewModel();
            }
        }
    }
}
