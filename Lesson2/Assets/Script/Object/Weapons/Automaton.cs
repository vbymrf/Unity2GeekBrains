using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ObjectScene
{
    /// <summary>
    /// Класс определяет поведение оружия «Автомат»
    /// </summary>
    public class Automaton : Weapons
    {
        public override void Fire(Ammunition ammunition)
        {
            if (_fire) // Если можно стрелять
            {
                // Создаем снаряд (пулю)
            }
        }
    }
}
