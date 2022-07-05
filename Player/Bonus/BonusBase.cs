using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InvadersEngine
{
    public abstract class BonusBase : Entity
    {
        public float Lifetime = 15;

        protected override void Start()
        {
            base.Start();

            SetTimer(Lifetime);
            OnTimerElapsed += SelfDestroy;
        }

        // target -- то, к чему применяется бонус (например, игрок)
        protected virtual void ApplyBonus(GameObject target)
        { }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                ApplyBonus(other.gameObject);
                SelfDestroy();
            }
        }
    }
}