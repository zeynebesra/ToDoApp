//PROJE-2 : Console ToDo Uygulaması

using System;
using System.Collections.Generic;
using System.Text;

/*

Kart İçeriği:
Baslık
Icerik
Atanan Kisi (Takım üyelerişnden biri olmalı)
Büyüklük (XS, S, M, L, XL)

*/

namespace ToDoApp
{
    public class Kart
    {
        public string Baslik { get; set; }
        public string Icerik { get; set; }
        public string AtananKisi { get; set; }
        public Buyuluk Boyut { get; set; }

        public enum Buyuluk
        {
            XS,
            S,
            M,
            L,
            XL
        }

        public Kart(string baslik, string icerik, string atananKisi, Buyuluk boyut)
        {
            Baslik = baslik;
            Icerik = icerik;
            AtananKisi = atananKisi;
            Boyut = boyut;
        }

        
    }
}