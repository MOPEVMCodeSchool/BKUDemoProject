using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace InvadersEngine
{
    public interface IDamageable
    {
        // функция, которая должна быть реализована у всех, кто может получить урон
        public void TakeDamage(int damage);

        public void RestoreDamage(int damage);
    }

    public abstract class EnemyBase : Entity, IDamageable
    {
        public UnityEvent<int> OnDestroy;

        public int HitPonints = 100;
        public int MaxHitPoints = 100;
        // сколько очков дадут за этот уничтоженный объект
        public int Score = 0;

        public virtual void RestoreDamage(int damage)
        {
            HitPonints = Mathf.Min(HitPonints + Mathf.Abs(damage), MaxHitPoints);
        }

        public virtual void TakeDamage(int damage)
        {
            HitPonints -= Mathf.Abs(damage);

            if (HitPonints <= 0)
                SelfDestroy();
        }

        public int CurrentHPPct
        {
            get { return (HitPonints * 100) / MaxHitPoints; }
        }


        protected override void SelfDestroy()
        {
            base.SelfDestroy();

            OnDestroy.Invoke(Score);
        }
    }
}