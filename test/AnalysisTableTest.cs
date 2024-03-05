using System.Data;

public class AnalysisTableTest{
    public AnalysisTableTest(){
        OleDbHelper dbhelper = new OleDbHelper(Setting.ConnectionType.Analysis);
        dbhelper.OpenConnection();
        string selectQuery = "SELECT * FROM [analiz$] ";
        DataTable tabloHTable = dbhelper.ExecuteQuery(selectQuery,"AnalysisTableTest");
        
        dbhelper.CloseConnection();
        //Write all data tabloHTable  in loop
        Console.WriteLine(tabloHTable.Rows.Count);
        foreach (DataRow row in tabloHTable.Rows)
        {
            foreach (DataColumn col in tabloHTable.Columns)
            {
                Console.WriteLine(row[col]);
            }
        }
        
    }
}