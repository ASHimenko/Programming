using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectOrientedPractics.Model.Enums;

namespace ObjectOrientedPractics.Model.Discounts
{
    public class PercentDiscount : IDiscount
    {
        /// <summary>
        /// Максимальный размер скидки в процентах.
        /// </summary>
        private const double MaxDiscountValue = 0.10; 

        /// <summary>
        /// Сумма покупки, необходимая для увеличения скидки на 1%.
        /// </summary>
        private const double ThresholdForOnePercent = 1000.0;

        /// <summary>
        /// Начальный размер скидки в процентах.
        /// </summary>
        private const double InitialDiscountValue = 0.01; 

        /// <summary>
        /// Текущая скидка в процентах.
        /// </summary>
        private double _currentDiscount;

        /// <summary>
        /// Сумма, на которую покупатель уже совершил покупки товаров данной категории.
        /// </summary>
        private double _accumulatedAmount;

        /// <summary>
        /// Категория товаров, на которую распространяется скидка.
        /// </summary>
        public Category DiscountCategory { get; }

        /// <summary>
        /// Возвращает текущий процент скидки.
        /// </summary>
        public double CurrentDiscount => _currentDiscount;

        /// <summary>
        /// Возвращает сумму, накопленную по покупкам в данной категории.
        /// </summary>
        public double AccumulatedAmount => _accumulatedAmount;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="PercentDiscount"/>.
        /// </summary>
        /// <param name="category">Категория товаров, к которой применяется скидка.</param>
        public PercentDiscount(Category category)
        {
            DiscountCategory = category;
            _currentDiscount = InitialDiscountValue;
            _accumulatedAmount = 0.0;
        }

        /// <summary>
        /// Вычисляет общую стоимость товаров, относящихся к категории скидки.
        /// </summary>
        /// <param name="items">Список продуктов.</param>
        /// <returns>Сумма стоимостей товаров данной категории.</returns>
        private double GetCategoryTotalCost(List<Item> items)
        {
            if (items == null || items.Count == 0) return 0.0;

            return items
                .Where(item => item.Category.Equals(DiscountCategory))
                .Sum(item =>
                {
                    if (double.TryParse(item.Cost, out double itemCost))
                    {
                        return itemCost;
                    }
                    return 0.0;
                });
        }

        /// <summary>
        /// Рассчитывает доступный размер скидки для списка продуктов.
        /// Скидка применяется только к товарам, соответствующим категории.
        /// </summary>
        /// <param name="items">Список продуктов.</param>
        /// <returns>Размер скидки в денежном эквиваленте.</returns>
        public double Calculate(List<Item> items)
        {
            double categoryTotalCost = GetCategoryTotalCost(items);

            if (categoryTotalCost <= 0) return 0.0;

            double discountAmount = categoryTotalCost * _currentDiscount;

            return discountAmount;
        }

        /// <summary>
        /// Применяет скидку к товарам. В отличие от PointsDiscount, 
        /// здесь не списывается накопленная сумма, а просто возвращается размер скидки.
        /// </summary>
        /// <param name="items">Список продуктов.</param>
        /// <returns>Размер примененной скидки в денежном эквиваленте.</returns>
        public double Apply(List<Item> items)
        {
            double discountAmount = Calculate(items);

            return discountAmount;
        }

        /// <summary>
        /// Обновляет накопленную сумму покупок и, при необходимости, увеличивает процент скидки.
        /// </summary>
        /// <param name="items">Список купленных товаров.</param>
        public void Update(List<Item> items)
        {
            double purchaseAmount = GetCategoryTotalCost(items);

            if (purchaseAmount <= 0) return;

            _accumulatedAmount += purchaseAmount;
            int earnedPercents = (int)Math.Floor(_accumulatedAmount / ThresholdForOnePercent);
            double newDiscount = InitialDiscountValue + (earnedPercents * 0.01);
            _currentDiscount = Math.Min(newDiscount, MaxDiscountValue);

        }
    }
}
