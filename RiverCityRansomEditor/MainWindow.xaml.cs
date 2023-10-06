using Microsoft.Win32;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Collections.Generic;

namespace RiverCityRansomEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            byte[] fileBytes = RomHandlingFile();
            var x = "x";
        }

        private byte[] RomHandlingFile()
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "NES roms (*.nes)|*.nes|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == true)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                    using (var fileStream = File.OpenRead(filePath))
                    {
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            fileStream.CopyTo(memoryStream);
                            return memoryStream.ToArray();
                        }
                    }
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}
