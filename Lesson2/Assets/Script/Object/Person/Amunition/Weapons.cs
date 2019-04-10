using UnityEngine;
namespace ObjectScene
{
    /// <summary>
    ///  Базовый класс для всех типов оружий
    /// </summary>
    public abstract class Weapons : BaseObjectScene
    {
        #region Serialize Variable
        [SerializeField] protected Transform _gun;
        [SerializeField] protected float _force = 500;
        [SerializeField] protected float _rechargeTime = 0.2f;
        // Можно добавить поля, которые хранили бы количество обойм, текущее количество патронов и т.д.
        #endregion
        #region Protected Variable
        protected Timer _recharge = new Timer(); // Выделяем память под таймер        
        protected bool _fire = true;             // Флаг, разрешающий стрелять
        #endregion
        #region Abstract Function
        public abstract void Fire(Ammunition ammunition);
        #endregion
        protected virtual void Update()
        {
            // Тут можно дописать условие: если не выбрано оружие или выбрано не огнестрельное оружие, то не производить подсчеты
            _recharge.Update();     // Производим подсчеты времени
            if (_recharge.IsEvent())// Если закончили отсчет, разрешаем стрелять
            {
                _fire = true;
            }
        }
    }

}
