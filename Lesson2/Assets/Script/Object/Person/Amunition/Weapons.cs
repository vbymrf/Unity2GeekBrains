using UnityEngine;
namespace ObjectScene
{
    /// <summary>
    ///  Базовый класс для всех типов оружий
    /// </summary>
    public abstract class Weapons : BaseObjectScene
    {
        /// <summary>
        /// Урон от оружия
        /// </summary>
        public float _fDamageWeapons;
        /// <summary>
        /// Скорость пули
        /// </summary>
        public float _fSpeedBullet;
        /// <summary>
        /// Звук выстрела
        /// </summary>
        protected AudioSource _aAudioShoot;
        /// <summary>
        /// Время между перезарядкой
        /// </summary>
        public float _fTimeBetweenRecharge;
        /// <summary>
        /// Время между стрельбой
        /// </summary>
        public float _fTimeBetweenFire;
        /// <summary>
        /// Максимальное количество патронов в магазине
        /// </summary>
        public abstract float _fCountAmmo { get; set; }
        /// <summary>
        /// Количество доступных патронов в магазине оружие
        /// </summary>
        public abstract float _fCountAmmoNow { get; set; }
        /// <summary>
        /// Сейчас стреляем?
        /// </summary>
        public bool _IsFire;
        /// <summary>
        /// Сечас перезарежаем?
        /// </summary>
        public bool _IsRecharge;

        protected float _fTimeLastFire=0;
        protected float _fTimeLastRecharge=0;

        protected override void Awake()
        {
            base.Awake();
            if (GetComponent<AudioSource>())
            {
                _aAudioShoot = GetComponent<AudioSource>();
            }
            _fTimeLastFire = Time.time;            
        }

        public abstract void Fire();

        
        




        //#region Serialize Variable
        //[SerializeField] protected Transform _gun;
        //[SerializeField] protected float _force = 500;
        //[SerializeField] protected float _rechargeTime = 0.2f;
        //// Можно добавить поля, которые хранили бы количество обойм, текущее количество патронов и т.д.
        //#endregion
        //#region Protected Variable
        //protected Timer _recharge = new Timer(); // Выделяем память под таймер        
        //protected bool _fire = true;             // Флаг, разрешающий стрелять
        //#endregion
        //#region Abstract Function
        //public abstract void Fire(Ammunition ammunition);
        //#endregion
        //protected virtual void Update()
        //{
        //    // Тут можно дописать условие: если не выбрано оружие или выбрано не огнестрельное оружие, то не производить подсчеты
        //    _recharge.Update();     // Производим подсчеты времени
        //    if (_recharge.IsEvent())// Если закончили отсчет, разрешаем стрелять
        //    {
        //        _fire = true;
        //    }
        //}
    }

}
