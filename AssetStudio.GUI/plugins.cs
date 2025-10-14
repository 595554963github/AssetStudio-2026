using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
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
            public bool IsZipFile { get; set; }
            public string ExeFileName { get; set; }
            public string ExtractFolder { get; set; }
        }

        public static List<PluginInfo> plugins = new List<PluginInfo>
        {
            new PluginInfo
            {
                Name = "UniversalFileExtractor",
                DisplayName = "万能二进制提取器",
                DownloadUrl = "https://gitee.com/valkylia-goddess/AssetStudio-Neptune/releases/download/down/FileExtractor.dll",
                FileName = "FileExtractor.dll",
                IsDownloaded = false,
                IsExternalTool = false,
                IsBuiltInDll = true
            },
            new PluginInfo
            {
                Name = "UniversalByteRemover",
                DisplayName = "万能字节移除器",
                DownloadUrl = "https://gitee.com/valkylia-goddess/AssetStudio-Neptune/releases/download/down/ByteRemover.dll",
                FileName = "ByteRemover.dll",
                IsDownloaded = false,
                IsExternalTool = false,
                IsBuiltInDll = true
            },
            new PluginInfo
            {
                Name = "quickbmsbatch",
                DisplayName = "quickbms批量提取器",
                DownloadUrl = "https://gitee.com/valkylia-goddess/AssetStudio-Neptune/releases/download/down/quickbmsbatch.dll",
                FileName = "quickbmsbatch.dll",
                IsDownloaded = false,
                IsExternalTool = false,
                IsBuiltInDll = true
            },
            new PluginInfo
            {
                Name = "SuperToolbox",
                DisplayName = "超级工具箱",
                DownloadUrl = "https://gitee.com/valkylia-goddess/AssetStudio-Neptune/releases/download/down/Super-toolbox.dll",
                FileName = "Super-toolbox.dll",
                IsDownloaded = false,
                IsExternalTool = false,
                IsBuiltInDll = true
            },
            new PluginInfo
            {
                Name = "CriFsV2Lib.Definitions.dll",
                DisplayName = "超级工具箱dll依赖",
                DownloadUrl = "https://gitee.com/valkylia-goddess/AssetStudio-Neptune/releases/download/down/CriFsV2Lib.Definitions.dll",
                FileName = "CriFsV2Lib.Definitions.dll",
                IsDownloaded = false,
                IsExternalTool = false,
                IsBuiltInDll = false
            },
            new PluginInfo
            {
                Name = "Sofdec2Viewer",
                DisplayName = "USM视频查看器汉化版",
                DownloadUrl = "https://gitee.com/valkylia-goddess/AssetStudio-Neptune/releases/download/down/Sofdec2_Viewer.exe",
                FileName = "Sofdec2_Viewer.exe",
                IsDownloaded = false,
                IsExternalTool = true,
                IsBuiltInDll = false
            },
            new PluginInfo
            {
                Name = "RadVideo",
                DisplayName = "bink视频播放器",
                DownloadUrl = "https://gitee.com/valkylia-goddess/AssetStudio-Neptune/releases/download/down/radvideo64.exe",
                FileName = "radvideo64.exe",
                IsDownloaded = false,
                IsExternalTool = true,
                IsBuiltInDll = false
            },
            new PluginInfo
            {
                Name = "QuickBMS",
                DisplayName = "quickbms汉化版",
                DownloadUrl = "https://gitee.com/valkylia-goddess/AssetStudio-Neptune/releases/download/down/quickbms.exe",
                FileName = "quickbms.exe",
                IsDownloaded = false,
                IsExternalTool = true,
                IsBuiltInDll = false
            },
            new PluginInfo
            {
                Name = "quickbms_4gb_files",
                DisplayName = "quickbms_4gb_files汉化版",
                DownloadUrl = "https://gitee.com/valkylia-goddess/AssetStudio-Neptune/releases/download/down/quickbms_4gb_files.exe",
                FileName = "quickbms_4gb_files.exe",
                IsDownloaded = false,
                IsExternalTool = true,
                IsBuiltInDll = false
            },
            new PluginInfo
            {
                Name = "RioX",
                DisplayName = "RioX汉化版",
                DownloadUrl = "https://gitee.com/valkylia-goddess/AssetStudio-Neptune/releases/download/down/RioX.exe",
                FileName = "RioX汉化版.exe",
                IsDownloaded = false,
                IsExternalTool = true,
                IsBuiltInDll = false
            },
            new PluginInfo
            {
                Name = "PakExplorer",
                DisplayName = "LUCA system pak解包器汉化版",
                DownloadUrl = "https://gitee.com/valkylia-goddess/AssetStudio-Neptune/releases/download/down/pak_explorer.exe",
                FileName = "pak_explorer.exe",
                IsDownloaded = false,
                IsExternalTool = true,
                IsBuiltInDll = false
            },
            new PluginInfo
            {
                Name = "PSound",
                DisplayName = "PlayStation音频提取器",
                DownloadUrl = "https://gitee.com/valkylia-goddess/AssetStudio-Neptune/releases/download/down/PSound.exe",
                FileName = "PSound.exe",
                IsDownloaded = false,
                IsExternalTool = true,
                IsBuiltInDll = false
            },
            new PluginInfo
            {
                Name = "WinAsar",
                DisplayName = "WinAsar汉化版",
                DownloadUrl = "https://gitee.com/valkylia-goddess/AssetStudio-Neptune/releases/download/down/WinAsar.exe",
                FileName = "WinAsar汉化版.exe",
                IsDownloaded = false,
                IsExternalTool = true,
                IsBuiltInDll = false
            },
            new PluginInfo
            {
                Name = "WinAsar",
                DisplayName = "AudioCUE编辑器",
                DownloadUrl = "https://gitee.com/valkylia-goddess/AssetStudio-Neptune/releases/download/down/ACE.exe",
                FileName = "ACE.exe",
                IsDownloaded = false,
                IsExternalTool = true,
                IsBuiltInDll = false
            },
            new PluginInfo
            {
                Name = "WinPCK",
                DisplayName = "完美世界pck解包工具",
                DownloadUrl = "https://gitee.com/valkylia-goddess/AssetStudio-Neptune/releases/download/down/WinPCK.exe",
                FileName = "WinPCK.exe",
                IsDownloaded = false,
                IsExternalTool = true,
                IsBuiltInDll = false
            },
            new PluginInfo
            {
                Name = "RetsukoSoundTool",
                DisplayName = "3ds/wiiu音频提取器",
                DownloadUrl = "https://gitee.com/valkylia-goddess/AssetStudio-Neptune/releases/download/down/RetsukoSoundTool.exe",
                FileName = "RetsukoSoundTool.exe",
                IsDownloaded = false,
                IsExternalTool = true,
                IsBuiltInDll = false
            },
            new PluginInfo
            {
                Name = "Motrix",
                DisplayName = "免费不限速下载器",
                DownloadUrl = "https://gitee.com/valkylia-goddess/AssetStudio-Neptune/releases/download/down/Motrix_x64.exe",
                FileName = "Motrix_x64.exe",
                IsDownloaded = false,
                IsExternalTool = true,
                IsBuiltInDll = false
            },
            new PluginInfo
            {
                Name = "UmodelHelper",
                DisplayName = "Umodel辅助器",
                DownloadUrl = "https://gitee.com/valkylia-goddess/AssetStudio-Neptune/releases/download/down/UmodelHelper.exe",
                FileName = "UmodelHelper.exe",
                IsDownloaded = false,
                IsExternalTool = true,
                IsBuiltInDll = false
            },
            new PluginInfo
            {
                Name = "cmake-gui",
                DisplayName = "cmakegui汉化版",
                DownloadUrl = "https://gitee.com/valkylia-goddess/AssetStudio-Neptune/releases/download/down/cmake-gui.exe",
                FileName = "cmake-gui.exe",
                IsDownloaded = false,
                IsExternalTool = true,
                IsBuiltInDll = false
            },
            new PluginInfo
            {
                Name = "QuickWaveBank",
                DisplayName = "xwb打包解包工具",
                DownloadUrl = "https://gitee.com/valkylia-goddess/AssetStudio-Neptune/releases/download/down/QuickWaveBank.exe",
                FileName = "QuickWaveBank.exe",
                IsDownloaded = false,
                IsExternalTool = true,
                IsBuiltInDll = false
            },
            new PluginInfo
            {
                Name = "FSBank",
                DisplayName = "FSB打包工具",
                DownloadUrl = "https://gitee.com/valkylia-goddess/AssetStudio-Neptune/releases/download/down/fsbank.zip",
                FileName = "fsbank.zip",
                 IsDownloaded = false,
                 IsExternalTool = true,
                 IsBuiltInDll = false,
                 IsZipFile = true,
                 ExeFileName = "fsbank.exe",
                 ExtractFolder = "fsbank"
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
                string filePath;
                if (plugin.IsZipFile && !string.IsNullOrEmpty(plugin.ExtractFolder))
                {
                    filePath = Path.Combine(pluginsDirectory, plugin.ExtractFolder, plugin.ExeFileName);
                }
                else
                {
                    filePath = Path.Combine(pluginsDirectory, plugin.FileName);
                }
                plugin.IsDownloaded = File.Exists(filePath);
            }
        }

        public static ToolStripMenuItem CreatePluginMenuItem(PluginInfo plugin)
        {
            var menuItem = new ToolStripMenuItem();
            menuItem.Name = $"toolStripMenuItem_{plugin.Name}";
            menuItem.Size = new System.Drawing.Size(180, 22);

            UpdateMainMenuItemText(plugin, menuItem);

            var downloadItem = new ToolStripMenuItem("下载");
            downloadItem.Click += (sender, e) => DownloadPlugin(plugin, menuItem);

            var launchItem = new ToolStripMenuItem("启动");
            launchItem.Click += (sender, e) => LaunchPlugin(plugin);

            var uninstallItem = new ToolStripMenuItem("卸载");
            uninstallItem.Click += (sender, e) => UninstallPlugin(plugin, menuItem);

            menuItem.DropDownItems.Add(downloadItem);
            menuItem.DropDownItems.Add(launchItem);
            menuItem.DropDownItems.Add(uninstallItem);

            UpdateSubMenuItemsState(plugin, downloadItem, launchItem, uninstallItem);

            menuItem.MouseEnter += (sender, e) =>
            {
                string filePath = Path.Combine(pluginsDirectory, plugin.FileName);
                bool fileExists = File.Exists(filePath);

                if (fileExists != plugin.IsDownloaded)
                {
                    plugin.IsDownloaded = fileExists;
                    UpdateMainMenuItemText(plugin, menuItem);
                    UpdateSubMenuItemsState(plugin, downloadItem, launchItem, uninstallItem);
                }

                CloseOtherPluginDropDowns(menuItem);

                menuItem.ShowDropDown();
            };

            menuItem.MouseLeave += (sender, e) =>
            {
                var clientRect = menuItem.Bounds;
                var screenRect = menuItem.GetCurrentParent().RectangleToScreen(clientRect);
                var mousePos = Control.MousePosition;

                bool isMouseInDropDown = menuItem.DropDown.Visible &&
                                        menuItem.DropDown.Bounds.Contains(Control.MousePosition);

                if (!screenRect.Contains(mousePos) && !isMouseInDropDown)
                {
                    menuItem.HideDropDown();
                }
            };

            menuItem.DropDown.MouseLeave += (sender, e) =>
            {
                var mousePos = Control.MousePosition;
                var menuItemScreenRect = menuItem.GetCurrentParent().RectangleToScreen(menuItem.Bounds);

                if (!menuItemScreenRect.Contains(mousePos) &&
                    !menuItem.DropDown.Bounds.Contains(menuItem.DropDown.PointToClient(mousePos)))
                {
                    menuItem.HideDropDown();
                }
            };

            menuItem.Click += (sender, e) =>
            {
                if (plugin.Name == "CriFsV2Lib.Definitions.dll")
                {
                    return;
                }

                if (plugin.IsDownloaded)
                {
                    LaunchPlugin(plugin);
                }
                else
                {
                    DownloadPlugin(plugin, menuItem);
                }
            };

            return menuItem;
        }

        private static void CloseOtherPluginDropDowns(ToolStripMenuItem currentMenuItem)
        {
            var parentMenu = currentMenuItem.Owner as MenuStrip;
            if (parentMenu != null)
            {
                foreach (ToolStripItem item in parentMenu.Items)
                {
                    var pluginMenu = item as ToolStripMenuItem;
                    if (pluginMenu != null && pluginMenu.Text == "插件")
                    {
                        foreach (ToolStripItem pluginItem in pluginMenu.DropDownItems)
                        {
                            var pluginMenuItem = pluginItem as ToolStripMenuItem;
                            if (pluginMenuItem != null && pluginMenuItem != currentMenuItem && pluginMenuItem.DropDown.Visible)
                            {
                                pluginMenuItem.HideDropDown();
                            }
                        }
                        break;
                    }
                }
            }
        }

        private static void UpdateMainMenuItemText(PluginInfo plugin, ToolStripMenuItem menuItem)
        {
            if (plugin.IsDownloaded)
            {
                menuItem.Text = $"{plugin.DisplayName} ✓";
            }
            else
            {
                menuItem.Text = plugin.DisplayName;
            }
        }

        private static void UpdateSubMenuItemsState(PluginInfo plugin, ToolStripMenuItem downloadItem,
            ToolStripMenuItem launchItem, ToolStripMenuItem uninstallItem)
        {
            downloadItem.Enabled = !plugin.IsDownloaded;
            launchItem.Enabled = plugin.IsDownloaded;
            uninstallItem.Enabled = plugin.IsDownloaded;
            if (plugin.Name == "CriFsV2Lib.Definitions.dll")
            {
                launchItem.Enabled = false;
            }
            else
            {
                launchItem.Enabled = plugin.IsDownloaded;
            }

            uninstallItem.Enabled = plugin.IsDownloaded;
            if (plugin.IsDownloaded)
            {
                downloadItem.Text = "下载 ✓";
            }
            else
            {
                downloadItem.Text = "下载";
            }
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
                        if (plugin.IsZipFile)
                        {
                            try
                            {
                                string extractPath = Path.Combine(pluginsDirectory, plugin.ExtractFolder);
                                if (!Directory.Exists(extractPath))
                                {
                                    Directory.CreateDirectory(extractPath);
                                }
                                System.IO.Compression.ZipFile.ExtractToDirectory(filePath, extractPath, true);

                                File.Delete(filePath);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"解压失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        plugin.IsDownloaded = true;
                        UpdateMainMenuItemText(plugin, menuItem);
                        if (menuItem.DropDownItems.Count >= 3)
                        {
                            UpdateSubMenuItemsState(plugin,
                                menuItem.DropDownItems[0] as ToolStripMenuItem,
                                menuItem.DropDownItems[1] as ToolStripMenuItem,
                                menuItem.DropDownItems[2] as ToolStripMenuItem);
                        }
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
            if (plugin.Name == "CriFsV2Lib.Definitions.dll")
            {
                MessageBox.Show($"{plugin.DisplayName}是依赖文件，无法直接启动。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!plugin.IsDownloaded)
            {
                MessageBox.Show($"请先下载{plugin.DisplayName}", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string filePath;
                if (plugin.IsZipFile)
                {
                    filePath = Path.Combine(pluginsDirectory, plugin.ExtractFolder, plugin.ExeFileName);
                }
                else
                {
                    filePath = Path.Combine(pluginsDirectory, plugin.FileName);
                }

                if (!File.Exists(filePath))
                {
                    plugin.IsDownloaded = false;
                    MessageBox.Show($"{plugin.DisplayName} 文件不存在，请重新下载", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (plugin.IsExternalTool || plugin.IsZipFile)
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
                AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;

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
            catch (ReflectionTypeLoadException ex)
            {
                var loaderExceptions = ex.LoaderExceptions;
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"加载插件时遇到依赖问题，尝试继续运行:");

                foreach (var loaderException in loaderExceptions)
                {
                    if (loaderException is FileNotFoundException fileNotFound)
                    {
                        sb.AppendLine($"缺失依赖: {fileNotFound.FileName}");
                        continue;
                    }
                }

                var loadableTypes = ex.Types.Where(t => t != null);
                var formTypes = loadableTypes.Where(t => typeof(Form).IsAssignableFrom(t) && !t.IsAbstract).ToList();

                if (formTypes.Count > 0)
                {
                    Type mainFormType = formTypes.FirstOrDefault(t =>
                        t.Name.Contains("Main", StringComparison.OrdinalIgnoreCase)) ?? formTypes[0];

                    try
                    {
                        Form mainForm = Activator.CreateInstance(mainFormType) as Form;
                        if (mainForm != null)
                        {
                            mainForm.StartPosition = FormStartPosition.CenterScreen;
                            mainForm.Show();

                            MessageBox.Show($"{sb.ToString()}\n\n插件可能部分功能受限。",
                                "依赖警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    catch (Exception createEx)
                    {
                        throw new Exception($"创建窗体实例失败: {createEx.Message}\n{sb}", createEx);
                    }
                }

                throw new Exception($"加载插件失败:\n{sb}", ex);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载内置DLL插件失败:{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                AppDomain.CurrentDomain.AssemblyResolve -= CurrentDomain_AssemblyResolve;
            }
        }

        private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            try
            {
                string assemblyName = new AssemblyName(args.Name).Name;

                string pluginPath = Path.Combine(pluginsDirectory, assemblyName + ".dll");
                if (File.Exists(pluginPath))
                {
                    return Assembly.LoadFrom(pluginPath);
                }

                string currentPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, assemblyName + ".dll");
                if (File.Exists(currentPath))
                {
                    return Assembly.LoadFrom(currentPath);
                }

                return null;
            }
            catch
            {
                return null;
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
                    if (plugin.IsZipFile && !string.IsNullOrEmpty(plugin.ExtractFolder))
                    {
                        string extractFolderPath = Path.Combine(pluginsDirectory, plugin.ExtractFolder);
                        if (Directory.Exists(extractFolderPath))
                        {
                            Directory.Delete(extractFolderPath, true);
                        }
                    }
                    InitializePlugins();

                    UpdateMainMenuItemText(plugin, menuItem);
                    if (menuItem.DropDownItems.Count >= 3)
                    {
                        UpdateSubMenuItemsState(plugin,
                            menuItem.DropDownItems[0] as ToolStripMenuItem,
                            menuItem.DropDownItems[1] as ToolStripMenuItem,
                            menuItem.DropDownItems[2] as ToolStripMenuItem);
                    }

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
            var managerForm = new PluginManagerForm();
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

                    await DownloadFileWithProgressAsync(plugin.DownloadUrl, filePath);

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
                    }));
                }
                else
                {
                    progressBar.Value = percentage;
                    statusLabel.Text = $"下载中: {percentage}% ({FormatFileSize(bytesRead)} / {FormatFileSize(totalBytes)})";
                    speedLabel.Text = $"速度: {speedInfo.Speed:F1} {speedInfo.Unit}";
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
            private ListView listView;
            private Panel buttonPanel;

            public PluginManagerForm()
            {
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
                foreach (var plugin in Plugins.plugins)
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
                        if (plugin.Name == "CriFsV2Lib.Definitions.dll")
                        {
                            item.BackColor = SystemColors.Control;
                            item.ForeColor = SystemColors.GrayText;
                        }
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
                                Plugins.InitializePlugins();
                                LoadPlugins();

                                RefreshMainPluginMenu();

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
                        if (plugin.Name == "CriFsV2Lib.Definitions.dll")
                        {
                            MessageBox.Show($"{plugin.DisplayName}是依赖文件，无法直接启动。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
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
                            try
                            {
                                string filePath = Path.Combine(Plugins.pluginsDirectory, plugin.FileName);
                                if (File.Exists(filePath))
                                {
                                    File.Delete(filePath);
                                }

                                Plugins.InitializePlugins();
                                LoadPlugins();

                                // 刷新主程序的插件菜单
                                RefreshMainPluginMenu();

                                MessageBox.Show($"{plugin.DisplayName}卸载完成！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"卸载{plugin.DisplayName}失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }

            private void RefreshMainPluginMenu()
            {
                try
                {
                    var mainForm = Application.OpenForms.OfType<MainForm>().FirstOrDefault();
                    if (mainForm != null)
                    {
                        var pluginMenu = mainForm.MenuStrip1.Items["toolStripMenuItem20"] as ToolStripMenuItem;
                        if (pluginMenu != null)
                        {
                            var ownerControl = pluginMenu.Owner;
                            if (ownerControl != null && ownerControl.InvokeRequired)
                            {
                                ownerControl.Invoke(new Action(() => Plugins.AddMenuItemsToPluginMenu(pluginMenu)));
                            }
                            else
                            {
                                Plugins.AddMenuItemsToPluginMenu(pluginMenu);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"刷新主菜单失败: {ex.Message}");
                }
            }
        }
    }
}