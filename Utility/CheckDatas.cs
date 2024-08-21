public static class CheckDatas{

    public static void CheckUnvanHasSpecialTitle(string taxNumber, string taxPayerTitle)
    {
        taxPayerTitle = taxPayerTitle.ToUpper();

        // Initializing test list
        List<string> specialTitleList = new List<string> { "PART", "BELED", "VALI", "SAVCI", "DERNEK", "VAKIF",  "KURUM", "BASKAN", "MUDUR", "KOOP" };

        List<string> result = new List<string>();

        foreach (string element in specialTitleList)
        {
            element.ToUpper().Replace("İ", "I").Replace("Ş", "S").Replace("Ü", "U").Replace("Ğ", "G").Replace("Ç", "C").Replace("Ö", "O");

            if (taxPayerTitle.Contains(element))
            {
                result.Add(element);
                //if Setting.SpecialTitleList does not contain element, add it
            }



        }

        if (result.Count > 0)
        {
            if (!Setting.SpecialTitleTaxList.Contains(taxNumber))
                {
                    Setting.SpecialTitleTaxList.Add(taxNumber);
                    Print.WriteWarningMessage("VKN " + taxNumber + " li " + taxPayerTitle + " unvanlı mükellef unvanı : \"" + string.Join(", ", result) + "\" karakteri içermektedir. Yönetici İle Görüşülsün.");
                }
            
        }

    }
    public static void CheckVtrReportType()
    {
        if(Setting.VtrReportType=="VTR-Tam Sahte Belge Düzenleme")
        {
        }else if (!Setting.VtrReportType.StartsWith("VTR"))
        {
            Print.WriteErrorMessage("Rapor Türü VTR değil. Yönetici ile görüşün.");
        }else if (Setting.VtrReportType == "VTR-Genel")
        {
            Print.ColorYellow("Rapor Türü Genel. Yanlışlıkla SBK liste gelmemiş ise Ayarları genel incelemeye göre düzenleyiniz.");
            Print.ColorYellow("H analizi yapılmayacak.");
        }else if (Setting.VtrReportType == "VTR-Kısmen Sahte Belge Düzenleme")
        {
            Print.ColorYellow("Rapor Türü Kısmen Sahte Belge Düzenleme. H analizi yapılmayacak.");
        }else if(Setting.VtrReportType.StartsWith("VTR-Taklit"))
        {
            Print.ColorYellow("Rapor Türü Taklit-Çalıntı belge.");
            Print.ColorYellow("Giriş yaparken belirtmeyi unutmayın.");
            Print.ColorYellow("H analizi yapılmayacak.");
        }else if(Setting.VtrReportType.StartsWith("VTR-Muhteviyatı"))
        {
            Print.ColorYellow("Rapor Türü Muhteviyatı İtibarıyla Yanıltıcı Belge Düzenleme.");
            Print.ColorYellow("H analizi yapılmayacak.");
        }

    }
    public static void VtrEvaluationDateControlIsNullOrEmpty()
    {
        if (string.IsNullOrEmpty(Setting.VtrEvaluationDate))
        {
            Print.WriteWarningMessage("Rapor RDK'dan çıkmamış.Yönetici ile görüşün.");
        }
    }

    public static bool CheckAnaysisType(string reason){
        throw new NotImplementedException();
    }


   
}