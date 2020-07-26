using System;
using System.Windows;

namespace RaymanMArena_NoCD_Crack
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Fields
        private readonly UIControll ui = UIControll.GetNewController();
        private readonly SelectFileProvider sfp = new SelectFileProvider("Executable File | *.exe");
        private string _filePath;
        private IPatcher patcher;

        //Properties
        private string FilePath
        {
            get
            {
                return _filePath;
            }
            set
            {
                if (value != null)
                {
                    _filePath = value;
                    ui.FileName = _filePath.Substring(_filePath.LastIndexOf(@"\") + 1);
                }
            }
        }

        //Constructor
        public MainWindow()
        {
            InitializeComponent();
            DataContext = ui;
        }

        //Events
        private void Window_Initialized(object sender, EventArgs e)
        {
            ui.ReadyToCrack = false;
        }

        private void SelectFile_Click(object sender, RoutedEventArgs e)
        {
            string selectedFile = sfp.GetFile();
            if (Validate(selectedFile))
                FilePath = selectedFile;
            else
                ErrorBox("Error! Unsupported File");
        }

        private void CrackButton_Click(object sender, RoutedEventArgs e)
        {
            patcher?.PatchFile(ui.CreateBackup);
            SuccessBox("Success! Use this app to uncrack the game if needed.");
            Environment.Exit(0);
        }

        //Methods
        private bool Validate(string FileToCheck)
        {
            //Yeah I could have handled it so much better... This entire code is a disgrace
            //Rayman M
            patcher = new Patcher(FileToCheck, PatchNode.OffsetM, PatchNode.OriginalM, PatchNode.PatchedM);
            
            if (patcher.IsPatchable)
            {
                UnlockCrackButton();
                return true;
            }
            else if (patcher.IsAlreadyPatched())
            {
                patcher.ToPatchBytes = PatchNode.OriginalM;
                UnlockUnCrackButton();
                return true;
            }

            //Rayman Arena
            patcher.Offset = PatchNode.OffsetA;
            patcher.OriginalBytes = PatchNode.OriginalA;
            patcher.ToPatchBytes = PatchNode.PatchedA;

            if (patcher.IsPatchable)
            {
                UnlockCrackButton();
                return true;
            }
            else if (patcher.IsAlreadyPatched())
            {
                patcher.ToPatchBytes = PatchNode.OriginalA;
                UnlockUnCrackButton();
                return true;
            }

            //Rayman M Obscure the first 
            patcher.Offset = PatchNode.OffsetUbiExFocus;
            patcher.OriginalBytes = PatchNode.OriginalUbiExFocus;
            patcher.ToPatchBytes = PatchNode.PatchedUbiExFocus;

            if (patcher.IsPatchable)
            {
                UnlockCrackButton();
                return true;
            }
            else if (patcher.IsAlreadyPatched())
            { //I'm cringing so hard on this
                patcher.ToPatchBytes = PatchNode.OriginalUbiExFocus;
                UnlockUnCrackButton();
                return true;
            }

            return false;
        }

        private void UnlockCrackButton()
        {
            ui.ReadyToCrack = true;
            ui.CrackButtonLabel = "Crack It!";
        }

        private void UnlockUnCrackButton()
        {
            ui.ReadyToCrack = true;
            ui.CrackButtonLabel = "UnCrack It!";
        }

        private void ErrorBox(string Text)
        {
            MessageBox.Show(Text, "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }

        private void SuccessBox(string Text)
        {
            MessageBox.Show(Text, "Succ", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
