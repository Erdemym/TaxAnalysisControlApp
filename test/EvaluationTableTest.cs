using System.Data;

public class EvaluationTableTest{
    public EvaluationTableTest(){
        OleDbHelper dbhelper = new OleDbHelper(Setting.ConnectionType.Evaluation);
        
        dbhelper.OpenConnection();
        string selectQuery = "SELECT * FROM [Sayfa1$]";
        DataTable tabloHTable = dbhelper.ExecuteQuery(selectQuery,"EvaluationTableTest");
        
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