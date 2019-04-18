using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
namespace ObjectScene.Controller
{
    public sealed class FlashlightController : BaseController
    {
        #region Привязанные поля и методы к Модели Фонарика

        public ModelFlashLight _kModelFlashLight; // Ссылка на модель фонарика
        
        public bool Enable                           //Включен ли фонарик
        {
            get { return _kModelFlashLight.Enable; }
            set { _kModelFlashLight.Enable = value; }
        }
        public float _fEnergyAmount                  //Заряд фонарика
        {
            get { return _kModelFlashLight._fEnergyAmount; }
            set { _kModelFlashLight._fEnergyAmount = value; }
        }
        public float _fRechargeAmount               //К-т перезарядки, пока он выключен
        {
            get { return _kModelFlashLight._fRechargeAmount; }
            set { _kModelFlashLight._fRechargeAmount = value; }
        }
        public float _fMaxEnergyAmount               //Максимальный заряд фонарика
        {
            get { return _kModelFlashLight._fMaxEnergyAmount; }
            set { _kModelFlashLight._fMaxEnergyAmount = value; }
        }
        void ModelFlashLight_On()  { _kModelFlashLight.On(); } //Включение фонарика
        void ModelFlashLight_Off() { _kModelFlashLight.Off(); }//Выключение фонарика

        private void Awake()
        {
         _kModelFlashLight = GameObject.Find("Person").GetComponentInChildren<ModelFlashLight>(); // Здесь получаем модель. Здесь ее можно поменять
        }
        #endregion

        #region События - для расширения контроллера
        public event Action<bool> _eFlashLightUpdate;//Реже выходящий Update в корутине. Событие каждые waitUpdate. bool - передает состояние.
        public event Action<bool> _eEnabledFlashLight;//Событие, которое происходит при включении и выключении фонарика. bool - передает состояние.
        private WaitForSeconds waitUpdate = new WaitForSeconds(0.5f);//Время между работой псевдо Update
        private void Start()
        {
            StartCoroutine(OnFlashLight());
        }
        private void OnDestroy()
        {
            StopCoroutine(OnFlashLight());
        }
        IEnumerator OnFlashLight()
        {
            while (true)
            {
                yield return waitUpdate;
                _eFlashLightUpdate?.Invoke(Enable);
            }
        }
        #endregion

        ///// <summary>
        ///// Дебагер 
        ///// </summary>
        //private void OnGUI()
        //{
        //    if (_kModelFlashLight == null) return;
        //    GUILayout.Label("Энергия =" + (_kModelFlashLight._fEnergyAmount).ToString());           
        //    GUILayout.Label("Time.time =" + (Time.time).ToString());
        //}

        #region Контроллер состояния фонарика
        private void Update()
        {
            if (_kModelFlashLight==null) return;
            if (Enable)
            {
                if (_fEnergyAmount >= 0)
                {
                    _fEnergyAmount -= Time.deltaTime;
                }
                else
                {
                    Off();
                }
            }
            else
            {
                if (_fEnergyAmount < _fMaxEnergyAmount)
                {
                    _fEnergyAmount += Time.deltaTime*_fRechargeAmount;
                }
            }
        }
        public override void  On()
        {
            if (_kModelFlashLight == null) return;
            if (Enable == true || _fEnergyAmount< _fMaxEnergyAmount*0.3) return;
            ModelFlashLight_On();
            _eEnabledFlashLight?.Invoke(true);
        }
        public override void Off()
        {
            if (_kModelFlashLight == null) return;
            if (Enable == false) return;
            ModelFlashLight_Off();
            _eEnabledFlashLight?.Invoke(false);
        }
        #endregion

        //Старый код из методички для архива

        //private Light _light;
        //private Image _kImageLight;            //Ссылка на отображение в UI заряда фонарика
        //private bool Enabled;           // Влючен ли фонарик (свойство)
        //private float _enabledTime;        //Время влючения фонарика 
        //private float _energyTime;      //Время - энергия фонарика
        //private float _fairTime;        //Время горения фонарика
        //private float _fPlusEnergy;     //Заряжается фонарик пока выключен на коэ-ент от времени

        //private void Awake()
        //{
        //    //_light = GameObject.Find("Flashlight").GetComponent<Light>();
        //    //_kImageLight = GameObject.Find("UIflashLight").GetComponent<Image>();
        //}
        //public void Start()
        //{
        //    SetActiveFlashlight(false); // При старте сцены выключаем фонарик
        //    Enabled = false;
        //    _energyTime= _fairTime = 10f;//Задаем 10 секунд на горение фонарика по умолчанию
        //    _fPlusEnergy = 0.5f;//Заряжается фонарик в два раза медленнее
        //}

        ///// <summary>
        ///// Дебагер 
        ///// </summary>
        //private void OnGUI()
        //{
        //    GUILayout.Label("Энергия =" + (_energyTime / _fairTime).ToString());
        //    GUILayout.Label("_enabledTime Время влючения фонарика =" + (_enabledTime).ToString());
        //    GUILayout.Label("_energyTime Время - энергия фонарика =" + (_energyTime).ToString());
        //    GUILayout.Label("_fairTime Время горения фонарика =" + (_fairTime).ToString());
        //    GUILayout.Label("Time.time =" + (Time.time).ToString());
        //}
        //public void Update()
        //{
        //    if (!Enabled)
        //    {
        //        if (_energyTime < _fairTime)//Заряжается ак-тор
        //        {
        //            _energyTime += Time.deltaTime * _fPlusEnergy;
        //            _kImageLight.fillAmount = _energyTime / _fairTime;// Отображение заряда фонарика в интерфейсе UI
        //        }
        //        return;       // Если контроллер неактивен, выходим из Update
        //    }               

        //                                // Здесь описываем поведение фонарика: можно добавить максимальное время его работы, смену батареек и другое


        //    if(Time.frameCount%10==0) _energyTime -= Time.deltaTime*10;// Разрядка ак-та, подсчет на каждом 10 кадре           

        //    _kImageLight.fillAmount = _energyTime / _fairTime;// Отображение заряда фонарика в интерфейсе UI
        //    if (_energyTime <= 0)
        //    {               
        //        Off();// выключаем фонарик, если он горит больше своего заряда
        //    }
        //}


        //public float FairTime  //Задание времени горения фонарика
        //{
        //    get { return _fairTime; }
        //    set { _energyTime=_fairTime = value; }
        //}

        //private void SetActiveFlashlight(bool value)
        //{
        //    _light.enabled = value;
        //    Enabled = value;

        //}
        //public override void On()
        //{
        //    if (Enabled) return;          // Если контроллер включен, повторно не включаем
        //    base.On();
        //    SetActiveFlashlight(true);            
        //    _enabledTime = Time.time; //Записываем время включения фонарика
        //}
        //public override void Off()
        //{
        //    if (!Enabled) return;        // Если контроллер выключен, повторно не выключаем
        //    base.Off();
        //    SetActiveFlashlight(false);
        //}
    }
}
