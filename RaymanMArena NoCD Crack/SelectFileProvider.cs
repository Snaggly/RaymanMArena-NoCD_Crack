using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaymanMArena_NoCD_Crack
{
    class SelectFileProvider
    {
        readonly OpenFileDialog window = new OpenFileDialog();

        public SelectFileProvider(string filter)
        {
            window.Filter = filter;
        }

        public string GetFile()
        {
            if (window.ShowDialog() == true)
                return window.FileName;
            else
                return null;
        }
    }
}
