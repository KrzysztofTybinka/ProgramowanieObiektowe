using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Projekt
{
    public class MessageBoxes
    {
        public static bool RemoveCategoryBox()
        {
            if (MessageBox.Show("Czy na pewno chcesz usunąć kategorie?", "Usuń kategorie", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                    return false;
            return true;
        }

        public static bool RemoveFieldBox()
        {
            if (MessageBox.Show("Czy na pewno chcesz usunąć to pomieszczenie?", "Usuń pomieszczenie", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                return false;
            return true;
        }
    }
}
