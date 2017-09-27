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
    public class EFCustomerManagementBLL : ICustomerService
    {
        EFCustomerManagementDAL _customerManagementDAL = new EFCustomerManagementDAL();
        //private readonly ICustomerManagementDAL _customerManagementDAL;

        //public EFCustomerManagementBLL(ICustomerManagementDAL customerManagementDAL)
        //{
        //    _customerManagementDAL = customerManagementDAL;
        //}

        public void Add(Customers customer)
        {
            _customerManagementDAL.Add(customer);
        }

        public Customers GetByCivilizationNumber(string civilizationNumber)
        {
             return _customerManagementDAL.Get(x => x.CivilizationNumber == civilizationNumber);
        }
    }
}
