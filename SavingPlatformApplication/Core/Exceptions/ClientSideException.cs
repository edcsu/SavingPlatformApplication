﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SavingPlatformApplication.Core.Exceptions
{
    public class ClientSideException : Exception
    {
        public ClientSideException(string message) : base(message)
        {
        }
    }

    public class NotFoundException : ClientSideException
    {
        public NotFoundException(string message) : base(message) { }
    }
}
