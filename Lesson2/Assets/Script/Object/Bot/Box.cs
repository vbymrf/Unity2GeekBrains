using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ObjectScene
{
    public class Box : BaseObjectScene, ISetDamage
    {   
        [SerializeField]
        private float Health=100;
        public bool _IsAlive=true;

        public Material _mBox;

        protected override void Awake()
        {
            base.Awake();
            _mBox = GetComponent<MeshRenderer>().material; 
            
        }

        public void ApplyDamage(float damage)
        {
            if (!_IsAlive) return;

            Health -= damage;
            _mBox.color = Random.ColorHSV();
            if (Health <= 0)
            {
                _IsAlive = false;
                Die();
            }

        }
        public void ApplyDamageForce(float damage, Vector3 force)
        {
            ApplyDamage(damage);
            GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
        }
        public void Die()
        {
            if(!_IsAlive)
            {
                _mBox.color=Color.red;

                Invoke("DeiInvoke", 10);               
                
            }
        }
        void DeiInvoke()
        {
                if (GetComponent<BoxCollider>())
                GetComponent<BoxCollider>().enabled = false;
                Destroy(gameObject, 2);
        }
    }
    
    
    
    //{
        //[SerializeField] private float _hp = 100; // Количество жизней
        //private bool _isDead = false;             // Флаг смерти
        //private float step = 2f;
        //public void Update()
        //{
        //    if (_isDead)                          // Если персонаж умер, запускаем анимацию смерти
        //    {
        //        Color color = GetMaterial.color;
        //        if (color.a > 0)                  // Понижаем альфа-канал у материала (плавное затухание)
        //        {
        //            color.a -= step / 100;
        //            Color = color;
        //        }
        //        if (color.a < 1)
        //        {
        //            Destroy(InstanceObject.GetComponent<Collider>());
        //            Destroy(InstanceObject, 5f);
        //        }
        //    }
        //}
        //public void ApplyDamage(float damage)
        //{
        //    if (_hp > 0)  // Если жизней больше 0, получаем урон
        //    {
        //        _hp -= damage;
        //    }
        //    if (_hp <= 0) // Если жизней меньше 0, окрашиваемся в красный цвет и говорим себе, что умерли
        //    {
        //        _hp = 0;
        //        Color = Color.red;
        //        _isDead = true;
        //    }
        //}

    //}
}
