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
        Panel panel;
        void InitPalyCon() {
            vlcControl = new VlcControl();
            Controls.Add(vlcControl);
            vlcControl.Dock = DockStyle.Fill;
            //����vlcƽ̨�������ļ��¼�
            vlcControl.VlcLibDirectoryNeeded += VlcControl_VlcLibDirectoryNeeded;
            //�ļ�����ʱ��仯�¼�
            vlcControl.TimeChanged += VlcControl_TimeChanged;
            panel = new Panel();
            panel.
            //1018, 59 0.572
            vlcControl.Controls.Add()
            panel1.Click += Panel1_Click;
            this.BackColor = Color.White; this.TransparencyKey = Color.White;
            //this.Opacity = 0.8;
        }

        private void Panel1_Click(object? sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void VlcControl_TimeChanged(object? sender, Vlc.DotNet.Core.VlcMediaPlayerTimeChangedEventArgs e)
        {
            
        }

        private void VlcControl_VlcLibDirectoryNeeded(object? sender, VlcLibDirectoryNeededEventArgs e)
        {
            var assembly = Assembly.GetEntryAssembly();
            var directory = new FileInfo(assembly.Location).DirectoryName;
            if (null == directory) { return; }
            //Environment.Is64BitOperatingSystem
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