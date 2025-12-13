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
        public List<Item> FilterItems(List<Item> items, ItemFilterDelegate filterCriterion)
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
    }
}
