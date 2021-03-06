﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using AspNetMvc.Services.ECommerce.Bills.Dtos;
using AspNetMvc.Services.ECommerce.Products.Dtos;
using AspNetMvc.Data.Entities;
using AspNetMvc.Data.Enums;
using AspNetMvc.Infrastructure.Interfaces;
using AspNetMvc.Utilities.Dtos;
using AspNetMvc.Data.Entities.ECommerce;

namespace AspNetMvc.Services.ECommerce.Bills
{
    public class BillService : WebServiceBase<Bill, int, BillViewModel>, IBillService
    {
        private readonly IRepository<Bill, int> _orderRepository;
        private readonly IRepository<BillDetail, int> _orderDetailRepository;      
        private readonly IRepository<Product, int> _productRepository;       

        public BillService(IRepository<Bill, int> orderRepository,
            IRepository<BillDetail, int> orderDetailRepository,
            IRepository<Product, int> productRepository,           
            IUnitOfWork unitOfWork) : base(orderRepository, unitOfWork)
        {
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _productRepository = productRepository;
        }

        public override void Add(BillViewModel billVm)
        {
            var order = Mapper.Map<BillViewModel, Bill>(billVm);
            var orderDetails = Mapper.Map<List<BillDetailViewModel>, List<BillDetail>>(billVm.BillDetails);
            foreach(var detail in orderDetails)
            {
                var product = _productRepository.GetById(detail.ProductId);
                detail.Price = product.PromotionPrice ?? product.Price;
            }
            _orderRepository.Add(order);
        }

        public override void Update(BillViewModel billVm)
        {
            var order = _orderRepository.GetById(billVm.Id);
            var newDetails = Mapper.Map<List<BillDetailViewModel>, List<BillDetail>>(billVm.BillDetails);
            //var addedDetails = newDetails.Where(x => x.Id == Guid.Empty).ToList();
            //var updatedDetailVms = newDetails.Where(x => x.Id != Guid.Empty).ToList();
            var addedDetails = newDetails.Where(x => x.Id.ToString() == null).ToList();
            var updatedDetailVms = newDetails.Where(x => x.Id.ToString() != null).ToList();
            var existedDetails = _orderDetailRepository.GetAll().Where(x => x.BillId == billVm.Id);

            List<BillDetail> updatedDetails = new List<BillDetail>();

            foreach (var detailVm in updatedDetailVms)
            {
                var detail = _orderDetailRepository.GetById(detailVm.Id);
                detail.Quantity = detailVm.Quantity;
                detail.ProductId = detailVm.ProductId;
                var product = _productRepository.GetById(detailVm.ProductId);
                detail.Price = product.PromotionPrice ?? product.Price;
                _orderDetailRepository.Update(detail);
                updatedDetails.Add(detail);
            }

            foreach (var detail in addedDetails)
            {
                var product = _productRepository.GetById(detail.ProductId);
                detail.Price = product.PromotionPrice ?? product.Price;
                detail.BillId = order.Id;
                _orderDetailRepository.Add(detail);
            }

            //_orderDetailRepository.Delete(existedDetails.Except(updatedDetails));

            if (order.BillStatus != BillStatus.Completed && billVm.BillStatus == BillStatus.Completed)
            {
                ConfirmBill(order.Id);
            }
            if (order.BillStatus != BillStatus.Cancelled && billVm.BillStatus == BillStatus.Cancelled)
            {
                CancelBill(order.Id);
            }
            order.CustomerName = billVm.CustomerName;
            order.CustomerAddress = billVm.CustomerAddress;
            order.CustomerFacebook = billVm.CustomerFacebook;
            order.CustomerMessage = billVm.CustomerMessage;
            order.CustomerMobile = billVm.CustomerMobile;
            order.BillStatus = billVm.BillStatus;
            order.PaymentMethod = billVm.PaymentMethod;
            order.ShippingFee = billVm.ShippingFee;
            order.Status = billVm.Status;
            _orderRepository.Update(order);
        }

        public override BillViewModel GetById(int billId)
        {
            var bill = _orderRepository.Single(x => x.Id == billId);
            var billVm = Mapper.Map<Bill, BillViewModel>(bill);
            var billDetailVm = _orderDetailRepository.GetAll(x => x.BillId == billId).ProjectTo<BillDetailViewModel>().ToList();
            billVm.BillDetails = billDetailVm;
            return billVm;
        }

        public PagedResult<BillViewModel> GetAllPaging(string startDate, string endDate, string keyword, int pageSize, int page)
        {
            var query = _orderRepository.GetAll();
            if (!string.IsNullOrEmpty(startDate))
            {
                DateTime start = DateTime.ParseExact(startDate, "dd/MM/yyyy", CultureInfo.GetCultureInfo("vi-VN"));
                query = query.Where(x => x.CreatedDate >= start);
            }
            if (!string.IsNullOrEmpty(endDate))
            {
                DateTime end = DateTime.ParseExact(endDate, "dd/MM/yyyy", CultureInfo.GetCultureInfo("vi-VN"));
                query = query.Where(x => x.CreatedDate <= end);
            }
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.CustomerName.Contains(keyword) || x.CustomerMobile.Contains(keyword));
            }
            var totalRow = query.Count();
            var data = query.OrderByDescending(x => x.CreatedDate)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ProjectTo<BillViewModel>()
                .ToList();
            return new PagedResult<BillViewModel>()
            {
                CurrentPage = page,
                PageSize = pageSize,
                Results = data,
                RowCount = totalRow
            };
        }

        public void UpdateStatus(int billId, BillStatus status)
        {
            var order = _orderRepository.GetById(billId);
            order.BillStatus = status;
            _orderRepository.Update(order);
        }     

        public void ConfirmBill(int id)
        {
            //var bill = _orderRepository.FindById(id, i => i.BillDetails);
            var bill = _orderRepository.GetById(id);
            var billDetails = _orderDetailRepository.GetAll().Where(x => x.BillId == id);
            if (bill.BillStatus != BillStatus.Completed)
            {
                bill.BillStatus = BillStatus.Completed;
                foreach (var detail in billDetails)
                {
                    var product = _productRepository.GetById(detail.ProductId);
                    if (product.Quantity >= detail.Quantity)
                    {
                        product.Quantity -= detail.Quantity;
                    }
                    else
                        throw new Exception($"Sản phẩm {product.Name}-{product.Code} không đủ số lượng. Hiện tại chỉ còn {product.Quantity} trong kho.");
                }
            }
            else
            {
                throw new Exception("Đơn hàng này đã được xác nhận trước đó.");
            }
        }

        public void CancelBill(int id)
        {
            var bill = _orderRepository.GetById(id);
            var billDetails = _orderDetailRepository.GetAll().Where(x => x.BillId == id);            
            if (bill.BillStatus != BillStatus.Cancelled)
            {
                bill.BillStatus = BillStatus.Cancelled;
                foreach (var detail in billDetails)
                {
                    var product = _productRepository.GetById(detail.ProductId);
                    product.Quantity += detail.Quantity;
                }
            }
            else
            {
                throw new Exception("Đơn này đã huỷ trước đó rồi.");
            }
        }

        public void PendingBill(int id)
        {
            var bill = _orderRepository.GetById(id);
            var billDetails = _orderDetailRepository.GetAll().Where(x => x.BillId == id);
            if (bill.BillStatus != BillStatus.Pending)
            {
                bill.BillStatus = BillStatus.Pending;
            }
            else
            {
                throw new Exception("Đơn hàng này đã bị hoãn trước đó.");
            }
        }

        public void AddDetail(BillDetailViewModel billDetailVm)
        {
            var billDetail = Mapper.Map<BillDetailViewModel, BillDetail>(billDetailVm);
            _orderDetailRepository.Add(billDetail);
        }

        public void DeleteDetail(int productId, int billId)
        {
            var detail = _orderDetailRepository.Single(x => x.ProductId == productId
           && x.BillId == billId);
            _orderDetailRepository.Remove(detail);               
        }

        public BillViewModel GetDetailById(int billId)
        {
            var bill = _orderRepository.Single(x => x.Id == billId);
            var billVm = Mapper.Map<Bill, BillViewModel>(bill);
            var billDetailVm = _orderDetailRepository.GetAll().Where(x => x.BillId == billId).ProjectTo<BillDetailViewModel>().ToList();
            billVm.BillDetails = billDetailVm;
            return billVm;
        }

        public List<BillDetailViewModel> GetDetailsByBillId(int billId)
        {
            return _orderDetailRepository
                  .GetAll().Where(x => x.BillId == billId)
                //.GetAll().Where(x => x.BillId == billId, c => c.Bill, c => c.Product) 
                .ProjectTo<BillDetailViewModel>().ToList();
        }     

       
    }
}