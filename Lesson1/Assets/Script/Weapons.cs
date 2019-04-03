using UnityEngine;
namespace ObjectScene
{
    /// <summary>
    ///  Базовый класс для всех типов оружий
    /// </summary>
    public abstract class Weapons : BaseObjectScene
    {
        #region Serialize Variable 
        // Позиция, из которой будут вылетать снаряды
        [SerializeField] protected Transform _gun;
        // Сила выстрела                
        [SerializeField] protected float _force = 500;
        // Время задержки между выстрелами           
        [SerializeField] protected float _rechargeTime = 0.2f;
        #endregion
        #region Protected Variable
        protected bool _fire = true;
        // Флаг, разрешающий выстрел                                               
        #endregion
        #region Abstract Function
        // Функция для вызова выстрела, обязательна во всех дочерних классах
        public abstract void Fire();
        #endregion
    }
}
