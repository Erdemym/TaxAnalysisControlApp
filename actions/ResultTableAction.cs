using System.Data;

public class ResultTableAction
{
    public ResultTableAction()
    {
    }

    //create fill result model method
    public static ResultTable fillResultModel(DataRow row)
    {
        ResultTable result = new ResultTable();
        result.TaxNumber = row["VKN"].ToString();
        result.Title = row["Unvan"].ToString();
        result.Year = Convert.ToInt32(row["Yil"]);
        result.Amount = Convert.ToDecimal(row["Tutar"]);
        result.Result = row["Tablo"].ToString();
        return result;
    }
}