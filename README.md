# ⚽ FM26 Patch Fixer

<div align="center">

![Version](https://img.shields.io/badge/version-1.0.0-blue.svg)
![Platform](https://img.shields.io/badge/platform-Windows-blue.svg)
![.NET](https://img.shields.io/badge/.NET-6.0-purple.svg)
![License](https://img.shields.io/badge/license-Free-green.svg)

**Football Manager 2026 için gelişmiş yama ve optimizasyon aracı**


Lisans düzeltme • Arayüz hızlandırma • Tek dosya

[📥 İndir](#-kurulum) • [📖 Kullanım](#-kullanım) • [🐛 Sorun Bildirme](../../issues)

</div>

---

## 📋 İçindekiler

- [Özellikler](#-özellikler)
- [Kurulum](#-kurulum)
- [Kullanım](#-kullanım)
- [Yapılan İşlemler](#-yapılan-i̇şlemler)
- [Ekran Görüntüleri](#-ekran-görüntüleri)
- [SSS](#-sss-sık-sorulan-sorular)
- [Katkıda Bulunma](#-katkıda-bulunma)
- [Lisans](#-lisans)

---

## ✨ Özellikler

### 🎯 Ana Amaç
- ✅ Sürekli güncelleme alıp bozulan yamaları kolayca yeniden kurmak.

### 🏆 Lisans Yaması
- ✅ Takım ve oyuncu isimlerini düzeltir
- ✅ 29 gereksiz lisans dosyasını temizler
- ✅ FMScout yamaları ile tam uyumlu
- ✅ Otomatik yedekleme sistemi

### ⚡ Arayüz Hızlandırma
- ✅ Oyun arayüzünü optimize eder
- ✅ Menü geçişlerini hızlandırır
- ✅ UI performansını artırır
- ✅ **Yama: BassyBoy**

### 🎯 Genel
- ✅ **Tek .exe dosyası** - Başka hiçbir şey gerektirmez
- ✅ **Self-contained** - .NET yüklü olmasa bile çalışır
- ✅ **Modern GUI** - Koyu tema, kullanıcı dostu arayüz
- ✅ **Otomatik tespit** - Steam ve Epic Games yollarını otomatik bulur
- ✅ **Seçimli işlemler** - İstediğiniz özellikleri seçin
- ✅ **Detaylı log** - Her işlem adım adım gösterilir
- ✅ **Güvenli** - Sadece gerekli dosyalara dokunur

---

## 📥 Kurulum

### Hazır .exe (Önerilen)

1. **İndirin**
   ```
   Releases bölümünden FM26Patcher.exe dosyasını indirin
   ```

2. **Çalıştırın**
   ```
   İndirdiğiniz .exe dosyasını çift tıklayın
   ```

3. **Kullanın**
   ```
   İstediğiniz işlemleri seçip başlatın!
   ```

> **Not:** Windows Defender "Bilinmeyen yayımcı" uyarısı gösterebilir. "Ek bilgi" → "Yine de çalıştır" seçeneğini kullanın.

### Kaynak Koddan Derleme

#### Gereksinimler
- Windows 10/11
- .NET 6.0 SDK ([İndirin](https://dotnet.microsoft.com/download/dotnet/6.0))

#### Adımlar

```bash
# 1. Repoyu klonlayın
git clone https://github.com/yourusername/fm26-patch-fixer.git
cd fm26-patch-fixer

# 2. Projeyi derleyin
dotnet publish --configuration Release --output publish --self-contained true -p:PublishSingleFile=true

# 3. Çalıştırın
cd publish
./FM26Patcher.exe
```

**veya**

```bash
# Windows için hazır script
build.bat
```

---

## 🎮 Kullanım

### Temel Kullanım

1. **FM26'yı kapatın**
   > İşlem sırasında oyun çalışmamalı

2. **FM26Patcher.exe'yi çalıştırın**

3. **İşlemleri seçin**
   - ✓ **Lisans Yaması** - Takım ve oyuncu isimleri düzeltilir
   - ⚡ **Arayüz Hızlandırma** - UI performansı artırılır

4. **"▶ İşlemleri Başlat" butonuna tıklayın**

5. **Arayüz hızlandırma seçildiyse:**
   - **Evet** → Yedek konumu seçin
   - **Hayır** → Yedeksiz devam et
   - **İptal** → İşlemi iptal et

6. **FM26'yı yeniden başlatın**

### Desteklenen Platformlar

#### Steam
```
C:\Program Files (x86)\Steam\steamapps\common\Football Manager 26\
C:\Program Files\Steam\steamapps\common\Football Manager 26\
D:\Steam\steamapps\common\Football Manager 26\
```

#### Epic Games
```
C:\Program Files\Epic Games\FootballManager26\
D:\Epic Games\FootballManager26\
```

> Program otomatik olarak C:, D:, E: ve F: disklerini tarar.

---

## 📋 Yapılan İşlemler

### 🏆 Lisans Yaması

<details>
<summary><b>1. lnc/all klasöründen silinen dosyalar (12 adet)</b></summary>

```
- ac milan (wom).lnc
- acc Inter unlic 26.lnc
- acmilan unlic 26.lnc
- fake.lnc
- inter (wom).lnc
- inter unlic 26.lnc
- japanese names.lnc
- lazio (wom).lnc
- lic_dan_swe_fra.lnc
- licensing club name_fm26.lnc
- men lazio.lnc
- men.atalanta.lnc
```
</details>

<details>
<summary><b>2. lnc/all klasörüne eklenen dosyalar (2 adet)</b></summary>

```
+ FM26 Fix by FMScout.lnc
+ FM26 Club Names by FMScout.lnc
```
</details>

<details>
<summary><b>3. edt/permanent klasöründen silinen dosyalar (1 adet)</b></summary>

```
- fake.edt
```
</details>

<details>
<summary><b>4. dbc/permanent klasöründen silinen dosyalar (12 adet)</b></summary>

```
- 1_japan_removed_clubs.dbc
- brazil_kits.dbc
- england.dbc
- forbidden names.dbc
- france.dbc
- j league non player.dbc
- japan_fake.dbc
- japan_unlicensed_random_names.dbc
- licensing_post_data_lock.dbc
- licensing2.dbc
- licensing26.dbc
- netherlands.dbc
```
</details>

<details>
<summary><b>5. dbc/permanent/language klasöründen silinen dosyalar (2 adet)</b></summary>

```
- Licensing2.dbc
- Licensing2_chn.dbc
```
</details>

**Toplam:** 29 dosya siliniyor, 2 dosya ekleniyor

### ⚡ Arayüz Hızlandırma

```
Yol: fm_Data/StreamingAssets/aa/StandaloneWindows64/
Dosya: ui-panelids_assets_all.bundle

✓ Orijinal dosya yedeklenir (opsiyonel)
✓ Optimize edilmiş dosya kopyalanır
✓ UI performansı artırılır
```

**Yama Yapımcısı:** [BassyBoy](https://github.com/bassyboy)

---

## 📸 Ekran Görüntüleri

<img width="891" height="694" alt="uyg" src="https://github.com/user-attachments/assets/76688434-00c4-48cc-ab59-b63018d32d1d" />

### Ana Ekran
```
╔═══════════════════════════════════════════════════╗
║  ⚽ FM26 Patch Fixer                              ║
║  Football Manager 2026 - Lisans ve Optimizasyon  ║
╠═══════════════════════════════════════════════════╣
║  ┌─────────────────────────────────────────────┐ ║
║  │ 🔧 Uygulanacak İşlemler:                   │ ║
║  │                                             │ ║
║  │  [✓] Lisans Yaması                         │ ║
║  │      Takım ve oyuncu isimleri düzeltilir   │ ║
║  │                                             │ ║
║  │  [⚡] Arayüz Hızlandırma                   │ ║
║  │      Oyun arayüzü optimize edilir          │ ║
║  └─────────────────────────────────────────────┘ ║
║                                                   ║
║  [İşlem Günlüğü - Renkli log mesajları]         ║
║  [▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░░░] 75%                      ║
║                                                   ║
║  [▶ İşlemleri Başlat]      [✖ Çıkış]            ║
╚═══════════════════════════════════════════════════╝
```

### İşlem Başarılı
```
✓ FM26 bulundu!
📁 C:\Program Files\Steam\steamapps\common\Football Manager 26\

ADIM 1/5: lnc/all klasöründeki dosyalar siliniyor...
  ✓ Silindi: fake.lnc
  ✓ Silindi: inter unlic 26.lnc
  ► 12 dosya başarıyla silindi

✓ TÜM İŞLEMLER BAŞARIYLA TAMAMLANDI!
⚠ ÖNEMLI: FM26'yı yeniden başlatın!
```

---

## ❓ SSS (Sık Sorulan Sorular)

### ❓ Program neden 150 MB?

Self-contained uygulama olduğu için .NET Runtime dahil edilmiştir. Bu sayede hiçbir PC'de herhangi bir kurulum gerektirmez.

### ❓ Antivirüs uyarısı veriyor?

Windows Defender bazen bilinmeyen .exe dosyaları için uyarı verir. Program tamamen güvenlidir. "Ek bilgi" → "Yine de çalıştır" seçeneğini kullanın.

### ❓ FM26 bulunamadı hatası alıyorum?

- Oyunun Steam veya Epic Games üzerinden kurulu olduğundan emin olun
- Program C:, D:, E:, F: disklerini otomatik tarar
- Farklı bir konuma kuruluysa, ilgili diski kontrol edin

### ❓ Dosya silinemedi hatası alıyorum?

- FM26'yı tamamen kapatın (Görev Yöneticisi'nden kontrol edin)
- Programı yönetici olarak çalıştırın
- Antivirüs programını geçici olarak kapatın

### ❓ Yedek dosyayı nasıl geri yüklerim?

Yedek konumuna gidin, `.BACKUP` uzantılı dosyayı bulun ve orijinal konuma kopyalayın. Dosya adından `.BACKUP.tarih_saat` kısmını silin.

### ❓ Hangi işlemleri seçmeliyim?

- **Sadece lisans sorunları varsa:** Sadece "Lisans Yaması"
- **Sadece arayüz yavaşsa:** Sadece "Arayüz Hızlandırma"
- **Her ikisi de:** Her iki seçeneği de işaretleyin (önerilir)

---

## 🛡️ Güvenlik

- ✅ Program **sadece** belirtilen dosyaları işler
- ✅ Hiçbir dosyayı internet'e **göndermez**
- ✅ Kayıt defterinde değişiklik **yapmaz**
- ✅ Otomatik yedekleme sistemi ile **güvenli**
- ✅ **Açık kaynak** - Kaynak kodları inceleyebilirsiniz

---

## 🤝 Katkıda Bulunma

Katkılarınızı bekliyoruz! Projeye katkıda bulunmak için:

1. Bu repo'yu fork edin
2. Yeni bir branch oluşturun (`git checkout -b feature/amazing-feature`)
3. Değişikliklerinizi commit edin (`git commit -m 'feat: Add amazing feature'`)
4. Branch'inizi push edin (`git push origin feature/amazing-feature`)
5. Pull Request oluşturun

### Katkıda Bulunanlar

- **Arayüz Hızlandırma Yaması:** [BassyBoy](https://github.com/bassyboy)
- **Lisans Yamaları:** FMScout
- **Uygulama Geliştirme:** Sedokan54

---

## 📝 Lisans

Bu proje **ücretsiz** bir projedir. Ticari amaçla kullanılamaz.

---

## 💡 İpuçları

- 🔹 İşlem öncesi `2600` klasörünü yedekleyin (opsiyonel)
- 🔹 İlk çalıştırmada programı yönetici olarak çalıştırın
- 🔹 FM26'yı kapatmayı unutmayın
- 🔹 Gerçek FMScout dosyalarına sahipseniz, onları `lnc\all` klasörüne manuel kopyalayın

---

## 🔗 Bağlantılar

- 📦 [Releases](../../releases) - Hazır .exe dosyalarını indirin
- 🐛 [Issues](../../issues) - Sorun bildirin veya öneride bulunun
- 📚 [Wiki](../../wiki) - Detaylı dokümantasyon
- 💬 [Discussions](../../discussions) - Toplulukla sohbet edin

---

## 🎮 Football Manager 2026

<div align="center">

**İyi oyunlar! ⚽**

Made with ❤️ by FM26 Community

[⬆ Başa Dön](#-fm26-patch-fixer)

</div>

---

## 📊 Teknik Detaylar

<details>
<summary><b>Teknoloji Stack</b></summary>

```
- Dil: C# (.NET 6.0)
- Framework: Windows Forms
- IDE: Visual Studio 2022 / Rider
- Build: dotnet CLI
- Dağıtım: Self-contained single-file executable
```
</details>

<details>
<summary><b>Proje Yapısı</b></summary>

```
FM26Patcher/
├── Program.cs              # Giriş noktası
├── MainForm.cs             # İş mantığı
├── MainForm.Designer.cs    # GUI tasarımı
├── FM26Patcher.csproj      # Proje dosyası
├── build.bat               # Build script
├── publish/
│   └── FM26Patcher.exe    # Hazır uygulama
└── Resources/              # Gömülü dosyalar
    ├── fm26fixer.ico
    ├── ui-panelids_assets_all.bundle
    ├── FM26 Fix by FMScout.lnc
    └── FM26 Club Names by FMScout.lnc
```
</details>

<details>
<summary><b>Build Komutları</b></summary>

```bash
# Temizlik
dotnet clean

# Normal build
dotnet build --configuration Release

# Self-contained tek dosya
dotnet publish --configuration Release \
  --output publish \
  --self-contained true \
  -p:PublishSingleFile=true \
  -p:IncludeNativeLibrariesForSelfExtract=true

# Windows için (build.bat)
build.bat
```
</details>

---

<div align="center">

**⭐ Beğendiyseniz yıldız vermeyi unutmayın! ⭐**

</div>
