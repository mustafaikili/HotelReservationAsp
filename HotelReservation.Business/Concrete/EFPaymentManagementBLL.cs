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
    public class EFPaymentManagementBLL : IPaymentService
    {
        EFPaymentManagementDAL _paymentManagementDAL = new EFPaymentManagementDAL();
        //private readonly IPaymentManagementDAL _paymentManagementDAL;

        //public EFPaymentManagementBLL(IPaymentManagementDAL paymentManagementDAL)
        //{
        //    _paymentManagementDAL = paymentManagementDAL;
        //}
    }
}
