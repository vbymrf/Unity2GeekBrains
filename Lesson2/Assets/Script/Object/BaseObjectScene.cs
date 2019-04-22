using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectScene

{
    /// <summary>
    /// Базовый класс всех объектов на сцене
    /// </summary>
    public abstract class BaseObjectScene : MonoBehaviour
    {
        protected bool IsVisibleP;//Отображение обьекта и его дочерних элементов        
        protected string _sName;        

        public GameObject _gObject;

        //protected int _layer;
        //protected Color _color;
        //protected Material _material;
        //protected Transform _myTransform;
        //protected Vector3 _position;
        //protected Quaternion _rotation;
        //protected Vector3 _scale;
        
        //protected Rigidbody _rigidbody;   
       
        #region UnityFunction
        protected virtual void Awake()
        {
            _gObject = gameObject;
            _sName = _gObject.name;  
        }
        #endregion 
        
       
        #region Property
         /// <summary>
        /// Скрывает/показывает объект на сцене не отключая его
        /// </summary>
        public bool _IsVisible
        {
            get { return IsVisibleP; }
            set
            {
                IsVisibleP = value;
                if (_gObject.GetComponent<MeshRenderer>())
                    _gObject.GetComponent<MeshRenderer>().enabled = IsVisibleP; //Из методички оставил на будущее, но слишком много не нужного кода
                if (_gObject.GetComponent<SkinnedMeshRenderer>())
                    _gObject.GetComponent<SkinnedMeshRenderer>().enabled = IsVisibleP;
                if(_gObject.GetComponent<SpriteRenderer>())
                _gObject.GetComponent<SpriteRenderer>().enabled = IsVisibleP;

                setVisibleRendererChild(IsVisibleP);

            }
        }

        public void setVisibleRendererChild(bool value)//Устанавливает видимость для всех дочерних обьектов 
        {
            Renderer[] m = GetComponentsInChildren<Renderer>();
           foreach (Renderer r in m)
            {
                r.enabled = value;
            }
        }

        #endregion

        ///// <summary>
        ///// Имя объекта
        ///// </summary>
        //public string Name
        //{
        //    get { return _name; }
        //    set
        //    {
        //        _name = value;
        //        InstanceObject.name = _name;
        //    }
        //}
        ///// <summary>
        ///// Слой объекта
        ///// </summary>
        //public int Layers
        //{
        //    get { return _layer; }
        //    set
        //    {
        //        _layer = value;

        //        if (_instanceObject != null)
        //        {
        //            _instanceObject.layer = _layer;
        //        }
        //        if (_instanceObject != null)
        //        {
        //            AskLayer(GetTransform, value);
        //        }
        //    }
        //}
        ///// <summary>
        ///// Цвет материала объекта
        ///// </summary>
        //public Color Color
        //{
        //    get { return _color; }
        //    set
        //    {
        //        _color = value;
        //        if (_material != null)
        //        {
        //            _material.color = _color;
        //        }
        //        AskColor(GetTransform, _color);
        //    }
        //}
        //public Material GetMaterial
        //{
        //    get { return _material; }
        //}

        ///// <summary>
        ///// Позиция объекта
        ///// </summary>
        //public Vector3 Position
        //{
        //    get
        //    {
        //        if (InstanceObject != null)
        //        {
        //            _position = GetTransform.position;
        //        }
        //        return _position;
        //    }
        //    set
        //    {
        //        _position = value;
        //        if (InstanceObject != null)
        //        {
        //            GetTransform.position = _position;
        //        }
        //    }
        //}
        ///// <summary>
        ///// Размер объекта
        ///// </summary>
        //public Vector3 Scale
        //{
        //    get
        //    {
        //        if (InstanceObject != null)
        //        {
        //            _scale = GetTransform.localScale;
        //        }
        //        return _scale;
        //    }
        //    set
        //    {
        //        _scale = value;
        //        if (InstanceObject != null)
        //        {
        //            GetTransform.localScale = _scale;
        //        }
        //    }
        //}
        ///// <summary>
        ///// Поворот объекта
        ///// </summary>
        //public Quaternion Rotation
        //{
        //    get
        //    {
        //        if (InstanceObject != null)
        //        {
        //            _rotation = GetTransform.rotation;
        //        }

        //        return _rotation;
        //    }
        //    set
        //    {
        //        _rotation = value;
        //        if (InstanceObject != null)
        //        {
        //            GetTransform.rotation = _rotation;
        //        }
        //    }
        //}
        ///// <summary>
        ///// Получить физическое свойство объекта
        ///// </summary>
        //public Rigidbody GetRigidbody
        //{
        //    get { return _rigidbody; }
        //}
        ///// <summary>
        ///// Ссылка на gameObject
        ///// </summary>
        //public GameObject InstanceObject
        //{
        //    get { return _instanceObject; }
        //}

        ///// <summary>
        ///// Получить Transform объекта
        ///// </summary>
        //public Transform GetTransform
        //{
        //    get { return _myTransform; }
        //}

        //#endregion
        //#region PrivateFunction
        ///// <summary>
        ///// Выставляет слой себе и всем вложенным объектам независимо от уровня вложенности
        ///// </summary>
        ///// <param name="obj">Объект</param>
        ///// <param name="lvl">Слой</param>
        //private void AskLayer(Transform obj, int lvl)
        //{
        //    obj.gameObject.layer = lvl;       // Выставляем объекту слой
        //    if (obj.childCount > 0)
        //    {
        //        foreach (Transform d in obj) // Проходит по всем вложенным объектам
        //        {
        //            AskLayer(d, lvl);        // Рекурсивный вызов функции
        //        }
        //    }
        //}

        //private void AskColor(Transform obj, Color color)//Выставляю цвет для SpriteRenderer (не представляю кому еще нужен цвет)
        //{
        //    if (obj.GetComponent<SpriteRenderer>())
        //    {
        //        obj.GetComponent<SpriteRenderer>().color = color;
        //    }
        //    if (obj.childCount > 0)
        //    {
        //        foreach (Transform d in obj) // Проходит по всем вложенным объектам
        //        {
        //            AskColor(d, color);        // Рекурсивный вызов функции
        //        }
        //    }

        //}
        //#endregion

    }
}
