using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ObjectScene
{
    /// <summary>
    /// Класс определяет амуницию (патроны)
    /// </summary>
    public abstract class Ammunition : BaseObjectScene
    {
        /// <summary>
        /// Если во что то попали
        /// </summary>
        public bool _IsHit;
        //protected Vector3 _vPositionBullet;
       // protected Quaternion _qPositionBullet;


        public abstract void Initialization(Weapons wepons, GameObject PointWepons);
    }
}