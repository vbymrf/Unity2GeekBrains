using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ObjectScene.Controller
{
    /// <summary>
    /// Класс оружия, из которого выходят снаряды
    /// </summary>
    public class WeaponsController : BaseController
{
    private Weapons _weapons;
    private Ammunition _ammunition;
    private int _mouseButton = (int)Main.MouseButton.LeftButton;
    public bool Enabled { get; private set; }                    //---------------

    public Weapons SelectedWeapons              // Оружие, которое сейчас выбрано
    {
        get { return _weapons; }
    }

        

        public void Update()
    {
        if (!Enabled) return;
        if (Input.GetMouseButton(_mouseButton)) // Если зажата левая кнопка мыши
        {
            SelectedWeapons.Fire(_ammunition);
        }
    }
    public virtual void On(Weapons weapons, Ammunition ammunition)
    {
        if (Enabled) return;
        base.On();
        _weapons = weapons;
        _ammunition = ammunition;
        _weapons.IsVisible = true;

    }
    public override void Off()
    {
        if (Enabled) return;
        base.Off();
        _weapons.IsVisible = false;
        _weapons = null;
        _ammunition = null;
    }
}
}
