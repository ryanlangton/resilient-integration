using System;
using System.Collections.Generic;
using System.Text;

namespace ResilientIntegration.Core.Commands
{
    public interface UploadProvidersCommand
    {
        string FirstName { get; }
        string LastName { get; }
    }
}
