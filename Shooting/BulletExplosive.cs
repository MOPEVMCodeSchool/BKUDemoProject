using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InvadersEngine
{
    public class BulletExplosive : BulletBallistic
    {
        public GameObject ExplosionEffect;
        public float ExplosionRadius = 1.0f;
        public int ExplosionDamage = 25;

        protected void Explode()
        {
            Collider[] cols = Physics.OverlapSphere(transform.position, ExplosionRadius);
            IDamageable d;

            GameObject exp = Instantiate(ExplosionEffect, transform.position, Quaternion.identity);
            exp.transform.localScale = new Vector3(ExplosionRadius, ExplosionRadius, ExplosionRadius);
            Destroy(exp, 0.15f);


            foreach (Collider c in cols)
            {
                d = c.gameObject.GetComponent<IDamageable>();
                if (d != null)
                    d.TakeDamage(ExplosionDamage);
            }
        }

        protected override void SelfDestroy()
        {
            Explode();
            base.SelfDestroy();
        }
    }
}