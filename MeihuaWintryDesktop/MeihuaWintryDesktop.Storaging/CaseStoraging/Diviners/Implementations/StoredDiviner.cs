using LiteDB;
using MeihuaWintryDesktop.Storaging.CaseStoraging.Cases.Implementations;
using MeihuaWintryDesktop.Storaging.CaseStoraging.Cases;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics;

namespace MeihuaWintryDesktop.Storaging.CaseStoraging.Diviners.Implementations;
internal class StoredDiviner : IStoredDiviner
{
    public static ObjectId PossibleId => new ObjectId("5d0bb30b87cf8920519fd1f0");

    [BsonId(autoId: false)]
    public ObjectId DivinerId
    {
        get => PossibleId;
        set
        {
            Debug.Assert(value == PossibleId);
        }
    }

    private string preScript;
    public required string PreScript
    {
        get => this.preScript;
        [MemberNotNull(nameof(preScript))]
        set => this.preScript = value ?? "";
    }

    private string defaultScript;
    public required string DefaultScript
    {
        get => this.defaultScript;
        [MemberNotNull(nameof(defaultScript))]
        set => this.defaultScript = value ?? "";
    }
    
    private string postScript;
    public required string PostScript
    {
        get => this.postScript;
        [MemberNotNull(nameof(postScript))]
        set => this.postScript = value ?? "";
    }

    public static StoredDiviner FromInterfaceType(IStoredDiviner d)
    {
        return new StoredDiviner() {
            PreScript = d.PreScript,
            DefaultScript = d.DefaultScript,
            PostScript = d.PostScript
        };
    }
}