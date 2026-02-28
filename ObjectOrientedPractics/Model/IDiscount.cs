using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedPractics.Model
{
    /// <summary>
    /// Определяет контракт для всех типов скидок в системе.
    /// Все классы, реализующие этот интерфейс, должны предоставлять 
    /// механизмы расчета, применения и обновления скидки.
    /// </summary>
    public interface IDiscount
    {
        /// <summary>
        /// Возвращает информационное описание скидки (например, "Накопительная – 500 баллов").
        /// </summary>
        string Info { get; }

        /// <summary>
        /// Вычисляет размер скидки в денежном эквиваленте для заданного списка товаров.
        /// </summary>
        double Calculate(List<Item> items);

        /// <summary>
        /// Применяет скидку, возвращает ее размер и при необходимости изменяет внутреннее состояние скидки.
        /// </summary>
        double Apply(List<Item> items);

        /// <summary>
        /// Обновляет внутреннее состояние скидки после совершения покупки.
        /// </summary>
        void Update(List<Item> items);
    }
}
