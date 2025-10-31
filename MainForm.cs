using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace FM26Patcher
{
    public partial class MainForm : Form
    {
        private string? fm26Path = null;
        private int totalOperations = 0;
        private int completedOperations = 0;

        public MainForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            // Hiçbir seçim yapılmadıysa uyar
            if (!chkLisansYamasi.Checked && !chkArayuzHizlandirma.Checked)
            {
                MessageBox.Show("Lütfen en az bir işlem seçin!\n\n✓ Lisans Yaması\n✓ Arayüz Hızlandırma", 
                    "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnStart.Enabled = false;
            chkLisansYamasi.Enabled = false;
            chkArayuzHizlandirma.Enabled = false;
            progressBar.Value = 0;
            txtLog.Clear();
            completedOperations = 0;
            
            // Toplam işlem sayısını hesapla
            totalOperations = 0;
            if (chkLisansYamasi.Checked) totalOperations += 5;
            if (chkArayuzHizlandirma.Checked) totalOperations += 1;

            LogMessage("═══════════════════════════════════════════════════════════", Color.DarkBlue);
            LogMessage("    FM26 PATCH FIXER", Color.DarkBlue);
            LogMessage("═══════════════════════════════════════════════════════════", Color.DarkBlue);
            LogMessage("", Color.Black);

            // Seçilen işlemleri göster
            if (chkLisansYamasi.Checked)
                LogMessage("✓ Lisans Yaması SEÇILDI", Color.Green);
            if (chkArayuzHizlandirma.Checked)
                LogMessage("✓ Arayüz Hızlandırma SEÇILDI", Color.Green);
            
            LogMessage("", Color.Black);

            // FM26 yolunu bul
            LogMessage("🔍 FM26 kurulum yolu aranıyor...", Color.Black);
            fm26Path = FindFM26Path();

            if (fm26Path == null)
            {
                LogMessage("", Color.Black);
                LogMessage("✗ HATA: FM26 kurulumu bulunamadı!", Color.Red);
                LogMessage("  Lütfen oyunun Steam veya Epic Games üzerinden kurulu olduğundan emin olun.", Color.Red);
                MessageBox.Show("FM26 kurulumu bulunamadı!\n\nLütfen oyunun Steam veya Epic Games üzerinden kurulu olduğundan emin olun.", 
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetButtons();
                return;
            }

            LogMessage($"✓ FM26 bulundu!", Color.Green);
            LogMessage($"  📁 {fm26Path}", Color.Gray);
            LogMessage("", Color.Black);

            // LISANS YAMASI
            if (chkLisansYamasi.Checked)
            {
                ApplyLisansYamasi();
            }

            // ARAYÜZ HIZLANDIRMA
            if (chkArayuzHizlandirma.Checked)
            {
                ApplyArayuzHizlandirma();
            }

            // Tamamlandı
            LogMessage("", Color.Black);
            LogMessage("═══════════════════════════════════════════════════════════", Color.Green);
            LogMessage("    ✓ TÜM İŞLEMLER BAŞARIYLA TAMAMLANDI!", Color.Green);
            LogMessage("═══════════════════════════════════════════════════════════", Color.Green);
            LogMessage("", Color.Black);
            LogMessage("⚠ ÖNEMLI: FM26'yı yeniden başlatın!", Color.DarkOrange);

            // Yapılan işlemleri belirle
            string completedTasks = "";
            if (chkLisansYamasi.Checked && chkArayuzHizlandirma.Checked)
                completedTasks = "✓ Lisans yaması uygulandı\n✓ Arayüz hızlandırma uygulandı";
            else if (chkLisansYamasi.Checked)
                completedTasks = "✓ Lisans yaması başarıyla uygulandı";
            else if (chkArayuzHizlandirma.Checked)
                completedTasks = "✓ Arayüz hızlandırma başarıyla uygulandı";

            MessageBox.Show($"İşlemler başarıyla tamamlandı!\n\n{completedTasks}\n\n⚠ FM26'yı yeniden başlatmayı unutmayın!", 
                "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ResetButtons();
        }

        private void ApplyLisansYamasi()
        {
            LogMessage("╔═══════════════════════════════════════════════════════════╗", Color.DarkBlue);
            LogMessage("║              LISANS YAMASI UYGULANIY OR               ║", Color.DarkBlue);
            LogMessage("╚═══════════════════════════════════════════════════════════╝", Color.DarkBlue);
            LogMessage("", Color.Black);

            // ADIM 1: lnc/all dosyalarını sil
            LogMessage("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━", Color.DarkGray);
            LogMessage("ADIM 1/5: lnc/all klasöründeki dosyalar siliniyor...", Color.DarkBlue);
            LogMessage("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━", Color.DarkGray);

            var lncFiles = new List<string>
            {
                "ac milan (wom).lnc", "acc Inter unlic 24.lnc", "acmilan unlic 24.lnc",
                "fake.lnc", "inter (wom).lnc", "inter unlic 24.lnc", "japanese names.lnc",
                "lazio (wom).lnc", "lic_dan_swe_fra.lnc", "licensing club name_fm24.lnc",
                "men lazio.lnc", "men.atalanta.lnc"
            };

            DeleteFilesInPath(@"lnc\all", lncFiles);
            UpdateProgress();

            // ADIM 2
            LogMessage("", Color.Black);
            LogMessage("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━", Color.DarkGray);
            LogMessage("ADIM 2/5: Yeni .lnc dosyaları kontrol ediliyor...", Color.DarkBlue);
            LogMessage("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━", Color.DarkGray);
            CreateLncFiles();
            UpdateProgress();

            // ADIM 3
            LogMessage("", Color.Black);
            LogMessage("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━", Color.DarkGray);
            LogMessage("ADIM 3/5: edt/permanent klasöründeki fake.edt siliniyor...", Color.DarkBlue);
            LogMessage("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━", Color.DarkGray);
            DeleteFilesInPath(@"edt\permanent", new List<string> { "fake.edt" });
            UpdateProgress();

            // ADIM 4
            LogMessage("", Color.Black);
            LogMessage("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━", Color.DarkGray);
            LogMessage("ADIM 4/5: dbc/permanent klasöründeki dosyalar siliniyor...", Color.DarkBlue);
            LogMessage("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━", Color.DarkGray);

            var dbcPermanentFiles = new List<string>
            {
                "1_japan_removed_clubs.dbc", "brazil_kits.dbc", "england.dbc", "forbidden names.dbc",
                "france.dbc", "j league non player.dbc", "japan_fake.dbc", 
                "japan_unlicensed_random_names.dbc", "licensing_post_data_lock.dbc",
                "licensing2.dbc", "licensing26.dbc", "netherlands.dbc"
            };

            DeleteFilesInPath(@"dbc\permanent", dbcPermanentFiles);
            UpdateProgress();

            // ADIM 5
            LogMessage("", Color.Black);
            LogMessage("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━", Color.DarkGray);
            LogMessage("ADIM 5/5: dbc/permanent/language klasöründeki dosyalar siliniyor...", Color.DarkBlue);
            LogMessage("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━", Color.DarkGray);

            var dbcLanguageFiles = new List<string> { "Licensing2.dbc", "Licensing2_chn.dbc" };
            DeleteFilesInPath(@"dbc\permanent\language", dbcLanguageFiles);
            UpdateProgress();

            LogMessage("", Color.Black);
            LogMessage("✓ Lisans yaması başarıyla uygulandı!", Color.Green);
        }

        private void ApplyArayuzHizlandirma()
        {
            LogMessage("", Color.Black);
            LogMessage("╔═══════════════════════════════════════════════════════════╗", Color.DarkCyan);
            LogMessage("║           ARAYÜZ HIZLANDIRMA UYGULANIY OR             ║", Color.DarkCyan);
            LogMessage("╚═══════════════════════════════════════════════════════════╝", Color.DarkCyan);
            LogMessage("", Color.Black);

            // FM26 ana dizinini bul (2600 değil, ana dizin)
            string? fm26MainPath = FindFM26MainPath();
            
            if (fm26MainPath == null)
            {
                LogMessage("✗ FM26 ana dizini bulunamadı!", Color.Red);
                return;
            }

            string bundlePath = Path.Combine(fm26MainPath, @"fm_Data\StreamingAssets\aa\StandaloneWindows64");
            string targetFile = Path.Combine(bundlePath, "ui-panelids_assets_all.bundle");

            LogMessage($"📁 Hedef dizin: {bundlePath}", Color.Gray);
            LogMessage("", Color.Black);

            // Dosya var mı kontrol et
            if (!File.Exists(targetFile))
            {
                LogMessage("✗ Orijinal ui-panelids_assets_all.bundle dosyası bulunamadı!", Color.Red);
                LogMessage($"  Aranan konum: {targetFile}", Color.Gray);
                return;
            }

            LogMessage("✓ Orijinal dosya bulundu", Color.Green);
            LogMessage("", Color.Black);

            // Yedek alma hakkında bilgilendir
            var backupInfo = MessageBox.Show(
                "Arayüz hızlandırma için orijinal dosya yedeklenecektir.\n\n" +
                "📁 Dosya: ui-panelids_assets_all.bundle\n\n" +
                "Yedek dosyasının kaydedileceği konumu seçmek ister misiniz?\n" +
                "(Hayır derseniz yedek alınmadan işlem yapılır)",
                "Yedekleme Konumu",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question);

            bool backupTaken = false;

            if (backupInfo == DialogResult.Yes)
            {
                // Yedek konumu seç
                LogMessage("📂 Yedek konumu seçiniz...", Color.DarkOrange);
                
                using (var folderDialog = new FolderBrowserDialog())
                {
                    folderDialog.Description = "Yedek dosyanın kaydedileceği klasörü seçin";
                    folderDialog.ShowNewFolderButton = true;

                    if (folderDialog.ShowDialog() == DialogResult.OK)
                    {
                        string backupFolder = folderDialog.SelectedPath;
                        string backupFile = Path.Combine(backupFolder, $"ui-panelids_assets_all.bundle.BACKUP.{DateTime.Now:yyyyMMdd_HHmmss}");

                        try
                        {
                            // Yedeği al
                            LogMessage($"💾 Yedek alınıyor: {backupFile}", Color.DarkCyan);
                            File.Copy(targetFile, backupFile, false);
                            LogMessage("✓ Yedek başarıyla alındı!", Color.Green);
                            backupTaken = true;
                        }
                        catch (Exception ex)
                        {
                            LogMessage($"✗ Yedek alınamadı: {ex.Message}", Color.Red);
                            LogMessage("⚠ İşlem yine de devam edecek...", Color.Orange);
                        }
                    }
                }
            }
            else if (backupInfo == DialogResult.Cancel)
            {
                LogMessage("⚠ Arayüz hızlandırma kullanıcı tarafından iptal edildi", Color.Orange);
                UpdateProgress();
                return;
            }
            else // DialogResult.No
            {
                LogMessage("⚠ Yedekleme atlandı, doğrudan işlem yapılıyor...", Color.Orange);
            }

            LogMessage("", Color.Black);

            try
            {
                // Gömülü dosyayı al
                LogMessage("📋 Yeni dosya kopyalanıyor... (Yama: BassyBoy)", Color.DarkCyan);
                
                var assembly = Assembly.GetExecutingAssembly();
                var resourceName = "FM26Patcher.ui-panelids_assets_all.bundle";
                
                using (Stream? resourceStream = assembly.GetManifestResourceStream(resourceName))
                {
                    if (resourceStream == null)
                    {
                        LogMessage("✗ Gömülü arayüz dosyası bulunamadı!", Color.Red);
                        return;
                    }

                    using (FileStream fileStream = File.Create(targetFile))
                    {
                        resourceStream.CopyTo(fileStream);
                    }
                }
                
                LogMessage("✓ Arayüz hızlandırma dosyası başarıyla kopyalandı!", Color.Green);
                if (backupTaken)
                {
                    LogMessage("  ℹ Orijinal dosya yedeklendi", Color.DarkCyan);
                }
                else
                {
                    LogMessage("  ⚠ Yedek alınmadı", Color.Orange);
                }
                
                UpdateProgress();
            }
            catch (Exception ex)
            {
                LogMessage($"✗ Hata oluştu: {ex.Message}", Color.Red);
            }
        }

        private string? FindFM26Path()
        {
            var drives = new[] { "C:", "D:", "E:", "F:" };
            var steamPaths = new[]
            {
                @"\Program Files (x86)\Steam\steamapps\common\Football Manager 26\shared\data\database\db\2600",
                @"\Program Files\Steam\steamapps\common\Football Manager 26\shared\data\database\db\2600",
                @"\Steam\steamapps\common\Football Manager 26\shared\data\database\db\2600"
            };
            var epicPaths = new[]
            {
                @"\Program Files\Epic Games\FootballManager26\shared\data\database\db\2600",
                @"\Epic Games\FootballManager26\shared\data\database\db\2600"
            };

            foreach (var drive in drives)
            {
                foreach (var path in steamPaths.Concat(epicPaths))
                {
                    string fullPath = drive + path;
                    if (Directory.Exists(fullPath))
                    {
                        return fullPath;
                    }
                }
            }

            return null;
        }

        private string? FindFM26MainPath()
        {
            var drives = new[] { "C:", "D:", "E:", "F:" };
            var steamPaths = new[]
            {
                @"\Program Files (x86)\Steam\steamapps\common\Football Manager 26",
                @"\Program Files\Steam\steamapps\common\Football Manager 26",
                @"\Steam\steamapps\common\Football Manager 26"
            };
            var epicPaths = new[]
            {
                @"\Program Files\Epic Games\FootballManager26",
                @"\Epic Games\FootballManager26"
            };

            foreach (var drive in drives)
            {
                foreach (var path in steamPaths.Concat(epicPaths))
                {
                    string fullPath = drive + path;
                    if (Directory.Exists(fullPath))
                    {
                        return fullPath;
                    }
                }
            }

            return null;
        }

        private void DeleteFilesInPath(string relativePath, List<string> filesToDelete)
        {
            string fullPath = Path.Combine(fm26Path!, relativePath);

            if (!Directory.Exists(fullPath))
            {
                LogMessage($"  ⚠ Klasör bulunamadı: {relativePath}", Color.Orange);
                return;
            }

            int deletedCount = 0;
            foreach (var fileName in filesToDelete)
            {
                string filePath = Path.Combine(fullPath, fileName);
                if (File.Exists(filePath))
                {
                    try
                    {
                        File.Delete(filePath);
                        LogMessage($"  ✓ Silindi: {fileName}", Color.Green);
                        deletedCount++;
                    }
                    catch (Exception ex)
                    {
                        LogMessage($"  ✗ Silinemedi: {fileName}", Color.Red);
                        LogMessage($"    Hata: {ex.Message}", Color.Red);
                    }
                }
                else
                {
                    LogMessage($"  ○ Zaten yok: {fileName}", Color.Gray);
                }
            }

            if (deletedCount > 0)
            {
                LogMessage($"  ► {deletedCount} dosya başarıyla silindi", Color.DarkGreen);
            }
        }

        private void CreateLncFiles()
        {
            string lncAllPath = Path.Combine(fm26Path!, @"lnc\all");

            if (!Directory.Exists(lncAllPath))
            {
                LogMessage("  ✗ lnc\\all klasörü bulunamadı", Color.Red);
                return;
            }

            string fixFile = Path.Combine(lncAllPath, "FM26 Fix by FMScout.lnc");
            string clubNamesFile = Path.Combine(lncAllPath, "FM26 Club Names by FMScout.lnc");

            var assembly = Assembly.GetExecutingAssembly();

            // FM26 Fix by FMScout.lnc
            if (File.Exists(fixFile))
            {
                LogMessage($"  ✓ Mevcut: FM26 Fix by FMScout.lnc", Color.Green);
            }
            else
            {
                var fixResourceName = "FM26Patcher.FM26 Fix by FMScout.lnc";
                using (Stream? resourceStream = assembly.GetManifestResourceStream(fixResourceName))
                {
                    if (resourceStream != null)
                    {
                        using (FileStream fileStream = File.Create(fixFile))
                        {
                            resourceStream.CopyTo(fileStream);
                        }
                        LogMessage($"  ✓ Oluşturuldu: FM26 Fix by FMScout.lnc", Color.Green);
                    }
                    else
                    {
                        File.WriteAllText(fixFile, "<!-- FM26 Fix by FMScout -->\n");
                        LogMessage($"  ✓ Oluşturuldu: FM26 Fix by FMScout.lnc (varsayılan)", Color.Green);
                    }
                }
            }

            // FM26 Club Names by FMScout.lnc
            if (File.Exists(clubNamesFile))
            {
                LogMessage($"  ✓ Mevcut: FM26 Club Names by FMScout.lnc", Color.Green);
            }
            else
            {
                var clubResourceName = "FM26Patcher.FM26 Club Names by FMScout.lnc";
                using (Stream? resourceStream = assembly.GetManifestResourceStream(clubResourceName))
                {
                    if (resourceStream != null)
                    {
                        using (FileStream fileStream = File.Create(clubNamesFile))
                        {
                            resourceStream.CopyTo(fileStream);
                        }
                        LogMessage($"  ✓ Oluşturuldu: FM26 Club Names by FMScout.lnc", Color.Green);
                    }
                    else
                    {
                        File.WriteAllText(clubNamesFile, "<!-- FM26 Club Names by FMScout -->\n");
                        LogMessage($"  ✓ Oluşturuldu: FM26 Club Names by FMScout.lnc (varsayılan)", Color.Green);
                    }
                }
            }
        }

        private void LogMessage(string message, Color color)
        {
            txtLog.SelectionStart = txtLog.TextLength;
            txtLog.SelectionLength = 0;
            txtLog.SelectionColor = color;
            txtLog.AppendText(message + Environment.NewLine);
            txtLog.SelectionColor = txtLog.ForeColor;
            txtLog.ScrollToCaret();
            Application.DoEvents();
        }

        private void UpdateProgress()
        {
            completedOperations++;
            progressBar.Value = (int)((completedOperations / (float)totalOperations) * 100);
            Application.DoEvents();
        }

        private void ResetButtons()
        {
            btnStart.Enabled = true;
            chkLisansYamasi.Enabled = true;
            chkArayuzHizlandirma.Enabled = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
