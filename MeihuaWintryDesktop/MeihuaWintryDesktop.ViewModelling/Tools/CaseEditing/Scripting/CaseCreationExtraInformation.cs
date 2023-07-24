using MeihuaWintryDesktop.Storaging.CaseStoraging;
using MeihuaWintryDesktop.Storaging.CaseStoraging.Cases;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YiJingFramework.PrimitiveTypes;

namespace MeihuaWintryDesktop.ViewModelling.Tools.CaseEditing.Scripting;

internal sealed record CaseCreationExtraInformation(CaseStore CaseStore, string Script)
{

}