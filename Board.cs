//PROJE-2 : Console ToDo Uygulaması

using System;

namespace ToDoApp
{
    public class Board 

    {
         Dictionary<int, string> KisiList = new Dictionary<int, string>();
        List<Kart> TODO = new List<Kart>();
        List<Kart> INPROGRESS = new List<Kart>();
        List<Kart> DONE = new List<Kart>();

        public Board()
        {
            KisiList.Add(0, "Esra Öztürk");
            KisiList.Add(1, "Ensar Karaahmetoğlu");
            KisiList.Add(2, "Elif  Teke");
            KisiList.Add(3, "Selahattin Karaahmetoğlu");
            KisiList.Add(4, "Ahmet dursun");

            TODO.Add(new Kart("Grafik tasarım", "Logo tasarla", "Esra Öztürk", Kart.Buyuluk.M));
            TODO.Add(new Kart("3d çizim", "Karakter modelle", "Ensar Karaahmetoğlu", Kart.Buyuluk.XL));
            TODO.Add(new Kart("Yazılım", "Gerekli düzenlemeler tamamlanacak", "Elif Teke", Kart.Buyuluk.L));
            TODO.Add(new Kart("muhasebe", "Maaşları yatır", "Selahattin Karaahmetoğlu", Kart.Buyuluk.S));
            TODO.Add(new Kart("Alışveriş", "gıda al", "Ahmet dursun", Kart.Buyuluk.XS));
        }

        public void KartEkle()
        {
            string baslik;
            string icerik;
            int buyukluk;
            int kisi;
            int line;

            Console.Write("Baslik giriniz                                   :");
            baslik = Console.ReadLine();
            Console.Write("Icerik giriniz                                   :");
            icerik = Console.ReadLine();
            Console.Write("Buyukluk seciniz -> XS(1),S(2),M(3),L(4),XL(5)   :");
            buyukluk = int.Parse(Console.ReadLine());
            Console.Write("Kisi ID'sini giriniz                             :");
            kisi = int.Parse(Console.ReadLine());
            Console.Write("Line no giriniz -> TODO(1), INPROGRESS(2), DONE(3)   :");
            line = int.Parse(Console.ReadLine());


            if ((KisiList.ContainsKey(kisi) && buyukluk > 0 && buyukluk <= 5) && line == 1)
                TODO.Add(new Kart(baslik, icerik, KisiList[kisi], (Kart.Buyuluk)buyukluk));
            else if ((KisiList.ContainsKey(kisi) && buyukluk > 0 && buyukluk <= 5) && line == 2)
                INPROGRESS.Add(new Kart(baslik, icerik, KisiList[kisi], (Kart.Buyuluk)buyukluk));
            else if ((KisiList.ContainsKey(kisi) && buyukluk > 0 && buyukluk <= 5) && line == 3)
                DONE.Add(new Kart(baslik, icerik, KisiList[kisi], (Kart.Buyuluk)buyukluk));
            else
                Console.WriteLine("Hatali giris yaptiniz!");


        }


        public void KartSil()
        {
            string baslik;
            string icerik;

            Console.WriteLine("Öncelikle silmek istediginiz kartı seçmeniz gerekiyor.");
            Console.Write("Lutfen kartın başlığını yazınız :    ");
            baslik = Console.ReadLine();
            Console.Write("Lutfen kartın icerigi yazınız :    ");
            icerik = Console.ReadLine();

            bool bulundu = false;

            foreach (var kart in TODO.ToArray())
            {
                if (kart.Baslik == baslik && kart.Icerik == icerik)
                {
                    TODO.Remove(kart);
                    Console.WriteLine("Kart silindi.");
                    bulundu = true;
                }
            }

            foreach (var kart in INPROGRESS.ToArray()) 
            {
                if (kart.Baslik == baslik && kart.Icerik == icerik)
                {
                    INPROGRESS.Remove(kart);
                    Console.WriteLine("Kart silindi.");
                    bulundu = true;
                }
            }

            foreach (var kart in DONE.ToArray())
            {
                if (kart.Baslik == baslik && kart.Icerik == icerik)
                {
                    DONE.Remove(kart);
                    Console.WriteLine("Kart silindi.");
                    bulundu = true;
                }
            }

            if (!bulundu)
            {
                int secim;
                Console.WriteLine("Aradiginiz kriterlere uygun kart bulunamadi.");
                Console.Write("* Silmeyi sonlandirmak için (1)");
                Console.Write("* Yeniden denemek için (2)");
                secim = int.Parse(Console.ReadLine());
                if (secim == 2)
                    KartSil();
                else
                    Console.WriteLine("Kart silme islemi sonlandi.");
            }
        }



        private void KartEkle(Kart kart, ref List<Kart> addList, ref List<Kart> deleteList)
        {
            addList.Add(kart);
            deleteList.Remove(kart);
            Console.WriteLine("Ekleme islemi basarili!");
        }

        private void KartAra(string baslik, string icerik, ref List<Kart> kartListesi, ref bool bulundu, string listName)
        {
            foreach (var kart in kartListesi.ToArray())
            {
                if (kart.Baslik == baslik && kart.Icerik == icerik)
                {
                    bulundu = true;

                    Console.WriteLine("Bulunan Kart Bilgileri:");
                     Console.WriteLine("---------------------------------");
                    Console.WriteLine("Baslik       :   {0}", kart.Baslik);
                    Console.WriteLine("Icerik       :   {0}", kart.Icerik);
                    Console.WriteLine("Atanan Kisi  :   {0}", kart.AtananKisi);
                    Console.WriteLine("Buyukluk     :   {0}", kart.Boyut);
                    Console.WriteLine("Line         :   {0}", listName);
                    Console.WriteLine();
                    Console.WriteLine("Lutfen taşımak istediginiz Line'i secin:");
                    Console.WriteLine("(1) TODO");
                    Console.WriteLine("(2) IN PROGRESS");
                    Console.WriteLine("(3) DONE");
                    int secim = int.Parse(Console.ReadLine());
                    switch (secim)
                    {
                        case 1:
                            KartEkle(kart, ref TODO, ref kartListesi);
                            break;
                        case 2:
                            KartEkle(kart, ref INPROGRESS, ref kartListesi);
                            break;
                        case 3:
                            KartEkle(kart, ref DONE, ref kartListesi);
                            break;
                        default:
                            Console.WriteLine("Hatali bir secim yaptiniz!");
                            break;
                    }


                }
            }
        }

        public void KartTasi()
        {
            string baslik;
            string icerik;
            bool bulundu = false;

            Console.WriteLine("Öncelikle taşımak istediginiz kartı seçmeniz gerekiyor.");
            Console.WriteLine("Lutfen kartın başlığını yazınız :    ");
            baslik = Console.ReadLine();
            Console.WriteLine("Lutfen kartın icerigi yazınız :    ");
            icerik = Console.ReadLine();


            KartAra(baslik, icerik, ref TODO, ref bulundu, "TODO");                
            KartAra(baslik, icerik, ref INPROGRESS, ref bulundu, "INPROGRESS");    
            KartAra(baslik, icerik, ref DONE, ref bulundu, "DONE");               


            if (!bulundu)
            {
                int secim;
                Console.WriteLine("Aradiginiz kriterlere uygun kart bulunamadi.");
                Console.WriteLine("* Taşımayı sonlandirmak için (1)");
                Console.WriteLine("* Yeniden denemek için (2)");
                secim = int.Parse(Console.ReadLine());
                if (secim == 2)
                    KartTasi();
                else
                    Console.WriteLine("Kart taşıma islemi sonlandi.");
            }
        }

        public void BoardListele()
        {
            Console.WriteLine();
            Console.WriteLine("TODO Line");
            Console.WriteLine("---------------------------------");

            foreach (var kart in TODO)
            {
                Console.WriteLine("Baslik       : {0}", kart.Baslik);
                Console.WriteLine("Icerik       : {0}", kart.Icerik);
                Console.WriteLine("Atanan Kisi  : {0}", kart.AtananKisi);
                Console.WriteLine("Buyukluk     : {0}", kart.Boyut);
                Console.WriteLine("-");
            }

            Console.WriteLine();
            Console.WriteLine("IN PROGRESS Line");
            Console.WriteLine("---------------------------------");

            foreach (var kart in INPROGRESS)
            {
                Console.WriteLine("Baslik       : {0}", kart.Baslik);
                Console.WriteLine("Icerik       : {0}", kart.Icerik);
                Console.WriteLine("Atanan Kisi  : {0}", kart.AtananKisi);
                Console.WriteLine("Buyukluk     : {0}", kart.Boyut);
                Console.WriteLine("-");
            }

            Console.WriteLine();
            Console.WriteLine("DONE Line");
            Console.WriteLine("---------------------------------");

            foreach (var kart in DONE)
            {
                Console.WriteLine("Baslik       : {0}", kart.Baslik);
                Console.WriteLine("Icerik       : {0}", kart.Icerik);
                Console.WriteLine("Atanan Kisi  : {0}", kart.AtananKisi);
                Console.WriteLine("Buyukluk     : {0}", kart.Boyut);
                Console.WriteLine("-");
            }

        }
       

        
        
    }
}
