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
        private GameObject _controllersGameObject;
        private InputController _inputController;
        private FlashlightController _flashlightController;
        private static Main _instance;
        public static Main Instance { get; private set; }
        void Start()
        {
            _instance = this;
            _controllersGameObject = new GameObject { name = "Controllers" };
            _inputController = _controllersGameObject.AddComponent<InputController>();
            _flashlightController = _controllersGameObject.AddComponent<FlashlightController>();
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
        #endregion
    }
}
