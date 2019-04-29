﻿using UnityEngine;
using System.Collections;
namespace ObjectScene
{
    /// <summary>
    /// Класс определяет поведение оружия «Пистолет»
    /// </summary>
    public class Gun : Weapons
    {
        public Ammunition _GpBullet;
        public GameObject _GsPointWepons;
        public override float _fCountAmmo { get; set; } = 12;//Максимальнтое патронов в магазине
        public override float _fCountAmmoNow { get; set; } = 12;//Патронов в магазине сейчас

        private void FixedUpdate()
        {
            if (Time.time - _fTimeLastFire <= _fTimeBetweenFire) _IsFire = true;
            else _IsFire = false;
            if (_IsRecharge)
            {
                if (Time.time - _fTimeLastRecharge <= _fTimeBetweenRecharge) _IsRecharge = true;
                else
                {
                    _IsRecharge = false;
                    _fCountAmmoNow = _fCountAmmo;
                }
            }

            

        }

        public override void Fire()
        {
           
            //if (Time.time - _fTimeLastFire <= _fTimeBetweenFire) _IsFire = true;
            //else _IsFire = false;
            //if (_IsRecharge)
            //{
            //    if (Time.time - _fTimeLastRecharge <= _fTimeBetweenRecharge) _IsRecharge = true;
            //    else
            //    {
            //        _IsRecharge = false;
            //        _fCountAmmoNow = _fCountAmmo;
            //    }
            //}
            if (_IsFire == true || _IsRecharge == true) return;//Не стреляем

            _aAudioShoot?.Play();//Звук выстрела

            //Вылетает пуля
            Ammunition g = Instantiate(_GpBullet, _GsPointWepons.transform.position, _GsPointWepons.transform.rotation);

            //Instantiate(_GpBullet, _GsPointWepons.transform.position, _GsPointWepons.transform.rotation);
            //Destroy(_GpBullet, 3);
            _GpBullet.Initialization(gameObject.GetComponent<Gun>(), _GsPointWepons);
            Destroy(g.gameObject, 3);
            _fTimeLastFire = Time.time;
            //Перезарежаем
            _fCountAmmoNow--;
            if (_fCountAmmoNow <= 0)
            {
                _fTimeLastRecharge = Time.time;
                _IsRecharge = true;
            }
        }



        //public override void Fire(Ammunition ammunition)
        //{
        //    if (_fire)
        //    {
        //        if (ammunition)
        //        {
        //            Создаем пулю
        //            Bullet tempbulet = Instantiate(ammunition, _gun.position, _gun.rotation) as Bullet;
        //            Всегда проверяйте существование объекта, прежде чем к нему обратиться!
        //            if (tempbulet)
        //            {
        //                Добавляем ускорение к пуле
        //                tempbulet.GetRigidbody.AddForce(_gun.forward * _force);
        //                tempbulet.Name = "Bullet";                                                // Задаем имя пуле
        //                _fire = false;                                                                // Сообщаем, что произошел выстрел
        //                _recharge.Start(_rechargeTime);                               // Запускаем таймер
        //            }
        //        }
        //    }
        //}
    }

}
