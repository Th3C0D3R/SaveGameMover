using System;
using System.Collections.ObjectModel;

namespace SaveGameMoverData
{
    public static class Extensions
    {
        public static bool Change<T>(this ObservableCollection<T> list, int index, T newValue)
        {
            if (list == null)
            {
                return false;
            }

            if (index < 0)
            {
                return false;
            }

            if (list.Count <= index)
            {
                return false;
            }

            if (list[index] == null)
            {
                return false;
            }

            if (newValue == null)
            {
                return false;
            }

            try
            {
                list[index] = newValue;
                return true;
            }
            catch (Exception) { }
            return false;
        }
    }
}
