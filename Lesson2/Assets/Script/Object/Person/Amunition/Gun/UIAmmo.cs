using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ObjectScene.Controller;
namespace ObjectScene {
    public class UIAmmo : MonoBehaviour
    {
        private WeaponsController _kWeaponsController;
        private Image _kImage;
        private Text _kText;
        public float _fChangeColorRecharge = 10;

        public bool DebagIsPlugIn=false;//Если не появились контроллеры

        
        
        float A;
        bool Down = true;

        
        IEnumerator Start()
        {
            yield return new WaitWhile(() => Main.Instance == null);//Если обьект компанент Main не создан, то вызывается экзепшен при попытке обратиться к его содержимому. Странно, что просто не выдает null
            yield return new WaitWhile(() => Main.Instance.GetWeaponsController == null);//Вот здесь падает экзепшен без предыдущей строчки
            DebagIsPlugIn = true;
             _kWeaponsController = Main.Instance.GetWeaponsController;
            _kWeaponsController._eIsOnGetWepons += VisibleAmmo;
            _kImage = gameObject.GetComponent<Image>();
            _kText = gameObject.GetComponentInChildren<Text>();
        }
        private void OnDestroy()
        {            
            if (DebagIsPlugIn)            
            _kWeaponsController._eIsOnGetWepons -= VisibleAmmo;
        }
        void VisibleAmmo(Weapons wepons)
        {
            _kText.text = wepons._fCountAmmoNow.ToString();
            _kImage.fillAmount = wepons._fCountAmmoNow / wepons._fCountAmmo;
            if(wepons._IsRecharge)//Если перезаряжаем маргаем
            {
                A = _kImage.color.a;                
                if (Down)
                {
                    if (A - _fChangeColorRecharge >= 0)
                        A = A - _fChangeColorRecharge;
                    else Down = false;
                }
                else
                {
                    if (A + _fChangeColorRecharge <= 255)
                        A = A + _fChangeColorRecharge;
                    else Down = true;
                }
                _kImage.color = new Color(_kImage.color.r, _kImage.color.g, _kImage.color.b, A);

            }
        }
        
    }
}