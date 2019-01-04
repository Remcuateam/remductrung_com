using System;
using System.Collections.Generic;
using AspNetMvc.Services.ECommerce.Bills.Dtos;
using AspNetMvc.Services.ECommerce.Products.Dtos;
using AspNetMvc.Data.Enums;
using AspNetMvc.Utilities.Dtos;
using AspNetMvc.Data.Entities;
using AspNetMvc.Data.Entities.ECommerce;

namespace AspNetMvc.Services.ECommerce.Bills
{
    public interface IBillService : IWebServiceBase<Bill, int, BillViewModel>
    {
        //void Add(BillViewModel billVm);
        //void Update(BillViewModel billVm);

        //BillViewModel GetById(Guid id);

        PagedResult<BillViewModel> GetAllPaging(string startDate, string endDate, string keyword, int pageSize, int page);
        void UpdateStatus(int orderId, BillStatus status);
        void ConfirmBill(int id);
        void CancelBill(int id);
        void PendingBill(int id);
        //
        void AddDetail(BillDetailViewModel billDetailVm);
        void DeleteDetail(int productId, int billId);
        BillViewModel GetDetailById(int billId);
        List<BillDetailViewModel> GetDetailsByBillId(int billId);
        //List<ColorViewModel> GetColors();
        //List<SizeViewModel> GetSizes();

        //
        //void Add(BillViewModel billVm);
        //void Update(BillViewModel billVm);
        //void Delete(Guid billId); not available----------------------------------------------------
        //BillViewModel GetById(Guid billId);
        //List<BillViewModel> GetAll(); not available----------------------------------------------------
        //PagedResult<BillViewModel> GetAllPaging(string startDate, string endDate, string keyword, int pageSize, int page);
        //void UpdateStatus(Guid billId, BillStatus status);
        //void ComfirmBill(Guid billId);
        //void CancelBill(Guid billId);
        //void PendingBill(Guid billId);
        //
        //void AddDetail(BillDetailViewModel billDetailVm);
        //void UpdateDetail(BillDetalViewModel billDetailVm);----------------------------------------------------
        //void DeleteDetail(Guid billId, Guid productId);       
        //BillDetailViewModel GetDetailById(Guid billId);
        //List<BillDetailViewModel> GetAll();----------------------------------------------------
        //PagedResult<BillDetailViewModel> GetAllPaging(string keyword, int pageSize, int page);----------------------------------------------------
        //List<BillDetailViewModel> GetDetailsByBillId(Guid billId);
        //List<SizeViewModel> GetSizes();
        //List<ColorViewModel> GetColors();
    }
}