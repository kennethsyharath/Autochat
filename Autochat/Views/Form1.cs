using Autochat.Controls;
using Autochat.Models;
using GlobalHotKey;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace Autochat
{
    public partial class Form1 : Form
    {
        HotKeyGraphTraversalEngine _engine;
        LocalPathResolver _resolver;
        PreviewData _pData;

        string filePath = null;

        public Form1(HotKeyGraphTraversalEngine engine, LocalPathResolver resolver, PreviewData pData)
        {
            InitializeComponent();
            _engine = engine;
            _resolver = resolver;
            _pData = pData;

            _pData.OnUpdated += () => UpdatePreviewList();

            PreviewList.Items.Add(new ListViewItem(new string[] { "test value", "another test value" }));
            PreviewList.Items.Add(new ListViewItem(new string[] { "test value2", "another test value2" }));
            PreviewList.Items.Add(new ListViewItem(new string[] { "test value3", "another test value3" }));
        }

        void UpdatePreviewList()
        {
            PreviewList.Items.Clear();
            foreach (var item in _pData.Data)
                PreviewList.Items.Add(new ListViewItem(new string[] { item.shortcut, item.content}));
        }

        private void InitateHotkeyObservationBtn_Click(object sender, EventArgs e)
        {
            _engine.InitializeEngineTo(filePath);
        }

        private void LoadYAMLStartNodeBtn_Click(object sender, EventArgs e)
        {
            OpenYAMLStartNode.ShowDialog();
        }

        private void OpenYAMLStartNode_FileOk(object sender, CancelEventArgs e)
        {
            //TODO: Validate the file and report errors to the user
            filePath = OpenYAMLStartNode.FileName;
            _resolver.SetDirectoryFromFilePath(filePath);
        }
    }
}