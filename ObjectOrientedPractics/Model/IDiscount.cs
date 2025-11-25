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
        /// Вычисляет размер скидки в денежном эквиваленте для заданного списка товаров.
        /// Не изменяет внутреннее состояние скидки (не списывает баллы и т.п.).
        /// </summary>
        /// <param name="items">Список товаров, к которым применяется скидка.</param>
        /// <returns>Размер потенциальной скидки типа <see cref="double"/>.</returns>
        double Calculate(List<Item> items);

        /// <summary>
        /// Применяет скидку, возвращает ее размер и, при необходимости,
        /// изменяет внутреннее состояние скидки (например, списывает баллы).
        /// </summary>
        /// <param name="items">Список товаров, к которым применяется скидка.</param>
        /// <returns>Размер примененной скидки типа <see cref="double"/>.</returns>
        double Apply(List<Item> items);

        /// <summary>
        /// Обновляет внутреннее состояние скидки после совершения покупки (например,
        /// начисляет новые баллы или увеличивает процент скидки).
        /// </summary>
        /// <param name="items">Список купленных товаров.</param>
        void Update(List<Item> items);
    }
}
