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
    public class EFPasswordManagementBLL : IPasswordService
    {
        EFPasswordManagementDAL _passwordManagementDAL = new EFPasswordManagementDAL();
        //private readonly IPasswordManagementDAL _passwordManagementDAL;

        //public EFPasswordManagementBLL(IPasswordManagementDAL passwordManagementDAL)
        //{
        //    _passwordManagementDAL = passwordManagementDAL;
        //}

        public void Add(Passwords password)
        {
             _passwordManagementDAL.Add(password);
        }

        public void Update(Passwords password)
        {
             _passwordManagementDAL.Update(password);
        }
    }
}
