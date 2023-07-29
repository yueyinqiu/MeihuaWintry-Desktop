namespace MeihuaWintryDesktop.ViewModelling.Tools.CaseEditing.Scripting;

[Serializable]
public class ScriptFailedException : Exception
{
    public ScriptFailedException(Exception? inner) : base("在运行脚本时发生了错误。", inner) { }
    protected ScriptFailedException(
      System.Runtime.Serialization.SerializationInfo info,
      System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}
