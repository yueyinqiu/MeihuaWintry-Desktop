using MeihuaWintryDesktop.Storaging.CaseStoraging.Settings;
using MeihuaWintryDesktop.Storaging.GlobalConfiguring.TrustedStores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeihuaWintryDesktop.Storaging.GlobalConfiguring;
public sealed class GlobalConfiguration
{
    public ITrustedStoreManager TrustedStores => throw new NotImplementedException();
}
