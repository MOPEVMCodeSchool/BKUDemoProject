using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace InvadersEngine
{
    public class PlayerShip : EnemyBase
    {
        public UnityEvent<int> OnChangeHP;
        public UnityEvent<int> OnChangeAmmo; 
        public BulletBase[] Bullets;
        public Shooter[] shooters;

        int CurBullet = 0;

        protected override void Start()
        {
            base.Start();
            ChangeBullet(CurBullet);
            OnChangeHP.Invoke(CurrentHPPct);
        }

        protected override void FixedUpdate()
        {
            base.FixedUpdate();
        }

        protected override void Update()
        {
            base.Update();

            if (Input.GetKey(KeyCode.Space))
            {
                Shoot();
            }

            if (Input.GetKeyUp(KeyCode.F))
            {
                CurBullet = Mathf.Clamp(CurBullet + 1, 0, Bullets.Length);
                ChangeBullet(CurBullet);
            }

            if (Input.GetKeyUp(KeyCode.G))
            {
                CurBullet = Mathf.Clamp(CurBullet - 1, 0, Bullets.Length);
                ChangeBullet(CurBullet);
            }
        }

        protected virtual void Shoot()
        {
            foreach (Shooter s in shooters)
                s.Shoot();
        }

        protected void ChangeBullet(int id)
        {
            foreach (Shooter s in shooters)
                s.Projectile = Bullets[Mathf.Clamp(id, 0, Bullets.Length-1)].gameObject;
            OnChangeAmmo.Invoke(id);
        }

        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);

            OnChangeHP.Invoke(CurrentHPPct);
        }

        public override void RestoreDamage(int damage)
        {
            base.RestoreDamage(damage);

            OnChangeHP.Invoke(CurrentHPPct);
        }
    }
}


// Можно сделать:
// -- бонусы
// -- врагов V
// -- подсчёт очков (в статическом классе) V
// -- статический класс, который создаёт эффекты взрыва