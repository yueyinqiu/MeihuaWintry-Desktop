using MeihuaWintryDesktop.Storaging.CaseStoraging.Cases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeihuaWintryDesktop.ViewModelling.Tools.CaseEditing;
internal sealed record GregorianTime(
    int? Year, int? Month, int? Day,
    int? Hour, int? Minute) : IStoredGregorianTime
{
}
