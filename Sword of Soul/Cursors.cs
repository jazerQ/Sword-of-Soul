using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Sword_of_Soul
{
    static class Cursors
    {
        static private List<string> cursors = new List<string> { "images\\woodenSwordBetter.cur" };
        static private string currentCursor;
        static public void setCurrentCursor(int index) {
            currentCursor = cursors[index];
        }
        public static void Set(Window window)
        {
            Cursor sword = new Cursor(Application.GetResourceStream(new Uri(currentCursor, UriKind.Relative)).Stream);
            window.Cursor = sword;
        }
    }
}
