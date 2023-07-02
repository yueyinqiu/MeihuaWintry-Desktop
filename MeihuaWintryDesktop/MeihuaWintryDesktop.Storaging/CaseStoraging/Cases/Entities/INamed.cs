using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeihuaWintryDesktop.Storaging.CaseStoraging.Cases.Entities;
public interface INamed<T>
{
    string Name { get; }
    T Value { get; }
}
