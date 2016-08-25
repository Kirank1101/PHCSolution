//Copyright (C) Microsoft Corporation.  All rights reserved.
using System;
namespace PHC.DataAccess
{
    public interface IUnitOfWork : IDisposable
    {        
        void Save();
    }
}
