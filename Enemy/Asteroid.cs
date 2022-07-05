using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InvadersEngine
{
    public class Asteroid : EnemyBase
    {
        public int Damage = 25;
        protected bool bcansplit = true;

        protected override void Start()
        {
            base.Start();

            MovementLine mov = GetComponent<MovementLine>();

            if (mov != null)
                mov.Velocity = new Vector2(Random.Range(-0.25f, 0.25f), Random.Range(-1.25f, -5.75f));
        }

        private void OnCollisionEnter(Collision collision)
        {
            IDamageable dmg;

            if (collision.gameObject.CompareTag("Player"))
            {
                dmg = collision.gameObject.GetComponent<IDamageable>();

                if (dmg != null)
                    dmg.TakeDamage(Damage);

                bcansplit = false;
                SelfDestroy();
            }
        }

        protected override void SelfDestroy()
        {
            if (!bcansplit)
            {
                Destroy(gameObject);
                return;
            }

            Collider col = GetComponent<Collider>();
            Asteroid astr;
            MovementLine mov;

            if (col != null)
                col.enabled = false;              

            GameObject fragment;
            fragment = Instantiate(gameObject, transform.position + new Vector3(1.25f, 0, 0.5f), transform.rotation);
            fragment.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            col = fragment.GetComponent<Collider>();
            col.enabled = true;
            mov = fragment.GetComponent<MovementLine>();
            mov.Velocity = new Vector2(1.25f, -2.5f);
            // уберём возможность дробиться дальше у осколков (т.к. они скопируют это значение у текущего объекта)
            astr = fragment.GetComponent<Asteroid>();
            astr.bcansplit = false;
            astr.HitPonints = MaxHitPoints / 3;
            astr.Damage = Damage / 3;

            fragment = Instantiate(gameObject, transform.position + new Vector3(0.75f, 0, 1.25f), transform.rotation);
            fragment.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            col = fragment.GetComponent<Collider>();
            col.enabled = true;
            mov = fragment.GetComponent<MovementLine>();
            mov.Velocity = new Vector2(0.75f, -2.25f);
            // уберём возможность дробиться дальше у осколков (т.к. они скопируют это значение у текущего объекта)
            astr = fragment.GetComponent<Asteroid>();
            astr.bcansplit = false;
            astr.HitPonints = MaxHitPoints / 3;
            astr.Damage = Damage / 3;

            fragment = Instantiate(gameObject, transform.position + new Vector3(-0.75f, 0, -0.75f), transform.rotation);
            fragment.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            col = fragment.GetComponent<Collider>();
            col.enabled = true;
            mov = fragment.GetComponent<MovementLine>();
            mov.Velocity = new Vector2(-0.75f, -2.75f);
            // уберём возможность дробиться дальше у осколков (т.к. они скопируют это значение у текущего объекта)
            astr = fragment.GetComponent<Asteroid>();
            astr.bcansplit = false;
            astr.HitPonints = MaxHitPoints / 3;
            astr.Damage = Damage / 3;

            base.SelfDestroy();
        }
    }
}