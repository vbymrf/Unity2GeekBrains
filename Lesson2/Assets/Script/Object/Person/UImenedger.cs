using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ObjectScene.Controller;
namespace ObjectScene
{
    /// <summary>
    /// Класс, который создан для проверки получения элементов Unity
    /// </summary>
    public class UImenedger : MonoBehaviour
    {
        //private Image _kFlashImage;
        //private FlashlightController _kFlashController;


        public Component[] _kmCompanentUI;//Массив дочерних компанентов
        public Component   _kCompanentUI;//Компаненты, на кого накинули скрипт

        //public Component[] _kcCompanentUI;
        // public List<GameObject> _kolCompanentUI;// нельзя, т.к обьект и гейм обьект это не компанент 
        //public List<Component> _kclCompanentUI;
        //public Image[] _kmImageUI;
        //public List<Image> _klImageUI;

        private void Awake()
        {
            
            //_kcCompanentUI = GetComponents<Component>();
            //GetComponents<GameObject>(_kolCompanentUI);
            // GetComponents<Component>(_kclCompanentUI);
            // _kmImageUI= GetComponents<Image>();
            //GetComponentsInParent <Image>(true,_klImageUI);
            //_koCompanentUI = GetComponentsInParent<Component>();

            _kCompanentUI = GetComponent<Component>();
            _kmCompanentUI = GetComponentsInParent<Component>(); //Массив всех дочерних компанентов


        }

    }
}