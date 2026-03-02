using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectOrientedPractics.Model;
using ObjectOrientedPractics.Model.Enums;

namespace ObjectOrientedPractics.Services
{
    /// <summary>
    /// Делегет.
    /// </summary>
    public delegate bool ItemFilterDelegate(Item item);

    public class DataTools
    {
        /// <summary>
        /// Критерий: стоимость товара строго выше 5000.
        /// </summary>
        public static bool IsCostAboveFiveThousand(Item item)
        {
            return double.Parse(item.Cost) > 5000;
        }

        /// <summary>
        /// Критерий: товар относится к категории Electronics.
        /// </summary>
        public static bool IsCategoryElectronics(Item item)
        {
            return item.Category == Category.Electronics;
        }

        /// <summary>
        /// Универсальный метод фильтрации, который использует делегат 
        /// для определения критерия включения товара.
        /// </summary>
        public List<Item> FilterItems(List<Item> items, Func<Item, bool> filterCriterion)
        {
            List<Item> filteredItems = new List<Item>();

            foreach (Item item in items)
            {
                if (filterCriterion(item))
                {
                    filteredItems.Add(item);
                }
            }
            return filteredItems;
        }

        /// <summary>
        /// Возвращает делегат для сортировки по имени.
        /// </summary>
        public static Comparison<Item> CompareByNameAscending()
        {
            return (item1, item2) => string.Compare(item1.Name, item2.Name, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Возвращает делегат для сортировки по стоимости (по возрастанию).
        /// </summary>
        public static Comparison<Item> CompareByCostAscending()
        {
            return (item1, item2) =>
            {
                double cost1 = double.TryParse(item1.Cost, out double c1) ? c1 : 0;
                double cost2 = double.TryParse(item2.Cost, out double c2) ? c2 : 0;

                return cost1.CompareTo(cost2);
            };
        }

        /// <summary>
        /// Возвращает делегат для сортировки по стоимости (по убыванию).
        /// </summary>
        public static Comparison<Item> CompareByCostDescending()
        {
            return (item1, item2) =>
            { 
                double cost1 = double.TryParse(item1.Cost, out double c1) ? c1 : 0;
                double cost2 = double.TryParse(item2.Cost, out double c2) ? c2 : 0;

                return cost2.CompareTo(cost1);
            };
        }

        /// <summary>
        /// Сортирует список товаров с помощью внешнего делегата Comparison<Item>.
        /// </summary>
        /// <param name="items">Список товаров для сортировки.</param>
        /// <param name="comparisonMethod">Делегат Comparison<Item>, реализующий логику сравнения.</param>
        /// <returns>Новый упорядоченный список.</returns>
        public List<Item> SortItems(List<Item> items, Comparison<Item> comparisonMethod)
        {
            if (items == null) return new List<Item>();

            List<Item> sortedList = new List<Item>(items);
            sortedList.Sort(comparisonMethod);

            return sortedList;
        }
    }
}
