using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InvadersEngine
{
    public class Shooter : Entity
    {
        public GameObject Projectile;
        public float ShootCooldown = 5;

        protected override void Start()
        { 
            base.Start();

            OnTimerElapsed += Recharge;

            if (Projectile == null)
                this.enabled = false;
        }

        protected virtual void Recharge()
        {  }

        protected virtual GameObject[] MakeProjectiles()
        {
            return new GameObject[] { Instantiate(Projectile, transform.position, Projectile.transform.rotation) };
        }

        public void Shoot()
        {
            if (GetTimer() <= 0.0001f)
            {
                MakeProjectiles();
                SetTimer(ShootCooldown);
            }
        }
    }
}