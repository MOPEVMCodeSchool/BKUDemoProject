using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace InvadersEngine
{
    public abstract class BulletBase : Entity
    {
        public float Lifetime = 150;
        public int Damage = 15;

        protected override void Start()
        {
            base.Start();

            SetTimer(Lifetime);
            OnTimerElapsed += SelfDestroy;
        }

        protected virtual void DoBulletDamage(IDamageable target) {  }

        private void OnCollisionEnter(Collision collision)
        {
            IDamageable dmg;

            dmg = collision.gameObject.GetComponent<IDamageable>();

            if (dmg != null)
                DoBulletDamage(dmg);
            else
                SelfDestroy();
        }
    }
}