# KJ.Tourify

Tur ve seyahat şirketleri için geliştirilmiş, **ASP.NET Core MVC** tabanlı bir web sitesi. Site içeriğinin tamamı (sayfa metinleri, turlar, şehirler, galeri, yorumlar) yönetim paneli üzerinden düzenlenebilir.

## Özellikler

**Ziyaretçi tarafı**
- Ana sayfa, Hakkımızda, Hizmetler, Rehberler ve İletişim sayfaları
- Tur listesi; şehir ve kişi sayısına göre filtreleme
- Tur detay sayfası ve müşteri yorumları
- Ziyaretçilerin profil fotoğraflı yorum bırakabilmesi
- Kategorilere ayrılmış fotoğraf galerisi
- Rezervasyon sayfası
- SMTP üzerinden e-posta gönderen iletişim formu

**Yönetim paneli (`/Management`)**
- Cookie tabanlı oturum açma
- Tüm sayfa içeriklerinin düzenlenmesi
- Tur, şehir, galeri kategorisi, galeri öğesi ve yorum yönetimi (ekle / güncelle / sil)
- Görsel yükleme

## Kullanılan Teknolojiler

- .NET 10, ASP.NET Core MVC
- Entity Framework Core 10 (SQL Server)
- Cookie Authentication
- Razor View'lar ve View Component'ler
- Bootstrap, jQuery, Owl Carousel, Lightbox

## Proje Yapısı

```
KJ.Tourify.WebUI/
├── Areas/Management/   # Yönetim paneli (controller ve view'lar)
├── Controllers/        # Ziyaretçi sayfaları
├── Models/
│   ├── Entities/       # Veritabanı tabloları
│   └── ViewModels/
├── Migrations/         # EF Core migration'ları
├── ViewComponents/
├── Utils/              # Dosya yükleme ve yardımcı sınıflar
├── Views/
└── wwwroot/            # CSS, JS, görseller ve yüklenen dosyalar
_db/                    # Yardımcı SQL betikleri
```

## Kurulum

### Gereksinimler
- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- SQL Server (Express veya LocalDB yeterli)

### 1. Projeyi klonla
```bash
git clone https://github.com/Kayajan07/KJ.Tourify.git
cd KJ.Tourify/KJ.Tourify.WebUI
```

### 2. Ayarları gir
`appsettings.json` dosyasında yalnızca örnek değerler bulunur. Gerçek bağlantı ve SMTP bilgilerini **user-secrets** ile gir, böylece bu bilgiler repoya girmez:

```bash
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=.\SQLEXPRESS;Database=TourifyDb;Trusted_Connection=True;Encrypt=False;"
dotnet user-secrets set "Smtp:Host" "mail.alanadiniz.com"
dotnet user-secrets set "Smtp:Port" "587"
dotnet user-secrets set "Smtp:Email" "iletisim@alanadiniz.com"
dotnet user-secrets set "Smtp:Password" "SMTP_ŞİFRENİZ"
```

Sunucuda ortam değişkenleri de kullanılabilir (örneğin `ConnectionStrings__DefaultConnection`, `Smtp__Password`).

### 3. Veritabanını oluştur
```bash
dotnet tool install --global dotnet-ef   # yüklü değilse
dotnet ef database update
```

### 4. Yönetici kullanıcısı ekle
Panele giriş için `Users` tablosuna bir kayıt ekle:

```sql
INSERT INTO Users (Id, Username, Password)
VALUES (NEWID(), 'admin', 'guclu-bir-sifre');
```

### 5. Çalıştır
```bash
dotnet run
```

- Site: `https://localhost:7066`
- Yönetim paneli: `https://localhost:7066/Management`

## Lisans

Bu proje kişisel/portföy amaçlı geliştirilmiştir.
