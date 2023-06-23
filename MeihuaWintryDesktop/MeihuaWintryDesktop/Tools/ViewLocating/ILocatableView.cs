using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeihuaWintryDesktop.Tools.ViewLocating;
public interface ILocatableView
{
    abstract static Type TypeOfViewModel { get; }
}
