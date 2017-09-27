﻿using HotelReservation.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Business.Abstract
{
    public interface IResCusRoomService
    {
         void Add(ResCusRooms resCusRoom);
         void Delete(ResCusRooms resCusRoom);
         ICollection<ResCusRooms> GetAll(Guid customerID);
    }
}