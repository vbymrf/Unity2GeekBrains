using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
namespace ObjectScene.Controller
{
    public delegate bool Predicate<T>(T a) ;
    public delegate void Action();
    /// <summary>
    /// Контроллер оружия для стрельбы
    /// </summary>
    public class WeaponsController : BaseController
{
        #region Точка привязки к оружию
        public Weapons[] _kmWepons;
        public int _iCurentWepons=0;
        #endregion
        /// <summary>
        /// Если стреляем или перезаряжаем запустить
        /// </summary>        
        public event Action<Weapons> _eIsOnGetWepons; 

        //public enum 

        private void Awake()
        {
            _kmWepons = FindObjectsOfType<Weapons>();
            for (int i=0; i < _kmWepons.Length; i++)
            {
                _kmWepons[i]._IsVisible = i == _iCurentWepons;
            }
            //_eIsOnGetWepons+= delegate { };//Пустой метод на событие, что бы не вызывала ошибок
        }
        private void FixedUpdate()
        {
            if (_kmWepons[_iCurentWepons] == null) return;
            if (_kmWepons[_iCurentWepons]._IsFire || _kmWepons[_iCurentWepons]._IsRecharge) _eIsOnGetWepons?.Invoke(_kmWepons[_iCurentWepons]);

        }


        public void Fire()
        {
            _kmWepons[_iCurentWepons].Fire();
        }

        public void ChangeWepons()
        {
            _kmWepons[_iCurentWepons]._IsVisible = false;
            if (_iCurentWepons == _kmWepons.Length-1) _iCurentWepons = 0;
            else _iCurentWepons++;
            _kmWepons[_iCurentWepons]._IsVisible = true;
        }
        public void ChangeWeponsScroll(bool next)
        {

            _kmWepons[_iCurentWepons]._IsVisible = false;//Выключаем видимость используемого
            if (next)
            {
                if (_iCurentWepons == _kmWepons.Length-1) _iCurentWepons = 0;
                else _iCurentWepons++;
            }
            else
            {
                if (_iCurentWepons == 0) _iCurentWepons = _kmWepons.Length-1;
                else _iCurentWepons--;
            }
            _kmWepons[_iCurentWepons]._IsVisible = true;//Включаем видимость следующего
        }




    //private Weapons _weapons;
    //private Ammunition _ammunition;
    //private int _mouseButton = (int)Main.MouseButton.LeftButton;
    //public bool Enabled { get; private set; }                    //---------------

    //public Weapons SelectedWeapons              // Оружие, которое сейчас выбрано
    //{
    //    get { return _weapons; }
    //}

        

    //    public void Update()
    //{
    //    if (!Enabled) return;
    //    if (Input.GetMouseButton(_mouseButton)) // Если зажата левая кнопка мыши
    //    {
    //        SelectedWeapons.Fire(_ammunition);
    //    }
    //}
    //public virtual void On(Weapons weapons, Ammunition ammunition)
    //{
    //    if (Enabled) return;
    //    base.On();
    //    _weapons = weapons;
    //    _ammunition = ammunition;
    //    _weapons.IsVisible = true;

    //}
    //public override void Off()
    //{
    //    if (Enabled) return;
    //    base.Off();
    //    _weapons.IsVisible = false;
    //    _weapons = null;
    //    _ammunition = null;
    //}
}
}
