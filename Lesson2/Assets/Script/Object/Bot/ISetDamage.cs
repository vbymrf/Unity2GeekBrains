using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectScene
{

    /// <summary>
    /// интерфейс, для нанесения урона врагу. Который на него подписан
    /// </summary>
    public interface ISetDamage
    {        
        void ApplyDamage(float damage);
        void ApplyDamageForce(float damage, Vector3 force);
    }

}
