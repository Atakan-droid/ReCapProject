using CORE.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
   public static class Messages
    {
        public static string AllDatasError = "Tüm veriler listelenemedi";
        public static string IdyeGore = "Id ye göre getirildi";

        public static string AllUsersListed = "Tüm veriler başarıyla listleendi.";
        public static string NewUserErrorPassword = "Yeni kullanıcı oluşturulamadı.Şifreyi 6 kakaretden uzun tutun lütfen...";

        public static string CustomersListed = "Kullanıcılar başarıyla listelendi";
        public static string RentalSuccess = "Başarılı bir şekilde kiralandı";
        public static string RentalFail = "Daha önceden kiralandığı için kiralanamaz!";
        public static string RentalUpdateFail = "Bu araç kiralanmış zaten";
        public static string RentalAddFail = "Kiralanmadığından eklenemez.";
        public static string RentalListed = "Başarılı bir şekilde listelendi";
        public static string RentalListedById = "Id ye göre listelendi";
        public static string RentalBackSuccess = "Başarılı bir şekilde teslim edildi";

        public static string UserNotFound = "Kullanıcı Bulunamadı";

        public static string PasswordError = "Şifre Hatalı";

        public static string SuccesfulLogin = "Sisteme Giriş başarılı";

        public static string UserAlreadyExists = "Bu kullanıcı zaten Mevcut";

        public static string UserRegistered = "Kullanıcı Başarıyla Kaydedildi";

        public static string AccessTokenCreated = "Token Oluşturuldu";
    }
}
