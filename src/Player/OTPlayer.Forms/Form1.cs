using System.Reflection;

using Vlc.DotNet.Forms;

namespace OTPlayer.Forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitPalyCon();
        }

        VlcControl vlcControl;
        void InitPalyCon() {
            vlcControl = new VlcControl();
            splitContainer1.Panel1.Controls.Add(vlcControl);
            vlcControl.Dock = DockStyle.Fill;
            //设置vlc平台所属的文件事件
            vlcControl.VlcLibDirectoryNeeded += VlcControl_VlcLibDirectoryNeeded;
            //文件播放时间变化事件
            vlcControl.TimeChanged += VlcControl_TimeChanged;
        }

        private void VlcControl_TimeChanged(object? sender, Vlc.DotNet.Core.VlcMediaPlayerTimeChangedEventArgs e)
        {
            
        }

        private void VlcControl_VlcLibDirectoryNeeded(object? sender, VlcLibDirectoryNeededEventArgs e)
        {
            var assembly = Assembly.GetEntryAssembly();
            var directory = new FileInfo(assembly.Location).DirectoryName;
            if (null == directory) { return; }
            if (4 == IntPtr.Size)
            {
                e.VlcLibDirectory = new DirectoryInfo(Path.GetFullPath(@".\libvlc\win-x86"));
            }
            else
            {
                e.VlcLibDirectory = new DirectoryInfo(Path.GetFullPath(@".\libvlc\win-x64"));
            }
        }
    }
}