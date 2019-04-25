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
        public Ammunition _GpBullet;
        public GameObject _GsPointWepons;
        public override float _fCountAmmo { get; set; } = 30;//Максимальнтое патронов в магазине
        public  override float _fCountAmmoNow { get; set; } = 30;//Патронов в магазине сейчас

        public GameObject _GsAnimationObject;//Обьект отыгрывания полета патронов из магазина

        
        protected override void Awake()
        {
            base.Awake();
            _GsAnimationObject.GetComponent<MeshRenderer>().enabled = false;
        }
        private void FixedUpdate()
        {
            if (Time.time - _fTimeLastFire <= _fTimeBetweenFire) _IsFire = true;
            else _IsFire = false;
            if (_IsRecharge)
            {
                if (Time.time - _fTimeLastRecharge <= _fTimeBetweenRecharge) _IsRecharge = true;
                else _IsRecharge = false;
            }
            if(!_IsRecharge)
            _GsAnimationObject.GetComponent<MeshRenderer>().enabled = _IsFire;//Включаем выключаем анимацию выстрела
        }

        public override void Fire()
        {
            if (Time.time - _fTimeLastFire <= _fTimeBetweenFire) _IsFire = true;
            else _IsFire = false;

            if (_IsRecharge)
            {
                if (Time.time - _fTimeLastRecharge <= _fTimeBetweenRecharge) _IsRecharge = true;
                else _IsRecharge = false;
            }

            if (_IsFire==true || _IsRecharge==true) return;//Не стреляем

            _aAudioShoot?.Play();
            Ammunition g = Instantiate(_GpBullet, _GsPointWepons.transform.position, _GsPointWepons.transform.rotation);

            //Instantiate(_GpBullet, _GsPointWepons.transform.position, _GsPointWepons.transform.rotation);
            //Destroy(_GpBullet, 3);
            _GpBullet.Initialization(gameObject.GetComponent<Automaton>(), _GsPointWepons);
            Destroy(g.gameObject, 3);
            _fTimeLastFire = Time.time;
        }
    }
 }

