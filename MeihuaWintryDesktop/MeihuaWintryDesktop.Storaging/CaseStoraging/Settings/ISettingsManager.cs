﻿using LiteDB;
using YiJingFramework.PrimitiveTypes;

namespace MeihuaWintryDesktop.Storaging.CaseStoraging.Settings;
public interface ISettingsManager
{
    string StoreNotes { get; set; }
}
