using UnityEngine;
namespace ObjectScene.Controller
{
    /// <summary>
    /// Контроллер, который отвечает за горячие клавиши
    /// </summary>
    public sealed class InputController : BaseController
    {
        private bool _isActiveFlashlight = false;
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
        }
    }
}
