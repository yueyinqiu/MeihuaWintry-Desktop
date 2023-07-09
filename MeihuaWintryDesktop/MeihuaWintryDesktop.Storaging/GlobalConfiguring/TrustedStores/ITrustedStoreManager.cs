using MeihuaWintryDesktop.Storaging.CaseStoraging;

namespace MeihuaWintryDesktop.Storaging.GlobalConfiguring.TrustedStores;
public interface ITrustedStoreManager
{
    void TrustStore(CaseStore store);
    bool IsStoreTrusted(CaseStore store);
}
