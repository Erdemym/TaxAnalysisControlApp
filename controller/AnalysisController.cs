using System.Data;
//Also write methodname in summary
/// <summary>
/// Abstract class that serves as a base for all analysis controllers. 
/// PreControl
/// Analysis
/// CheckErrorFlag
/// </summary>
public abstract class AnalysisController
{
    public AnalysisController()
    {
        PreControl();

    }
    public abstract void PreControl();
    public abstract void Analysis();

    public static void CheckErrorFlag()
    {
        if (Setting.ErrorFlag)
        {
            Print.ExitMessage("Program Sonlandırıldı.");
            Environment.Exit(0);
        }
    }


}