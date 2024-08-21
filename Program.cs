class Program
{
    static void Main(string[] args)
    {
        bool testMode = false;
        if (testMode)
            new RunTest();
        else
        {
            string analysisType = "1";
            Console.WriteLine("Starting the application");
            new SettingAction();
            if (Setting.VtrReportType.Equals("VTR-Genel"))
            {
                //if Analiz Sahte kullanma ise 1 Genel inceleme ise 2 ye basınız
                Console.WriteLine("Analiz Sahte kullanma ise 1 / Genel inceleme ise 2 ye basıp. Enter tuşuna basınız.");
                analysisType = Console.ReadLine();

            }
            else { new SbkAnalysisController(); }
            if (analysisType == "2")
            {
                new MoneyTransferAnalysisController();
            }
            else
            {
                new SbkAnalysisController();
            }
        }
    }
}
