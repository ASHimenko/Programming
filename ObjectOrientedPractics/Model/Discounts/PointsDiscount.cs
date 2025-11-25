using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObjectOrientedPractics.Model.Discounts
{
    public class PointsDiscount : IDiscount
    {
        /// <summary>
        /// Приватное поле для хранения текущего количества накопленных баллов.
        /// </summary>
        private int _point;

        /// <summary>
        /// Максимальный процент от общей стоимости, который может быть покрыт скидкой (30%).
        /// </summary>
        private const double MaxDiscountPercentage = 0.30;

        /// <summary>
        /// Процент от общей стоимости покупки, который начисляется в виде баллов (10%).
        /// </summary>
        private const double EarningPercentage = 0.10;

        /// <summary>
        /// Возвращает текущее количество накопленных баллов.
        /// </summary>
        public int Points => _point;

        /// <summary>
        /// Устанавливает новое количество накопленных баллов.
        /// Гарантирует, что баланс баллов не станет отрицательным.
        /// </summary>
        /// <param name="value">Новое значение баллов.</param>
        private void SetPoints(int value)
        {
            _point = Math.Max(0, value);
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="PointsDiscount"/> с начальным количеством баллов.
        /// </summary>
        /// <param name="initialPoint">Начальное количество баллов.</param>
        public PointsDiscount(int initialPoint)
        {
            if (initialPoint < 0)
            {
                MessageBox.Show("начальное число баллов не может быть отрицательным", "Ошибка",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SetPoints(initialPoint);
        }

        /// <summary>
        /// Вычисляет общую стоимость всех продуктов в списке, преобразуя строковое поле Cost в числовой формат.
        /// </summary>
        /// <param name="items">Список продуктов <see cref="Item"/>.</param>
        /// <returns>Общая стоимость заказа в формате <see cref="double"/>.</returns>
        private double GetTotalCost(List<Item> items)
        {
            if (items == null || items.Count == 0) return 0.0;
            return items.Sum(item =>
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
        /// Не списывает накопленные баллы.
        /// </summary>
        /// <param name="items">Список продуктов.</param>
        /// <returns>Размер скидки в денежном эквиваленте (не более 30% от стоимости).</returns>
        public double Calculate(List<Item> items)
        {
            double totalCost = GetTotalCost(items);
            if (totalCost <= 0) return 0.0;

            double maxAllowedDiscount = totalCost * MaxDiscountPercentage;
            double discountFromPoints = this.Points;
            double calculatedDiscount = Math.Min(discountFromPoints, maxAllowedDiscount);

            return calculatedDiscount;
        }

        /// <summary>
        /// Применяет скидку к товарам, списывает накопленные баллы и возвращает размер скидки.
        /// </summary>
        /// <param name="items">Список продуктов.</param>
        /// <returns>Размер примененной скидки в денежном эквиваленте.</returns>
        public double Apply(List<Item> items)
        {
            double discountAmount = Calculate(items);

            if (discountAmount > 0)
            {
                int pointsToSpend = (int)Math.Round(discountAmount);
                SetPoints(this.Points - pointsToSpend);
            }

            return discountAmount;
        }

        /// <summary>
        /// Добавляет баллы на основе полученного списка товаров (10% от общей стоимости, округление вверх).
        /// </summary>
        /// <param name="items">Список купленных товаров.</param>
        public void Update(List<Item> items)
        {
            double totalCost = GetTotalCost(items);
            double rawPointsEarned = totalCost * EarningPercentage;
            int pointsEarned = (int)Math.Ceiling(rawPointsEarned);

            if (pointsEarned > 0)
            {
                SetPoints(this.Points + pointsEarned);
            }
        }
    }
}
