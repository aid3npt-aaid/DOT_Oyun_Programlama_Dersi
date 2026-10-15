/* Dersdeki kodumuz
String deger = "";
int sayi;

do
{
    Console.Write("Sayı gir:");
    deger = Console.ReadLine();
    if (int.TryParse(deger, out sayi))
    {
        if(sayi % 2 == 0)
        {
            Console.WriteLine("Sayı çifttir");
        }
        else
        {
            Console.WriteLine("Sayı tektir");
        }
    }
} while (deger != "N" && deger != "n");
*/

using System;

    // SayiIslemleri sınıfımızı oluşturuyoruz. Methodları bir sınıf altında toplamak bu methodları başka yerlerde kullanabilmemizi sağlıyor

class SayiIslemleri 
{
    // Veriler sınıfın içinde private alanlarda tutuluyor (kapsülleme)
    // Sınıf dışından doğrudan erişilemez, sadece aşağıdaki Getter/Setter'lar üzerinden erişilebiliyor
    private string _deger = "";   
    private int _sayi;            // Değer sayıya çevrilebilirse _sayi değişkenine atanacak
    private bool _gecerliMi;      // Girilen değerin sayı olup olmadığı

    public string Deger
    {
        get { return _deger; }
        set { _deger = value ?? ""; }    // Deger için Getter/Setter. Setter null gelirse boş string atar
    }

    // Sayi için sadece Getter var. Dışarıdan değiştirilemez yalnızca SayimiKontrolEt methodu üzerinden dolaylı olarak güncellenir
    public int Sayi
    {
        get { return _sayi; }
    }

    // GecerliMi de sadece okunabilir.
    public bool GecerliMi
    {
        get { return _gecerliMi; }
    }

        // Kullanıcıdan değer alan methodumuz
    // Method değeri return etmiyor (void) alınan değeri Deger property'sine (setter) atıyor
    public void SayiGir()
    {
        Console.Write("Sayınızı girin: ");
        Deger = Console.ReadLine();
    }

        // Girilen değerin sayı olup olmadığını kontrol eden method
    // Sonucu hem döndürüyor hem de _gecerliMi ve _sayi alanlarına kaydediyor.
    public bool SayimiKontrolEt()
    {
        _gecerliMi = int.TryParse(_deger, out _sayi);   // Eğer sayı ise sayi değişkenine atıyoruz
        return _gecerliMi;
    }

    public bool CikisMi()
    {
        return _deger.ToUpper() == "N";
    }

        // Sayının tek mi çift mi olduğunu ekrana yazan method
    public void TekmiCiftmi()
    {
        if (_sayi % 2 == 0)   // Sayının 2 ye bölümünden kalan 0 ise sayı çifttir, değilse tektir
        {
            Console.WriteLine("Sayınız çifttir\n");
        }
        else
        {
            Console.WriteLine("Sayınız tektir\n");
        }
    }
}

// Program sınıfımızı oluşturuyoruz. Main methodu burada yer alıyor. Kullanıcıdan değer alıp methodları çağırıyoruz

class Program
{
    static void Main() // Main methodu programın başlangıç noktasıdır. Program buradan başlar ve buradan biter.
                       // Void tipinde olduğu için geriye değer döndürmez. Static olduğu için sınıfın bir nesne oluşturulmadan çağrılabilir. Main methodu static olmak zorundadır.
    {
        SayiIslemleri islem = new SayiIslemleri();      // SayiIslemleri sınıfından bir nesne oluşturuyoruz. methodları çağırmak için kullanacağız


        // değişkenler nesnenin içinde (private _deger ve _sayi) tutuluyor
        // Bu yüzden Main içinde bu değişkenleri tanımlamak gerekmiyor

        Console.WriteLine("Sayınızın tek mi çift mi olduğunu bulmak için bir sayı girin! (Çıkmak için 'n' yazın)\n");

        //kullanıcı sayı olmayan bir değer girerse tekrar sayı girmesi için döngüye alıyoruz. Kullanıcı N veya n girerse döngüden çıkıyoruz

        do   // while yerine do-while çünkü while döngüsünde kullanıcıya ilk başta sayı girme fırsatı verilmiyor.
        {
                // tüm methodları çağırıyoruz
            islem.SayiGir();

            if (islem.SayimiKontrolEt())
            {
                islem.TekmiCiftmi();
            }
        } while (!islem.CikisMi());      // cıkışmı işlemi doğru olmadığı takdirde döngü devam ediyor
    }
}
