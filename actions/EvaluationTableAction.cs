using System.Data;

public class EvaluationTableAction{
    public EvaluationTableAction()
    {
    }
    
    //create fill evaluation model method
    public static EvaluationTable fillEvaluationModel(DataRow row)
    {
        EvaluationTable evaluation = new EvaluationTable();
        evaluation.Evaluation = row["Değerlendirme"].ToString();
        evaluation.Subject = row["İnceleme Konusu"].ToString();
        evaluation.TaxNo = row["Vergi No"].ToString();
        evaluation.Title = row["Unvan"].ToString();
        evaluation.Amount = Convert.ToDecimal(row["SBK Tutarı"]);
        evaluation.Years = row["İnceleme Yılları"].ToString();
        evaluation.Reason = row["Gerekçe"].ToString();
        evaluation.ReportDate = row["(İZDK) Rapor Tarihi"].ToString();
        evaluation.ReportNo = row["(İZDK) Rapor Sayısı"].ToString();
        
       
        return evaluation;
    }

}