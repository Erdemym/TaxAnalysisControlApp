using System.Data;

public class SettingAction
{
    public SettingAction()
    {
        Print.WriteProgramName();
        getVtrSettings();
        getResultSettings();
        getEvaluationSettings();

    }
     private void getVtrSettings()
    {
        OleDbHelper dbHelper = new OleDbHelper(Setting.ConnectionType.Analysis);
        string query = "Select * from [vtr$]";
        DataTable ayarTable = dbHelper.ExecuteQuery(query,"SettingAction.getVtrSettings");
        dbHelper.CloseConnection();
        //ayarTable count equal zero give error and exit program
        if (ayarTable.Rows.Count == 0)
        {
            Setting.ErrorFlag = true;
            Print.WriteErrorMessage("VTR ayarları girilmedi.Lütfen kontrol ediniz.");
            AnalysisController.CheckErrorFlag();
        }
        DataRow getFirst = ayarTable.Rows[0];
        Vtr vtrData = VtrTableAction.fillVtrModel(getFirst);
        Setting.VtrTaxPayerTitle = vtrData.TaxPayerTitle;
        Setting.VtrReportType = vtrData.ReportType;
        Setting.VtrEvaluationDate = vtrData.EvaluationDate;
        Setting.VtrTaxPeriod = vtrData.TaxPeriod;
        
    }
    
    private void getResultSettings(){
        OleDbHelper dbHelper = new OleDbHelper(Setting.ConnectionType.Analysis);
        string query = "Select * from [analiz$]";
        DataTable resultTable = dbHelper.ExecuteQuery(query,"SettingAction.getResultSettings");
        dbHelper.CloseConnection();
        if (resultTable.Rows.Count == 0)
        {
            Setting.ErrorFlag = true;
            Print.WriteErrorMessage("Analiz tablosu boş. Lütfen kontrol ediniz.");
            AnalysisController.CheckErrorFlag();
        }
        //in loop fill result model and add to list
        foreach (DataRow row in resultTable.Rows)
        {
            ResultTable resultData = ResultTableAction.fillResultModel(row);
            Setting.ResultList.Add(resultData);
        }
        
    }

    public void getEvaluationSettings()
    {
        OleDbHelper dbHelper = new OleDbHelper(Setting.ConnectionType.Evaluation);
        string query = "Select * from [Sayfa1$]";
        DataTable evaluationTable = dbHelper.ExecuteQuery(query,"SettingAction.getEvaluationSettings");
        dbHelper.CloseConnection();
        if (evaluationTable.Rows.Count == 0)
        {
            Setting.ErrorFlag = true;
            Print.WriteErrorMessage("Degerlendirme tablosu boş. Lütfen kontrol ediniz.");
            AnalysisController.CheckErrorFlag();
        }
        //in loop fill evaluation model and add to list
        foreach (DataRow row in evaluationTable.Rows)
        {
            EvaluationTable evaluationData = EvaluationTableAction.fillEvaluationModel(row);
            Setting.EvaluationList.Add(evaluationData);
        }
    }

    
}