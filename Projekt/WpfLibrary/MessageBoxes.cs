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
        /// <summary>
        /// Pops a yes/no window.
        /// </summary>
        /// <returns>True if 'yes' button pressed, otherwise false.</returns>
        public static bool RemoveCategoryBox()
        {
            if (MessageBox.Show("Czy na pewno chcesz usunąć kategorie?", "Usuń kategorie", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                    return false;
            return true;
        }

        /// <summary>
        /// Pops a yes/no window.
        /// </summary>
        /// <returns>True if 'yes' button pressed, otherwise false.</returns>
        public static bool RemoveFieldBox()
        {
            if (MessageBox.Show("Czy na pewno chcesz usunąć to pomieszczenie?", "Usuń pomieszczenie", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                return false;
            return true;
        }

        /// <summary>
        /// Pops a yes/no window.
        /// </summary>
        /// <returns>True if 'yes' button pressed, otherwise false.</returns>
        public static bool RemoveToReserveBox()
        {
            if (MessageBox.Show("Czy na pewno chcesz usunąć ten termin?", "Usuń termin", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                return false;
            return true;
        }

        /// <summary>
        /// Pops a yes/no window.
        /// </summary>
        /// <returns>True if 'yes' button pressed, otherwise false.</returns>
        public static bool LogOutBox()
        {
            if (MessageBox.Show("Czy na pewno chcesz się wyologować?", "Wyloguj", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                return false;
            return true;
        }

        /// <summary>
        /// Pops a yes/no window.
        /// </summary>
        /// <returns>True if 'yes' button pressed, otherwise false.</returns>
        public static bool DeleteUserBox()
        {
            if (MessageBox.Show("Czy na pewno chcesz \n pemanentnie usunąć konto użytkownika?", "Usuń konto", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                return false;
            return true;
        }

        /// <summary>
        /// Pops a yes/no window.
        /// </summary>
        /// <returns>True if 'yes' button pressed, otherwise false.</returns>
        public static bool DeleteReservationBox()
        {
            if (MessageBox.Show("Czy na pewno chcesz usunąć rezerwacje?", "Usuń rezerwacje", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                return false;
            return true;
        }
    }
}
