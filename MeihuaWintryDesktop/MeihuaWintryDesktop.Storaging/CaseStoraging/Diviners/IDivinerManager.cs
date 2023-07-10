using LiteDB;

namespace MeihuaWintryDesktop.Storaging.CaseStoraging.Diviners;
public interface IDivinerManager
{
    string GetScript(DivinerScriptCategory category);
    void SetScript(DivinerScriptCategory category, string script);
}
