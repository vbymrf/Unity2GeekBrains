using UnityEngine;
namespace ObjectScene.Controller
{
    public sealed class FlashlightController : BaseController
    {
        private Light _light;            // Ссылка на источник света
        private bool Enabled;           // Влючен ли фонарик (свойство)

        private float _enabledTime;        //Время влючения фонарика 
        private float _energyTime;      //Время - энергия фонарика
        private float _fairTime;        //Время горения фонарика

        private void Awake()
        {
            _light = GameObject.Find("Flashlight").GetComponent<Light>();
            _fairTime = 10f;//Задаем 10 секунд на горение фонарика по умолчанию
        }
        public void Start()
        {
            SetActiveFlashlight(false); // При старте сцены выключаем фонарик
            Enabled = false;
        }
        public void Update()
        {
            if (!Enabled) return;       // Если контроллер неактивен, выходим из Update
                                        // Здесь описываем поведение фонарика: можно добавить максимальное время его работы, смену батареек и другое
            if (_enabledTime+ _energyTime - Time.time <= 0) Off();// выключаем фонарик, если он горит больше своего заряда
        }

        public float FairTime  //Задание времени горения фонарика
        {
            get { return _fairTime; }
            set { _fairTime = value; }
        }

        private void SetActiveFlashlight(bool value)
        {
            _light.enabled = value;
            Enabled = value;
        }
        public override void On()
        {
            if (Enabled) return;          // Если контроллер включен, повторно не включаем
            base.On();
            SetActiveFlashlight(true);
            _energyTime = FairTime;// Здесь менять. Т.к. само по себе условие выключения востанавлиает заряд некоректно
            _enabledTime = Time.time; //Записываем время включения фонарика
        }
        public override void Off()
        {
            if (!Enabled) return;        // Если контроллер выключен, повторно не выключаем
            base.Off();
            SetActiveFlashlight(false);
            _energyTime = Time.time-_enabledTime; //Остаток заряда записываем


        }
    }
}
