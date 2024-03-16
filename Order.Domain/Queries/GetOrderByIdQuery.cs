﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Queries
{
    public class GetOrderByIdQuery : IRequest<string>
    {
        public int Id { get; set; }

        // IRequest<UserDto> dönüş tipi, sorgu sonucu olarak bir UserDto döndürülmesini sağlar.
    }
}