using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeihuaWintryDesktop.ViewModelling.Tools.CaseEditing.Scripting;

[Serializable]
public class ScriptFailedException : Exception
{
    public ScriptFailedException(Exception? inner) : base("Failed to run the given script.", inner) { }
    protected ScriptFailedException(
      System.Runtime.Serialization.SerializationInfo info,
      System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}
