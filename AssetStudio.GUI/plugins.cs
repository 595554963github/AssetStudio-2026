using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssetStudio.GUI
{
    public partial class Plugins
    {
        public class PluginInfo
        {
            public string Name { get; set; }
            public string DisplayName { get; set; }
            public string DownloadUrl { get; set; }
            public string FileName { get; set; }
            public bool IsDownloaded { get; set; }
            public bool IsExternalTool { get; set; }
            public bool IsBuiltInDll { get; set; }
        }

        public static List<PluginInfo> plugins = new List<PluginInfo>
        {
            new PluginInfo
            {
                Name = "UniversalFileExtractor",
                DisplayName = "万能二进制提取器",
                DownloadUrl = "https://github.com/595554963github/AssetStudio-Neptune/releases/download/plugins/FileExtractor.dll",
                FileName = "FileExtractor.dll",
                IsDownloaded = false,
                IsExternalTool = false,
                IsBuiltInDll = true
            },
            new PluginInfo
            {
                Name = "UniversalByteRemover",
                DisplayName = "万能字节移除器",
                DownloadUrl = "https://github.com/595554963github/AssetStudio-Neptune/releases/download/plugins/ByteRemover.dll",
                FileName = "ByteRemover.dll",
                IsDownloaded = false,
                IsExternalTool = false,
                IsBuiltInDll = true
            },
            new PluginInfo
            {
                Name = "quickbmsbatch",
                DisplayName = "quickbms批量提取器",
                DownloadUrl = "https://github.com/595554963github/AssetStudio-Neptune/releases/download/plugins/quickbmsbatch.dll",
                FileName = "quickbmsbatch.dll",
                IsDownloaded = false,
                IsExternalTool = false,
                IsBuiltInDll = true
            },
            new PluginInfo
            {
                Name = "SuperToolbox",
                DisplayName = "超级工具箱",
                DownloadUrl = "https://github.com/595554963github/AssetStudio-Neptune/releases/download/plugins/Super-toolbox.dll",
                FileName = "Super-toolbox.dll",
                IsDownloaded = false,
                IsExternalTool = false,
                IsBuiltInDll = true
            },
            new PluginInfo
            {
                Name = "Sofdec2Viewer",
                DisplayName = "USM视频查看器汉化版",
                DownloadUrl = "https://github.com/595554963github/AssetStudio-Neptune/releases/download/plugins/Sofdec2_Viewer.exe",
                FileName = "Sofdec2_Viewer.exe",
                IsDownloaded = false,
                IsExternalTool = true,
                IsBuiltInDll = false
            },
            new PluginInfo
            {
                Name = "RadVideo",
                DisplayName = "bink视频播放器",
                DownloadUrl = "https://github.com/595554963github/AssetStudio-Neptune/releases/download/plugins/radvideo64.exe",
                FileName = "radvideo64.exe",
                IsDownloaded = false,
                IsExternalTool = true,
                IsBuiltInDll = false
            },
            new PluginInfo
            {
                Name = "QuickBMS",
                DisplayName = "quickbms汉化版",
                DownloadUrl = "https://github.com/595554963github/AssetStudio-Neptune/releases/download/plugins/quickbms.exe",
                FileName = "quickbms.exe",
                IsDownloaded = false,
                IsExternalTool = true,
                IsBuiltInDll = false
            },
            new PluginInfo
            {
                Name = "quickbms_4gb_files",
                DisplayName = "quickbms_4gb_files汉化版",
                DownloadUrl = "https://github.com/595554963github/AssetStudio-Neptune/releases/download/plugins/quickbms_4gb_files.exe",
                FileName = "quickbms_4gb_files.exe",
                IsDownloaded = false,
                IsExternalTool = true,
                IsBuiltInDll = false
            },
            new PluginInfo
            {
                Name = "RioX",
                DisplayName = "RioX汉化版",
                DownloadUrl = "https://github.com/595554963github/AssetStudio-Neptune/releases/download/plugins/RioX.exe",
                FileName = "RioX汉化版.exe",
                IsDownloaded = false,
                IsExternalTool = true,
                IsBuiltInDll = false
            },
            new PluginInfo
            {
                Name = "PakExplorer",
                DisplayName = "LUCA system pak解包器汉化版",
                DownloadUrl = "https://github.com/595554963github/AssetStudio-Neptune/releases/download/plugins/pak_explorer.exe",
                FileName = "pak_explorer.exe",
                IsDownloaded = false,
                IsExternalTool = true,
                IsBuiltInDll = false
            },
            new PluginInfo
            {
                Name = "PSound",
                DisplayName = "PlayStation音频提取器",
                DownloadUrl = "https://github.com/595554963github/AssetStudio-Neptune/releases/download/plugins/PSound.exe",
                FileName = "PSound.exe",
                IsDownloaded = false,
                IsExternalTool = true,
                IsBuiltInDll = false
            },
            new PluginInfo
            {
                Name = "WinAsar",
                DisplayName = "WinAsar汉化版",
                DownloadUrl = "https://github.com/595554963github/AssetStudio-Neptune/releases/download/plugins/WinAsar.exe",
                FileName = "WinAsar汉化版.exe",
                IsDownloaded = false,
                IsExternalTool = true,
                IsBuiltInDll = false
            },
            new PluginInfo
            {
                Name = "WinAsar",
                DisplayName = "AudioCUE编辑器",
                DownloadUrl = "https://github.com/595554963github/AssetStudio-Neptune/releases/download/plugins/ACE.exe",
                FileName = "ACE.exe",
                IsDownloaded = false,
                IsExternalTool = true,
                IsBuiltInDll = false
            },
            new PluginInfo
            {
                Name = "WinPCK",
                DisplayName = "完美世界pck解包工具",
                DownloadUrl = "https://github.com/595554963github/AssetStudio-Neptune/releases/download/plugins/WinPCK.exe",
                FileName = "WinPCK.exe",
                IsDownloaded = false,
                IsExternalTool = true,
                IsBuiltInDll = false
            }
        };

        public static string pluginsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "plugins");

        public static void InitializePlugins()
        {
            if (!Directory.Exists(pluginsDirectory))
            {
                Directory.CreateDirectory(pluginsDirectory);
            }

            foreach (var plugin in plugins)
            {
                string filePath = Path.Combine(pluginsDirectory, plugin.FileName);
                plugin.IsDownloaded = File.Exists(filePath);
            }
        }

        public static ToolStripMenuItem CreatePluginMenuItem(PluginInfo plugin)
        {
            var menuItem = new ToolStripMenuItem();
            menuItem.Name = $"toolStripMenuItem_{plugin.Name}";
            menuItem.Size = new System.Drawing.Size(180, 22);

            if (plugin.IsDownloaded)
            {
                menuItem.Text = $"{plugin.DisplayName} ✓";
                menuItem.Click += (sender, e) => LaunchPlugin(plugin);
            }
            else
            {
                menuItem.Text = plugin.DisplayName;
                menuItem.Click += (sender, e) => DownloadPlugin(plugin, menuItem);
            }

            var contextMenu = new ContextMenuStrip();

            var downloadItem = new ToolStripMenuItem("下载");
            downloadItem.Click += (sender, e) => DownloadPlugin(plugin, menuItem);

            var launchItem = new ToolStripMenuItem("启动");
            launchItem.Click += (sender, e) => LaunchPlugin(plugin);

            var uninstallItem = new ToolStripMenuItem("卸载");
            uninstallItem.Click += (sender, e) => UninstallPlugin(plugin, menuItem);

            contextMenu.Items.Add(downloadItem);
            contextMenu.Items.Add(launchItem);
            contextMenu.Items.Add(uninstallItem);

            contextMenu.Opening += (sender, e) =>
            {
                string filePath = Path.Combine(pluginsDirectory, plugin.FileName);
                bool fileExists = File.Exists(filePath);

                if (fileExists != plugin.IsDownloaded)
                {
                    plugin.IsDownloaded = fileExists;

                    if (plugin.IsDownloaded)
                    {
                        menuItem.Text = $"{plugin.DisplayName} ✓";
                        menuItem.Click -= (sender, e) => DownloadPlugin(plugin, menuItem);
                        menuItem.Click += (sender, e) => LaunchPlugin(plugin);
                    }
                    else
                    {
                        menuItem.Text = plugin.DisplayName;
                        menuItem.Click -= (sender, e) => LaunchPlugin(plugin);
                        menuItem.Click += (sender, e) => DownloadPlugin(plugin, menuItem);
                    }
                }

                downloadItem.Enabled = !plugin.IsDownloaded;
                launchItem.Enabled = plugin.IsDownloaded;
                uninstallItem.Enabled = plugin.IsDownloaded;
            };

            menuItem.MouseUp += (sender, e) =>
            {
                if (e.Button == MouseButtons.Right)
                {
                    contextMenu.Show(Cursor.Position);
                }
            };

            return menuItem;
        }
        public class DownloadSpeedCalculator
        {
            private DateTime startTime;
            private long totalBytes;
            private DateTime lastUpdateTime;
            private long lastBytes;
            private double smoothedSpeed = 0;

            public void Start()
            {
                startTime = DateTime.Now;
                lastUpdateTime = startTime;
                totalBytes = 0;
                lastBytes = 0;
                smoothedSpeed = 0;
            }

            public void AddBytes(long bytes)
            {
                totalBytes += bytes;
            }

            public void Stop()
            {
            }

            public double ElapsedTime => (DateTime.Now - startTime).TotalSeconds;

            public (double Speed, string Unit, string ETA) GetSpeedInfo(long downloadedBytes, long totalBytes)
            {
                var currentTime = DateTime.Now;
                var timeDiff = (currentTime - lastUpdateTime).TotalSeconds;

                if (timeDiff < 0.1)
                {
                    return (smoothedSpeed, smoothedSpeed > 1024 ? "MB/s" : "KB/s", "");
                }

                double currentSpeed = (downloadedBytes - lastBytes) / timeDiff / 1024;

                if (smoothedSpeed == 0)
                {
                    smoothedSpeed = currentSpeed;
                }
                else
                {
                    smoothedSpeed = 0.7 * smoothedSpeed + 0.3 * currentSpeed;
                }

                lastUpdateTime = currentTime;
                lastBytes = downloadedBytes;

                double speed;
                string unit;

                if (smoothedSpeed > 1024)
                {
                    speed = smoothedSpeed / 1024;
                    unit = "MB/s";
                }
                else
                {
                    speed = smoothedSpeed;
                    unit = "KB/s";
                }

                string eta = "";
                if (totalBytes > 0)
                {
                    long remainingBytes = totalBytes - downloadedBytes;
                    if (remainingBytes > 0 && smoothedSpeed > 0)
                    {
                        double etaSeconds = remainingBytes / (smoothedSpeed * 1024);
                        if (etaSeconds < 60)
                        {
                            eta = $"{etaSeconds:F0}秒";
                        }
                        else if (etaSeconds < 3600)
                        {
                            eta = $"{etaSeconds / 60:F0}分";
                        }
                        else
                        {
                            eta = $"{etaSeconds / 3600:F1}小时";
                        }
                    }
                    else
                    {
                        eta = "完成";
                    }
                }

                return (speed, unit, eta);
            }
        }
        private static void DownloadPlugin(PluginInfo plugin, ToolStripMenuItem menuItem)
        {
            if (plugin.IsDownloaded)
            {
                LaunchPlugin(plugin);
                return;
            }

            var downloadDialog = new DownloadProgressForm(plugin);
            downloadDialog.FormClosed += (s, e) =>
            {
                if (downloadDialog.DialogResult == DialogResult.OK)
                {
                    string filePath = Path.Combine(pluginsDirectory, plugin.FileName);
                    if (File.Exists(filePath))
                    {
                        plugin.IsDownloaded = true;
                        menuItem.Text = $"{plugin.DisplayName} ✓";

                        menuItem.Click -= (sender, e) => DownloadPlugin(plugin, menuItem);
                        menuItem.Click += (sender, e) => LaunchPlugin(plugin);

                        MessageBox.Show($"{plugin.DisplayName}下载完成！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"{plugin.DisplayName}下载文件验证失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                downloadDialog.Dispose();
            };

            downloadDialog.Show();
        }

        public static void LaunchPlugin(PluginInfo plugin)
        {
            if (!plugin.IsDownloaded)
            {
                MessageBox.Show($"请先下载{plugin.DisplayName}", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string filePath = Path.Combine(pluginsDirectory, plugin.FileName);

                if (!File.Exists(filePath))
                {
                    plugin.IsDownloaded = false;
                    MessageBox.Show($"{plugin.DisplayName} 文件不存在，请重新下载", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (plugin.IsExternalTool)
                {
                    Process.Start(filePath);
                }
                else if (plugin.IsBuiltInDll)
                {
                    LaunchBuiltInDll(plugin, filePath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"启动{plugin.DisplayName}失败:{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void LaunchBuiltInDll(PluginInfo plugin, string filePath)
        {
            try
            {
                Assembly assembly = Assembly.LoadFrom(filePath);

                var formTypes = assembly.GetTypes()
                    .Where(t => typeof(Form).IsAssignableFrom(t) && !t.IsAbstract)
                    .ToList();

                if (formTypes.Count == 0)
                {
                    throw new Exception($"在{plugin.FileName}中找不到窗体类");
                }

                Type mainFormType = formTypes.FirstOrDefault(t =>
                    t.Name.Contains("Main", StringComparison.OrdinalIgnoreCase)) ?? formTypes[0];

                Form existingInstance = Application.OpenForms.Cast<Form>()
                    .FirstOrDefault(form => form.GetType() == mainFormType);

                if (existingInstance != null)
                {
                    if (existingInstance.WindowState == FormWindowState.Minimized)
                    {
                        existingInstance.WindowState = FormWindowState.Normal;
                    }
                    existingInstance.BringToFront();
                    existingInstance.Focus();
                    return;
                }

                Form mainForm = Activator.CreateInstance(mainFormType) as Form;
                if (mainForm != null)
                {
                    mainForm.StartPosition = FormStartPosition.CenterScreen;
                    mainForm.Show();
                }
                else
                {
                    throw new Exception($"无法创建窗体实例: {mainFormType.FullName}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载内置DLL插件失败:{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void UninstallPlugin(PluginInfo plugin, ToolStripMenuItem menuItem)
        {
            if (!plugin.IsDownloaded)
            {
                return;
            }

            var result = MessageBox.Show($"确定要卸载{plugin.DisplayName}吗？", "确认卸载",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    string filePath = Path.Combine(pluginsDirectory, plugin.FileName);
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }

                    plugin.IsDownloaded = false;
                    menuItem.Text = plugin.DisplayName;

                    menuItem.Click -= (sender, e) => LaunchPlugin(plugin);
                    menuItem.Click += (sender, e) => DownloadPlugin(plugin, menuItem);

                    MessageBox.Show($"{plugin.DisplayName}卸载完成！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"卸载{plugin.DisplayName}失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public static void AddMenuItemsToPluginMenu(ToolStripMenuItem pluginMenu)
        {
            InitializePlugins();

            pluginMenu.DropDownItems.Clear();

            foreach (var plugin in plugins)
            {
                var menuItem = CreatePluginMenuItem(plugin);
                pluginMenu.DropDownItems.Add(menuItem);
            }

            pluginMenu.DropDownItems.Add(new ToolStripSeparator());

            var managePluginsItem = new ToolStripMenuItem("插件管理器");
            managePluginsItem.Click += (sender, e) => ShowPluginManager();
            pluginMenu.DropDownItems.Add(managePluginsItem);
        }

        private static void ShowPluginManager()
        {
            var managerForm = new PluginManagerForm(plugins);
            managerForm.ShowDialog();
        }

        public static void AddMenuItemsToMainForm(MainForm mainForm)
        {
            var pluginToolStripMenuItem = mainForm.MenuStrip1.Items["toolStripMenuItem20"] as ToolStripMenuItem;
            if (pluginToolStripMenuItem != null)
            {
                AddMenuItemsToPluginMenu(pluginToolStripMenuItem);
            }
        }

        public class DownloadProgressForm : Form
        {
            private CancellationTokenSource cancellationTokenSource;
            private ProgressBar progressBar;
            private Label statusLabel;
            private Plugins.PluginInfo plugin;
            public bool IsDownloading { get; private set; }
            private bool isDownloadCompleted = false;
            private string filePath;
            private long totalBytes = 0;
            private long totalDownloadedBytes = 0;
            private readonly object lockObject = new object();
            private Label speedLabel;
            private Label etaLabel;
            private DownloadSpeedCalculator downloadSpeedCalculator;
            private long currentTotalBytes = 0;
            public DownloadProgressForm(Plugins.PluginInfo plugin)
            {
                this.plugin = plugin;
                this.cancellationTokenSource = new CancellationTokenSource();
                InitializeComponent();
                this.Load += async (s, e) => await StartDownloadAsync();
            }

            private void InitializeComponent()
            {
                this.Size = new Size(450, 200);
                this.Text = $"下载{plugin.DisplayName}";
                this.StartPosition = FormStartPosition.CenterScreen;
                this.FormBorderStyle = FormBorderStyle.FixedDialog;
                this.MaximizeBox = false;
                this.MinimizeBox = false;
                this.ShowInTaskbar = false;

                statusLabel = new Label
                {
                    Text = "准备下载...",
                    Location = new Point(20, 20),
                    Size = new Size(360, 20)
                };

                progressBar = new ProgressBar
                {
                    Location = new Point(20, 50),
                    Size = new Size(410, 23),
                    Style = ProgressBarStyle.Continuous
                };
                speedLabel = new Label
                {
                    Text = "速度: --",
                    Location = new Point(20, 80),
                    Size = new Size(200, 15)
                };

                etaLabel = new Label
                {
                    Text = "剩余时间: --",
                    Location = new Point(20, 100),
                    Size = new Size(200, 15)
                };

                var cancelButton = new Button
                {
                    Text = "取消",
                    Location = new Point(335, 130),
                    Size = new Size(95, 25)
                };
                cancelButton.Click += (s, e) =>
                {
                    cancellationTokenSource.Cancel();
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                };

                this.Controls.Add(statusLabel);
                this.Controls.Add(progressBar);
                this.Controls.Add(speedLabel);
                this.Controls.Add(etaLabel);
                this.Controls.Add(cancelButton);

                downloadSpeedCalculator = new DownloadSpeedCalculator();
            }

            private HttpClient CreateOptimizedHttpClient()
            {
                var handler = new HttpClientHandler()
                {
                    ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true,
                    AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
                    UseProxy = false,
                    UseCookies = false,
                    MaxConnectionsPerServer = 20
                };

                var client = new HttpClient(handler)
                {
                    Timeout = TimeSpan.FromMinutes(30)
                };

                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36");
                client.DefaultRequestHeaders.Add("Accept", "*/*");
                client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br");
                client.DefaultRequestHeaders.Add("Connection", "keep-alive");
                client.DefaultRequestHeaders.Add("Cache-Control", "no-cache");

                return client;
            }

            private async Task StartDownloadAsync()
            {
                IsDownloading = true;
                downloadSpeedCalculator.Start();
                try
                {
                    if (!Directory.Exists(Plugins.pluginsDirectory))
                    {
                        Directory.CreateDirectory(Plugins.pluginsDirectory);
                    }

                    filePath = Path.Combine(Plugins.pluginsDirectory, plugin.FileName);

                    totalBytes = await GetFileSize(plugin.DownloadUrl);

                    if (totalBytes > 5 * 1024 * 1024)
                    {
                        await DownloadFileWithMultiThreadAsync(plugin.DownloadUrl, filePath, totalBytes);
                    }
                    else
                    {
                        await DownloadFileWithProgressAsync(plugin.DownloadUrl, filePath);
                    }

                    statusLabel.Text = "下载完成！";
                    isDownloadCompleted = true;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (OperationCanceledException)
                {
                    DeleteIncompleteFile();
                    statusLabel.Text = "下载已取消";
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
                catch (Exception ex)
                {
                    DeleteIncompleteFile();
                    statusLabel.Text = $"下载错误:{ex.Message}";
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
                finally
                {
                    downloadSpeedCalculator.Stop();
                    IsDownloading = false;
                }
            }

            private async Task<long> GetFileSize(string url)
            {
                try
                {
                    using (var client = CreateOptimizedHttpClient())
                    using (var response = await client.SendAsync(new HttpRequestMessage(HttpMethod.Head, url)))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            return response.Content.Headers.ContentLength ?? 0;
                        }
                    }
                }
                catch
                {
                }
                return 0;
            }

            private async Task DownloadFileWithMultiThreadAsync(string fileUrl, string savePath, long fileSize)
            {
                const int threadCount = 4;
                var chunkSize = fileSize / threadCount;
                var tasks = new List<Task>();

                using (var fileStream = new FileStream(savePath, FileMode.Create, FileAccess.Write, FileShare.Write))
                {
                    fileStream.SetLength(fileSize);
                }

                totalDownloadedBytes = 0;
                currentTotalBytes = fileSize;
                for (int i = 0; i < threadCount; i++)
                {
                    var startByte = i * chunkSize;
                    var endByte = (i == threadCount - 1) ? fileSize - 1 : (i + 1) * chunkSize - 1;
                    tasks.Add(DownloadChunkAsync(fileUrl, savePath, startByte, endByte, i));
                }

                await Task.WhenAll(tasks);
            }

            private async Task DownloadChunkAsync(string fileUrl, string savePath, long startByte, long endByte, int chunkIndex)
            {
                using (var chunkClient = CreateOptimizedHttpClient())
                {
                    var request = new HttpRequestMessage(HttpMethod.Get, fileUrl);
                    request.Headers.Range = new System.Net.Http.Headers.RangeHeaderValue(startByte, endByte);

                    using (var response = await chunkClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead))
                    {
                        response.EnsureSuccessStatusCode();

                        using (var stream = await response.Content.ReadAsStreamAsync())
                        using (var fileStream = new FileStream(savePath, FileMode.Open, FileAccess.Write, FileShare.Write))
                        {
                            fileStream.Seek(startByte, SeekOrigin.Begin);

                            var buffer = new byte[32768];
                            int bytesRead;

                            while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                            {
                                await fileStream.WriteAsync(buffer, 0, bytesRead);

                                lock (lockObject)
                                {
                                    totalDownloadedBytes += bytesRead;
                                    UpdateProgressSafe();
                                }
                            }
                        }
                    }
                }
            }

            private async Task DownloadFileWithProgressAsync(string fileUrl, string savePath)
            {
                using (var client = CreateOptimizedHttpClient())
                using (var response = await client.GetAsync(fileUrl, HttpCompletionOption.ResponseHeadersRead))
                {
                    response.EnsureSuccessStatusCode();

                    if (totalBytes == 0)
                    {
                        totalBytes = response.Content.Headers.ContentLength ?? 0;
                    }
                    currentTotalBytes = totalBytes;
                    using (var contentStream = await response.Content.ReadAsStreamAsync())
                    using (var fileStream = new FileStream(savePath, FileMode.Create, FileAccess.Write, FileShare.None, 8192, true))
                    {
                        var buffer = new byte[8192];
                        var currentBytesRead = 0L;
                        int bytesRead;

                        while ((bytesRead = await contentStream.ReadAsync(buffer, 0, buffer.Length, cancellationTokenSource.Token)) > 0)
                        {
                            await fileStream.WriteAsync(buffer, 0, bytesRead, cancellationTokenSource.Token);
                            currentBytesRead += bytesRead;

                            if (totalBytes > 0)
                            {
                                var percentage = (int)((double)currentBytesRead / totalBytes * 100);
                                UpdateProgressUI(percentage, currentBytesRead);
                            }

                            cancellationTokenSource.Token.ThrowIfCancellationRequested();
                        }
                    }
                }
            }

            private void UpdateProgressSafe()
            {
                if (totalBytes <= 0) return;

                var progress = (int)((double)totalDownloadedBytes / totalBytes * 100);
                var speedInfo = downloadSpeedCalculator.GetSpeedInfo(totalDownloadedBytes, totalBytes);

                if (progressBar.InvokeRequired)
                {
                    progressBar.Invoke(new Action(() => {
                        progressBar.Value = Math.Min(progress, 100);
                        statusLabel.Text = $"下载中: {progress}% ({FormatFileSize(totalDownloadedBytes)} / {FormatFileSize(totalBytes)})";
                        speedLabel.Text = $"速度: {speedInfo.Speed:F1} {speedInfo.Unit}";
                        etaLabel.Text = $"剩余时间: {speedInfo.ETA}";
                    }));
                }
                else
                {
                    progressBar.Value = Math.Min(progress, 100);
                    statusLabel.Text = $"下载中: {progress}% ({FormatFileSize(totalDownloadedBytes)} / {FormatFileSize(totalBytes)})";
                    speedLabel.Text = $"速度: {speedInfo.Speed:F1} {speedInfo.Unit}";
                    etaLabel.Text = $"剩余时间: {speedInfo.ETA}";
                }
            }
            private string FormatFileSize(long bytes)
            {
                if (bytes >= 1024 * 1024 * 1024) // GB
                {
                    return $"{bytes / (1024.0 * 1024 * 1024):0.00} GB";
                }
                else if (bytes >= 1024 * 1024) // MB
                {
                    return $"{bytes / (1024.0 * 1024):0.00} MB";
                }
                else if (bytes >= 1024) // KB
                {
                    return $"{bytes / 1024.0:0.00} KB";
                }
                else // B
                {
                    return $"{bytes} B";
                }
            }
            private void UpdateProgressUI(int percentage, long bytesRead)
            {
                var speedInfo = downloadSpeedCalculator.GetSpeedInfo(bytesRead, totalBytes);

                if (progressBar.InvokeRequired)
                {
                    progressBar.Invoke(new Action(() => {
                        progressBar.Value = percentage;
                        statusLabel.Text = $"下载中: {percentage}% ({FormatFileSize(bytesRead)} / {FormatFileSize(totalBytes)})";
                        speedLabel.Text = $"速度: {speedInfo.Speed:F1} {speedInfo.Unit}";
                        etaLabel.Text = $"剩余时间: {speedInfo.ETA}";
                    }));
                }
                else
                {
                    progressBar.Value = percentage;
                    statusLabel.Text = $"下载中: {percentage}% ({FormatFileSize(bytesRead)} / {FormatFileSize(totalBytes)})";
                    speedLabel.Text = $"速度: {speedInfo.Speed:F1} {speedInfo.Unit}";
                    etaLabel.Text = $"剩余时间: {speedInfo.ETA}";
                }
            }

            private void DeleteIncompleteFile()
            {
                try
                {
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }
                }
                catch
                {
                }
            }

            protected override void OnFormClosing(FormClosingEventArgs e)
            {
                if (IsDownloading && !isDownloadCompleted)
                {
                    var result = MessageBox.Show("下载正在进行中，确定要取消吗？",
                        "确认关闭", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.No)
                    {
                        e.Cancel = true;
                        return;
                    }
                    else
                    {
                        DeleteIncompleteFile();
                    }
                }

                cancellationTokenSource?.Cancel();
                base.OnFormClosing(e);
            }
        }

        public class PluginManagerForm : Form
        {
            private List<Plugins.PluginInfo> plugins;
            private ListView listView;
            private Panel buttonPanel;

            public PluginManagerForm(List<Plugins.PluginInfo> plugins)
            {
                this.plugins = plugins;
                InitializeComponent();
                LoadPlugins();
            }

            private void InitializeComponent()
            {
                this.StartPosition = FormStartPosition.CenterScreen;
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.MinimumSize = new Size(500, 300);
                this.Text = "插件管理器";
                this.Size = new Size(500, 400);

                var tableLayout = new TableLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    RowCount = 2,
                    ColumnCount = 1
                };
                tableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
                tableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));

                listView = new ListView
                {
                    View = View.Details,
                    FullRowSelect = true,
                    GridLines = true,
                    Dock = DockStyle.Fill,
                    MultiSelect = false
                };

                listView.Columns.Add("插件名称", 100);
                listView.Columns.Add("状态", 100);
                listView.Columns.Add("文件", 100);
                listView.Columns.Add("类型", 100);

                buttonPanel = new Panel
                {
                    Dock = DockStyle.Fill,
                    Height = 50
                };

                var downloadButton = new Button { Text = "下载", Location = new Point(10, 10), Size = new Size(75, 23) };
                var launchButton = new Button { Text = "启动", Location = new Point(95, 10), Size = new Size(75, 23) };
                var uninstallButton = new Button { Text = "卸载", Location = new Point(180, 10), Size = new Size(75, 23) };
                var refreshButton = new Button { Text = "刷新", Location = new Point(265, 10), Size = new Size(75, 23) };
                var closeButton = new Button { Text = "关闭", Location = new Point(350, 10), Size = new Size(75, 23) };

                downloadButton.Click += (s, e) => DownloadSelected();
                launchButton.Click += (s, e) => LaunchSelected();
                uninstallButton.Click += (s, e) => UninstallSelected();
                refreshButton.Click += (s, e) => LoadPlugins();
                closeButton.Click += (s, e) => this.Close();

                buttonPanel.Controls.Add(downloadButton);
                buttonPanel.Controls.Add(launchButton);
                buttonPanel.Controls.Add(uninstallButton);
                buttonPanel.Controls.Add(refreshButton);
                buttonPanel.Controls.Add(closeButton);

                tableLayout.Controls.Add(listView, 0, 0);
                tableLayout.Controls.Add(buttonPanel, 0, 1);

                this.Controls.Add(tableLayout);

                this.Resize += (s, e) => AutoResizeColumns();
            }

            private void AutoResizeColumns()
            {
                if (listView != null && listView.Columns.Count > 0 && listView.Width > 0)
                {
                    int totalWidth = listView.Width - 25;
                    int columnCount = listView.Columns.Count;

                    int columnWidth = totalWidth / columnCount;
                    foreach (ColumnHeader column in listView.Columns)
                    {
                        column.Width = columnWidth;
                    }
                }
            }

            private void LoadPlugins()
            {
                listView.Items.Clear();
                foreach (var plugin in plugins)
                {
                    var item = new ListViewItem(plugin.DisplayName);
                    item.SubItems.Add(plugin.IsDownloaded ? "已下载" : "未下载");
                    item.SubItems.Add(plugin.FileName);

                    string pluginType = "外部工具";
                    if (plugin.IsBuiltInDll)
                    {
                        pluginType = "内置DLL工具";
                    }
                    else if (!plugin.IsExternalTool)
                    {
                        pluginType = "内置工具";
                    }
                    item.SubItems.Add(pluginType);

                    item.Tag = plugin;

                    if (plugin.IsDownloaded)
                    {
                        item.BackColor = SystemColors.Info;
                        item.ForeColor = SystemColors.InfoText;
                    }
                    else
                    {
                        item.BackColor = SystemColors.ControlLight;
                        item.ForeColor = SystemColors.ControlText;
                    }

                    listView.Items.Add(item);
                }
            }

            private void DownloadSelected()
            {
                if (listView.SelectedItems.Count > 0)
                {
                    var plugin = listView.SelectedItems[0].Tag as Plugins.PluginInfo;
                    if (plugin != null)
                    {
                        var downloadDialog = new DownloadProgressForm(plugin);
                        downloadDialog.FormClosed += (s, e) =>
                        {
                            if (downloadDialog.DialogResult == DialogResult.OK)
                            {
                                plugin.IsDownloaded = true;
                                LoadPlugins();
                                MessageBox.Show($"{plugin.DisplayName}下载完成！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            downloadDialog.Dispose();
                        };
                        downloadDialog.Show();
                    }
                }
            }

            private void LaunchSelected()
            {
                if (listView.SelectedItems.Count > 0)
                {
                    var plugin = listView.SelectedItems[0].Tag as Plugins.PluginInfo;
                    if (plugin != null && plugin.IsDownloaded)
                    {
                        Plugins.LaunchPlugin(plugin);
                    }
                }
            }

            private void UninstallSelected()
            {
                if (listView.SelectedItems.Count > 0)
                {
                    var plugin = listView.SelectedItems[0].Tag as Plugins.PluginInfo;
                    if (plugin != null && plugin.IsDownloaded)
                    {
                        var result = MessageBox.Show($"确定要卸载{plugin.DisplayName}吗？", "确认卸载",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            string filePath = Path.Combine(Plugins.pluginsDirectory, plugin.FileName);
                            if (File.Exists(filePath))
                            {
                                File.Delete(filePath);
                                plugin.IsDownloaded = false;
                                LoadPlugins();
                                MessageBox.Show($"{plugin.DisplayName}卸载完成！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
        }
    }
}