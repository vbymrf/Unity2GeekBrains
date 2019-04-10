using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ObjectScene.Controller;
using System;
// Привязать к UI картинки отображения света
namespace ObjectScene
{
    /// <summary>
    /// Отображает заряд фонарики и горит ли он.
    /// </summary>
    public class UIflashLight : MonoBehaviour
    {
        public FlashlightController _kFlashlightController;// Ссылка на контроллер
        public Image _kImage;// Ссылка на изображение
        public float _fFillAmount;// Заполнение энергией
        public Color _cOn; //Включен
        public Color _cOff;// Выключен

        private void Awake()
        {
            _kImage = GetComponent<Image>();

            Invoke("waitAwake", 1);// Задержка, что бы на сцене появился обьект Контроллеров. Иначе выходит ошибка (не рекомендуется создавать главнуе обьекты в реалтайм, либо нужно в корутине подгружать ссылки)
        }
        void waitAwake()
        {
            _kFlashlightController = Main.Instance.GetFlashlightController;            
            _kFlashlightController._eFlashLightUpdate += FillAmountChange;          
            
        }
        private void OnDestroy()
        {
            _kFlashlightController._eFlashLightUpdate -= FillAmountChange;
        }
        private void Start()
        {            
              if (_cOn != Color.white) _cOn = Color.white;
              _cOff = Color.grey;                                                
        }      
       
        void FillAmountChange(bool enable)
        {
            _fFillAmount=_kImage.fillAmount = _kFlashlightController._fEnergyAmount/ _kFlashlightController._fMaxEnergyAmount;
            if (enable) _kImage.color = _cOn;
            else _kImage.color = _cOff;
        }
    }
}