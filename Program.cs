class Program{
    static void Main(string[] args){
         bool testMode = true;
        if (testMode)
            new RunTest();
        else
        {
            Console.WriteLine("Starting the application");
            new SettingAction();
        }
    }
}
