using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using System.IO;

namespace RKedit
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string fileName;
        bool fileOpened = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFile();
        }

        private void OpenFile()
        {
            OpenFileDialog open = new OpenFileDialog()
            {
                Title = "Select File To Open",
                FileName = " "
            };

            if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StreamReader sr = new StreamReader(File.OpenRead(open.FileName));
                textEditor.Text = sr.ReadToEnd();


                fileName = open.FileName;
                fileOpened = true;

                sr.Dispose();
            }

            dir.Content = fileName;
            open.Dispose();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SaveFile();
        }

        private void SaveFile()
        {
            if (fileOpened)
            {
                File.WriteAllText(fileName, textEditor.Text);
            }

            else
            {
                SaveFileDialog save = new SaveFileDialog();

                if (save.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    File.WriteAllText(save.FileName, textEditor.Text);

                    fileOpened = true;
                    fileName = save.FileName;
                }

                dir.Content = fileName;

                save.Dispose();
            }

        }

        private void RichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (languageSelected.SelectedIndex == 0)
            {
                textEditor.SyntaxHighlighting = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.GetDefinition("None");
            }

            if (languageSelected.SelectedIndex == 1)
            {
                textEditor.SyntaxHighlighting = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.GetDefinition("Python");
            }

            if (languageSelected.SelectedIndex == 2)
            {
                textEditor.SyntaxHighlighting = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.GetDefinition("C++");
            }

            if (languageSelected.SelectedIndex == 3)
            {
                textEditor.SyntaxHighlighting = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.GetDefinition("HTML");
            }

            if (languageSelected.SelectedIndex == 4)
            {
                textEditor.SyntaxHighlighting = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.GetDefinition("CSS");
            }

            if (languageSelected.SelectedIndex == 5)
            {
                textEditor.SyntaxHighlighting = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.GetDefinition("C#");
            }
        }
    }
}
