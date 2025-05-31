using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace espor_proje
{
    internal class KullaniciBilgileri
    {
    }
    public static class KullaniciBilgisi
    {
        public static int Id { get; set; }
        public static string Ad { get; set; }
        public static string Email { get; set; }
        public static string Role { get; set; } 

    }
    public static class KullaniciGiris
    {
        public static int KullaniciId { get; set; }  
        public static string KullaniciAd { get; set; }
    }
    public static class Session
    {
        public static int CurrentUserId;
    }
}
