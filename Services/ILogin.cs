using SampleASPCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleASPCore.Services
{
    public interface ILogin 
    {
        Login ProcessLogin(Login obj);
    }
}
