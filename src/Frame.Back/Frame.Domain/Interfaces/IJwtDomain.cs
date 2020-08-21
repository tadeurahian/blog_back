using Frame.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Frame.Domain.Interfaces
{
    public interface IJwtDomain 
    {
        string GerarToken(Usuario usuario);
    }
}
