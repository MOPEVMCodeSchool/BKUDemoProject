using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InvadersEngine
{
    public class BulletBallistic : BulletBase
    {
        protected override void FixedUpdate()
        {
            base.FixedUpdate();
        }

        protected override void DoBulletDamage(IDamageable target)
        {
            target.TakeDamage(Damage);
            SelfDestroy();
        }
    }
}