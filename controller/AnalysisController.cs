using System.Data;
//Also write methodname in summary
/// <summary>
/// Abstract class that serves as a base for all analysis controllers. 
/// PreControl
/// Analysis
/// CheckErrorFlag
/// </summary>
public abstract class AnalysisController
{
    public AnalysisController()
    {
        PreControl();

    }
    private void PreControl(){
       
        //Check Special Title in both List.
        foreach(EvaluationTable evaluation in Setting.EvaluationList){
            CheckDatas.CheckUnvanHasSpecialTitle(evaluation.TaxNo,evaluation.Title);
        }
        Print.WriteAsteriskLine();
        foreach(ResultTable result in Setting.ResultList){
            CheckDatas.CheckUnvanHasSpecialTitle(result.TaxNumber,result.Title);
        }

        /*
        Vergi Başmüfettişi Osman TAŞDEMİR tarafından Ziyapaşa Vergi Dairesi Müdürlüğünün 612 162 0489 vergi kimlik numaralı mükellefi Marina Dekorasyon Ltd. Şti. hakkında tanzim edilen 09.02.2024 tarihli ve 2024-[1989-1-60]/6 sayılı Vergi Tekniği Raporuna istinaden düzenlenen 29.02.2024 tarihli ve 8869 sayılı incelemeye sevk yazısında yer alan hususlar doğrultusunda; mükellefin sahte belge kullanma konusunda ve sınırlı inceleme kapsamında incelenmesine karar verilmiştir.
        
        Vergi Müfettişi	Unvan	Rapor Tarihi	Rapor Sayısı	Rapor Türü	İmza	Durumu	Dış Sisteme Gönderilme Tarihi	RDK	MRDK	İşemri Tarihi	İşemri Sayısı	Rapor Konusu	Vergi No	Unvan	Vergi Dairesi	Vergi Türü	Dönem	Kapsam	TÖU Talebi	Tevdi Tarihi	RDK'ya Sevk Tarihi	RDK Değerlendirme Tarihi	
    22Osman TAŞDEMİR22	11Vergi Başmüfettişi11	6609/02/202466	772024-[1989-1-60]/677	VTR-Tamamen Sahte Belge Düzenleme	İmzalı	İlgili Birime Gönderildi	27/02/2024	4 Nolu RDK	 	24/01/2023	23929873-663.05[32551]-3817	Sahte belge düzenleme	44612162048944	55MARINA DEKORASYON55	33001254 - ZİYAPAŞA VD.33		2022	Belirsiz	Kapsam Dışı	12/02/2024	12/02/2024	27/02/2024	


        */
        // evaluate split "sevk"[0] (sayılı incelemeye sevk yazısı) equal all gerekce;

        //if evaluation Value equal H check Setting.Vtr in List.

        //Check Evaluate VTR + vtr date

        //Check Inspector in Evaluate 

        //Check VTR type and evaluate

        //check TaxPayer Number and title in evaluate + Tax Office




    }
    public abstract void Analysis();

    public static void CheckErrorFlag()
    {
        if (Setting.ErrorFlag)
        {
            Print.ExitMessage("Program Sonlandırıldı.");
            Environment.Exit(0);
        }
    }


}