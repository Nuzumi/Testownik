using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Testownik
{
    public static class CustomCommands
    {
        public static readonly RoutedUICommand TrybEdycji = new RoutedUICommand
            (
                "TrybEdycji", "TrybEdycji", typeof(CustomCommands),
                new InputGestureCollection()
                {
                    new KeyGesture(Key.E,ModifierKeys.Control)
                }
            );

    }
}
