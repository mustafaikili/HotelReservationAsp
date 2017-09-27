using HotelReservation.Business.Abstract;
using HotelReservation.DataAccess.Abstract;
using HotelReservation.DataAccess.Concrete.EntityFramework.DALManagement;
using HotelReservation.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Business.Concrete
{
    public class EFPaymentTypeManagementBLL : IPaymentTypeService
    {
        EFPaymentTypeManagementDAL _paymentTypeManagementDAL = new EFPaymentTypeManagementDAL();
        //private readonly IPaymentTypeManagementDAL _paymentTypeManagementDAL;

        //public EFPaymentTypeManagementBLL(IPaymentTypeManagementDAL paymentTypeManagementDAL)
        //{
        //    _paymentTypeManagementDAL = paymentTypeManagementDAL;
        //}
    }
}
