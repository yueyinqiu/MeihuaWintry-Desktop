﻿using MeihuaWintryDesktop.Storaging.CaseStoraging.Cases;

namespace MeihuaWintryDesktop.ViewModelling.Tools.CaseEditing;
internal sealed record GregorianTime(
    int? Year, int? Month, int? Day,
    int? Hour, int? Minute) : IStoredGregorianTime
{
}
