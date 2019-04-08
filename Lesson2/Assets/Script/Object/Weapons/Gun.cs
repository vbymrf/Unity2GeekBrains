using UnityEngine;
using System.Collections;
namespace ObjectScene
{
    /// <summary>
    /// Класс определяет поведение оружия «Пистолет»
    /// </summary>
    public class Gun : Weapons
    {
        public override void Fire(Ammunition ammunition)
        {
            if (_fire)
            {
                if (ammunition)
                {
                    // Создаем пулю                                   
                    Bullet tempbulet = Instantiate(ammunition, _gun.position, _gun.rotation) as Bullet;
                    // Всегда проверяйте существование объекта, прежде чем к нему обратиться!
                    if (tempbulet)
                    {
                        // Добавляем ускорение к пуле
                        tempbulet.GetRigidbody.AddForce(_gun.forward * _force);
                        tempbulet.Name = "Bullet";                                                // Задаем имя пуле
                        _fire = false;                                                                // Сообщаем, что произошел выстрел
                        _recharge.Start(_rechargeTime);                               // Запускаем таймер
                    }
                }
            }
        }
    }

}
