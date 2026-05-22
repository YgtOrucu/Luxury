# 🌟 Luxury — Premium Otel Rezervasyon ve Canlı Pazar Dinamikleri Platformu

> Bu proje, sevgili hocam **Murat Yücedağ** eğitmenliğinde, **M&Y Yazılım Eğitim Akademi Danışmanlık** bünyesinde geliştirilmiştir.  

---

Luxury, kullanıcılarına üst segment ve kusursuz bir otel rezervasyon deneyimi sunarken, seyahatleri esnasında ihtiyaç duyabilecekleri tüm finansal ve lojistik canlı verileri tek bir panelde birleştiren premium bir web platformudur. 

Koyu tema üzerine inşa edilen altın ve bronz tonlarındaki lüks arayüzü ile modern bir kullanıcı deneyimi sunarken, arka planda tamamen asenkron servis mimarisi barındırır.

---

![.NET](https://img.shields.io/badge/.NET-8.0-purple)
![RapidAPI](https://img.shields.io/badge/RapidAPI-Integration-green)
![AutoMapper](https://img.shields.io/badge/AutoMapper-Enabled-orange)
![Bootstrap](https://img.shields.io/badge/Bootstrap-5-7952B3)
![Architecture](https://img.shields.io/badge/Architecture-N--Tier%20Layered-blue)
![Status](https://img.shields.io/badge/Status-Active-success)

---

# 🚀 Temel Özellikler

## 🌍 Kullanıcı Arayüzü & Rezervasyon Sistemi

| Özellik | Açıklama |
|---|---|
| 🏠 Ana Sayfa & Arama | Şehir/destinasyon seçimi, giriş-çıkış tarihleri, yetişkin/çocuk ve oda optimizasyonlu gelişmiş arama barı. |
| ✨ Seçkin Lokasyonlar | En çok tercih edilen Lüks destinasyonların otel sayıları ve skorlarıyla listelendiği vitrin. |
| 🏨 Otel Listeleme | Değerlendirme puanları, yıldız sayıları, gecelik/toplam fiyat kırılımları ile arama sonuçları listesi. |
| 🛏️ Otel & Oda Detay | Tesis olanakları (Spa, havuz, WiFi), oda konfor detayları ve rezervasyon kartı. |
| 🖼️ Gelişmiş Galeri | Oda ve tesis fotoğraflarının şık grid yerleşimi ve interaktif Lightbox/Slider mimarisi. |

---

## 📊 Canlı Veri (Market Data) Dashboard

| Modül | Açıklama |
|---|---|
| 💱 Döviz Kurları | USD/TRY, EUR/TRY, GBP/TRY gibi kurların anlık değerleri ve yüzde değişim oranları. |
| ☀️ Hava Durumu | Ana lokasyonların anlık sıcaklık, rüzgar ve nem VE bir çok verinin takibi. |
| 🪙 Kripto Para | BTC, ETH, USDT, BNB gibi popüler varlıkların anlık piyasa fiyatları ve trendleri. |
| ⛽ Akaryakıt Fiyatları | Bölgesel bazda güncel Benzin 95, Motorin ve Gaz fiyatlarının eşzamanlı takibi. |

---

# 🧠 Öne Çıkan Yazılım Yaklaşımları

- N-Tier (Çok Katmanlı) Mimari tasarımı
- IHttpClientFactory ile güvenli ve performanslı harici API yönetimi
- Tip güvenli Options Pattern (`RapidApiOptions`) ile gizli anahtar yönetimi
- AutoMapper tabanlı asenkron DTO transfer yapısı
- System.Text.Json ile dinamik polimorfik JSON serileştirme
- Responsive Luxury Custom Dark UI tasarımı
- Gelişmiş ViewComponent modüler arayüz yapısı

---

# 🛠️ Kullanılan Teknolojiler

| Kategori | Teknolojiler |
|---|---|
| Backend | .NET 8.0 / ASP.NET Core Web API |
| Frontend | ASP.NET Core MVC (Razor Pages) |
| Veri Kaynağı | RapidAPI Servis Entegrasyonları |
| Harici İletişim | HttpClient / IHttpClientFactory |
| ORM / Eşleme | AutoMapper NuGet |
| UI Framework | Bootstrap 5 & Custom Premium Gold/Dark Theme |
| Mimari | Katmanlı Mimari (API, Business, Dto, UI) |

---

# 🏗️ Mimari Yapı

```bash
       Luxury.UI (Kullanıcı Arayüzü & ViewComponents)
                        ↓
       Luxury.API (RESTful Servisler & API Gateway)
                        ↓
       Luxury.BusinessLayer (Manager & Core Logic)
                        ↓
       Luxury.DtoLayer (Data Transfer Objects)

```

---

# ⚙️ Kurulum ve Yapılandırma

## Repository Klonlama

```bash
git clone https://github.com/YgtOrucu/Luxury.git
```

---

## API Yapılandırması (appsettings.json)

```bash
 "RapidApi": {
   "ApiKey": "API_KEY",

   "Services": {
     "Currency": {
       "BaseUrl": "https://doviz-ve-altin-fiyatlari-try.p.rapidapi.com",
       "Host": "doviz-ve-altin-fiyatlari-try.p.rapidapi.com",
       "Endpoints": {
         "ExchangeRate": "/economy/currency/exchange-rate"
       }
     }
   }
}
```

---

## 📸 Proje Galerisi (Arayüz Tasarımı)

<details>
  <summary><b>🔍 Resimleri görüntülemek için tıklayın</b></summary>
  <br>
  <p align="center">
    <img width="100%" alt="Ekran görüntüsü 2026-05-22 233418" src="https://github.com/user-attachments/assets/ce60156c-d3cb-4748-a1cf-775a39f8337a" />
    <br><br>
    <img width="100%" alt="Ekran görüntüsü 2026-05-22 233454" src="https://github.com/user-attachments/assets/c2667073-b0bc-4ab5-b46e-4e97904df6e7" />
    <br><br>
    <img width="100%" alt="Ekran görüntüsü 2026-05-22 233510" src="https://github.com/user-attachments/assets/7a20a91a-3558-4aa8-befe-37fa875757d0" />
    <br><br>    
    <img width="100%" alt="Ekran görüntüsü 2026-05-22 233520" src="https://github.com/user-attachments/assets/86c2970c-205e-4ae5-9be5-d616471618da" />
    <br><br>
    <img width="100%" alt="Ekran görüntüsü 2026-05-22 233615" src="https://github.com/user-attachments/assets/148a493b-f11f-4a62-a721-84bdb0b3645f" />
    <br><br>
    <img width="100%" alt="Ekran görüntüsü 2026-05-22 233641" src="https://github.com/user-attachments/assets/1868961e-3870-4636-8836-9d732d4208cf" />
    <br><br>
    <img width="100%" alt="Ekran görüntüsü 2026-05-22 234051" src="https://github.com/user-attachments/assets/5dc3b3d9-ebee-4101-8209-3b3434095634" />
    <br><br>
    <img width="100%" alt="Ekran görüntüsü 2026-05-22 234115" src="https://github.com/user-attachments/assets/49634950-6072-4e35-9bb4-6157f049eacc" />
    <br><br>
    <img width="100%" alt="Ekran görüntüsü 2026-05-22 234142" src="https://github.com/user-attachments/assets/675ee16e-ea76-420c-93a0-f6e19bb9195f" />
    <br><br>
    <img width="100%" alt="Ekran görüntüsü 2026-05-22 234237" src="https://github.com/user-attachments/assets/1c2b5589-9004-4d30-92e5-c812d905c144" />
    <br><br>
    <img width="100%" alt="Ekran görüntüsü 2026-05-22 234250" src="https://github.com/user-attachments/assets/934e2cf0-2230-4196-96a9-0086f9a6a902" />
    <br><br>
    <img width="100%" alt="Ekran görüntüsü 2026-05-22 234319" src="https://github.com/user-attachments/assets/b60a21fe-6649-4787-b694-368064d7abfc" />
    <br><br>
    <img width="100%" alt="Ekran görüntüsü 2026-05-22 234352" src="https://github.com/user-attachments/assets/cc492b29-789c-490a-a3d4-8abd767b63f3" />
    <br><br>
    <img width="100%" alt="Ekran görüntüsü 2026-05-22 234417" src="https://github.com/user-attachments/assets/953f6b4e-7ccb-44f5-9860-d9aa69e5da6f" />
    <br><br>
  </p>
</details>

---

# 💎 Luxury

> Premium konaklama deneyimi. Güçlü ve asenkron veri altyapısı için tasarlandı.
