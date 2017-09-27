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
    public class EFPriceRatioManagementBLL : IPriceRatioService
    {
        EFPriceRatioManagementDAL _priceRatioManagementDAL = new EFPriceRatioManagementDAL();
        //private readonly IPriceRatioManagementDAL _priceRatioManagementDAL;

        //public EFPriceRatioManagementBLL(IPriceRatioManagementDAL priceRatioManagementDAL)
        //{
        //    _priceRatioManagementDAL = priceRatioManagementDAL;
        //}

        public PriceRatios GetByPriceRatioName(string priceRatioName)
        {
             return _priceRatioManagementDAL.Get(x => x.PriceRatioName == priceRatioName);
        }
    }
}
