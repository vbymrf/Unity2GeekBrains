using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ObjectScene
{
    /// <summary>
    /// Клас определяет пулю
    /// </summary>
    public class Bullet : Ammunition
    {
        // Время жизни пули
        [SerializeField] private float _timeToDestruct = 10;
        // Урон пули
        [SerializeField] private float _damage = 20;
        //  Масса пули           
        [SerializeField] private float _mass = 0.01f;
        // Текущий урон, который может нанести пуля           
        private float _currentDamage;
        protected override void Awake()
        {
            base.Awake();
            // Если пуля не встретит ничего, то через заданное время пуля самоуничтожится
            Destroy(InstanceObject, _timeToDestruct);
            // В начале задаем базовый урон, но в дальнейшем он может измениться    
            _currentDamage = _damage;
            GetRigidbody.mass = _mass;
        }
        // Если пуля встретила препятствие
        private void OnCollisionEnter(Collision collision)
        {
            // Если столкнулись с другой пулей, ничего не делаем
            if (collision.collider.tag == "Bullet") return;
            // Передаем в функцию компоненты унаследованный от интерфейса  ISetDamage
            SetDamage(collision.gameObject.GetComponent<ISetDamage>());
            // Тут можно дописать функционал. Например, на месте столкновения создавать частицы искр и с помощью декалей вставлять дырки от пуль
            // Удаляем пулю
            Destroy(InstanceObject);
        }
        private void SetDamage(ISetDamage obj)
        {
            if (obj != null)
                // Вызываем функцию получения урона
                obj.ApplyDamage(_currentDamage);
        }
    }

}
