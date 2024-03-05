// Class for the "ayar" sheet
public class Setting
{
    //generating class determine all the properties

    //create static enum for connection type evulation or analysis

    public enum ConnectionType { Evaluation, Analysis }



    private static bool _errorFlag = false;

    public static bool ErrorFlag { get => _errorFlag; set => _errorFlag = value; }
    public static int RowCount { get; set; }
    public static double Amount { get; set; }
    public static string? Result { get; set; }
    public static string? AnalysisType { get; set; }
    public static double TimeoutYear { get; set; }
    public static double HYear { get; set; }


    public static bool MatrahEmptyFlag { get; set; }
    public static bool TablohEmptyFlag { get; set; }

    public static string? VtrTaxPayerTitle { get; internal set; }
    public static string? VtrReportType { get; internal set; }
    
    public static string? VtrEvaluationDate { get; internal set; }
    public static string? VtrTaxPeriod { get; internal set; }

    public static List<ResultTable> ResultList {get;set;}
    public static List<EvaluationTable> EvaluationList {get;set;}
}