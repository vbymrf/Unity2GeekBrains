using UnityEngine;
using System.Collections.Generic;
using ObjectScene.Controller; // Подключаем пространство имен, в котором находятся контроллеры
//using ObjectScene.Helper;     // Подключаем пространство имен, в котором находятся хэлперы
namespace ObjectScene
{
    /// <summary>
    /// Точка входа в программу
    /// </summary>
    public sealed class Main : MonoBehaviour
    {
        private static Main _instance;
        public static Main Instance { get => _instance; private set=> _instance=value; }

        public  GameObject _gPerson;

        
        public  GameObject _controllersGameObject { get; private set; }

        private InputController _inputController;
        private FlashlightController _flashlightController;        
        private WeaponsController _weaponsController;
        private ObjectManager _objectManager;

        private void Awake()
        {            
            _gPerson = GameObject.FindGameObjectWithTag("Player");
        }

        

        void Start()
        {
            if (Instance) DestroyImmediate(gameObject); //Здесь мы говорим, что нельзя использовать больше одного Main
            else _instance = this;           

                _controllersGameObject = new GameObject { name = "Controllers" };
                _inputController = _controllersGameObject.AddComponent<InputController>();
                _flashlightController = _controllersGameObject.AddComponent<FlashlightController>();
                _weaponsController = _controllersGameObject.AddComponent<WeaponsController>();
                _objectManager = _controllersGameObject.AddComponent<ObjectManager>();
           
        }


        #region Property      
        /// <summary>
        /// Получить контроллер фонарика
        /// </summary>
        public FlashlightController GetFlashlightController
        {
            get { return _flashlightController; }
        }

        

        /// <summary>
        /// Получить контроллер ввода данных
        /// </summary>
        /// <returns></returns>
        public InputController GetInputController()
        {
            return _inputController;
        }

        /// <summary>
        /// Получить менеджер обьектов
        /// </summary>
        public ObjectManager GetManagerObject { get => _objectManager; }
        /// <summary>
        /// Получить контроллер оружия
        /// </summary>
        public WeaponsController GetWeaponsController { get=> _weaponsController; }

        #endregion
    }
}
