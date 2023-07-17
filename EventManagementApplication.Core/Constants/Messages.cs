using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementApplication.Core.Constants
{
    public static class Messages
    {
        public static string EventAdded = "Etkinlik başarıyla eklendi";
        public static string EventDeleted = "Etkinlik başarıyla silindi";
        public static string EventUpdated = "Entkinlik başarıyla güncellendi";

        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";

        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string EventNameAlreadyExists = "Etkinlik ismi zaten mevcut";

    }
}
