﻿using Microsoft.AspNetCore.Identity.UI.Services;
using Spice.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spice.Service.ServiceInterfaces
{
    public interface IOrderState
    {
        public void HandleRequest(IEmailService _emailService, int OrderId);
    }
}
