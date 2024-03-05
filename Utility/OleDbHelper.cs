using System;
using System.Data;
using System.Data.OleDb;

public class OleDbHelper : IDisposable
{
    private const string analysisFilePath = "deg-analiz.xlsx"; 
    private const string evaluationFilePath = "degerlendirme.xlsx"; 


    // Connection string for Excel 2007 xls file format
    //private const string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0;HDR=YES\";";
    public static string connectionStringAnalysis = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={analysisFilePath};Extended Properties=\"Excel 12.0;HDR=YES\";";
    public static string connectionStringEvaluation = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={evaluationFilePath};Extended Properties=\"Excel 12.0;HDR=YES\";";

    private OleDbConnection _connection;

    public OleDbHelper(Setting.ConnectionType connectionType)
    {
        // Remove the unnecessary line of code
        // Setting.ProfileMenuBarTab.Edit == Setting.ProfileMenuBarTab.Edit;

        if (connectionType == Setting.ConnectionType.Evaluation)
            _connection = new OleDbConnection(connectionStringEvaluation);
        else
            _connection = new OleDbConnection(connectionStringAnalysis);
    }

    public void OpenConnection()
    {
        if (_connection.State != ConnectionState.Open)
        {
            _connection.Open();
        }
    }

    

    public void CloseConnection()
    {
        if (_connection.State != ConnectionState.Closed)
        {
            _connection.Close();
        }
    }

       public DataTable ExecuteQuery(string query,string functionName)
    {
        DataTable dataTable = new DataTable();
        try{
        using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, _connection))
        {
            adapter.Fill(dataTable);
        }
        }catch{
            Console.WriteLine("!!!!!!"+functionName+"!!!!!!");
        }

        return dataTable;
    }

    public int ExecuteNonQuery(string query,string functionName)
    {
        try{
        using (OleDbCommand command = new OleDbCommand(query, _connection))
        {
            return command.ExecuteNonQuery();
        }
        }catch{
            Console.WriteLine("!!!!!!"+functionName+"!!!!!!");
            return 0;
        }
    }

 

    public void Dispose()
    {
        CloseConnection();
        _connection.Dispose();
    }


}
