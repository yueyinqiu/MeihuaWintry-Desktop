﻿using MeihuaWintryDesktop.Storaging.CaseStoraging;
using MeihuaWintryDesktop.Storaging.CaseStoraging.Cases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeihuaWintryDesktop.ViewModelling.Tools.CaseSearching;
public sealed record SearchedCase(IStoredCaseWithId StoredCase, string? SearchDetails)
{
}
