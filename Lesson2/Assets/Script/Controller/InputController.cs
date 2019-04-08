using UnityEngine;
namespace ObjectScene.Controller
{
    /// <summary>
    /// Контроллер, который отвечает за «горячие» клавиши
    /// </summary>
    public class InputController : BaseController
    {
        private bool _isActiveFlashlight = false;
        private bool _isSelectWeapons = true;
        private int _indexWeapons = 0;
        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                _isActiveFlashlight = !_isActiveFlashlight;
                if (_isActiveFlashlight)
                {
                    Main.Instance.GetFlashlightController.On();
                }
                else
                {
                    Main.Instance.GetFlashlightController.Off();
                }
            }
            // Меняем оружие по нажатию клавиш
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                _indexWeapons = 0;
                _isSelectWeapons = false;
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                _indexWeapons = 1;
                _isSelectWeapons = false;
            }
            // Меняем оружие колесиком        
            if (_isSelectWeapons) return;
            if (Main.Instance.GetManagerObject.GetWeaponsList[_indexWeapons])
            {
                // Передаем в контроллер стрельбы чем и из чего стрелять
                Main.Instance.GetWeaponsController.On(Main.Instance.GetManagerObject.GetWeaponsList[_indexWeapons], Main.Instance.GetManagerObject.GetAmmunitionList[_indexWeapons]);
            }
            _isSelectWeapons = true;
        }
    }

}
