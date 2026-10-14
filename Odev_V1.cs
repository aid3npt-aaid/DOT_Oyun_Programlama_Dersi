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
        // Kullanıcıdan değer alan methodumuz
    public string SayiGir()
    {
        Console.Write("Sayınızı girin: ");
        string? deger = Console.ReadLine();
        return deger;
    }

        // Girilen değerin sayı olup olmadığını kontrol eden method
    public bool SayimiKontrolEt(string deger, out int sayi)
    {
        return int.TryParse(deger, out sayi);   // Girilen değerin sayı olup olmadığını kontrol ediyoruz. Eğer sayı ise sayi değişkenine atıyoruz
    }

        // Sayının tek mi çift mi olduğunu ekrana yazan method
    public void TekmiCiftmi(int sayi)
    {
        if (sayi % 2 == 0)   // Sayının 2 ye bölümünden kalan 0 ise sayı çifttir, değilse tektir
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

            //kullanıcı sayı dışında bir değer girerse programın hata vermemesi için değişkenleri tanımlıyoruz

        string deger = "";       // Kullanıcıdan alınan değeri tutacak değişken. null olabileceği için string? yerine string kullandık.
        int sayi;       // Girilen değerin sayı olup olmadığını kontrol etmek için kullanılacak değişken

        Console.WriteLine("Sayınızın tek mi çift mi olduğunu bulmak için bir sayı girin! (Çıkmak için 'n' yazın)\n");

        //kullanıcı sayı olmayan bir değer girerse tekrar sayı girmesi için döngüye alıyoruz. Kullanıcı N veya n girerse döngüden çıkıyoruz

        do // while yerine do-while çünkü while döngüsünde kullanıcıya ilk başta sayı girme fırsatı verilmiyor.
        {
                // tüm methodları çağırıyoruz

            deger = islem.SayiGir();

            if (islem.SayimiKontrolEt(deger, out sayi))
            {
                islem.TekmiCiftmi(sayi);
            }

        } while (deger.ToLower() != "n");      // büyük küçük harf farketmeksizin N veya n girilirse döngüden çıkıyoruz
    }
}