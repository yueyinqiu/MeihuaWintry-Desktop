using MeihuaWintryDesktop.Storaging.CaseStoraging.Cases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeihuaWintryDesktop.ViewModelling.Tools.CaseEditing;
internal sealed record NumberOfCase(
    string Name, 
    int Number) : IStoredNumber
{
}
