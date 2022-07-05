using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace InvadersEngine
{
    public abstract class Entity : MonoBehaviour
    {
        protected Action OnTimerElapsed;
        float timer = 0;

        protected virtual void FixedUpdate()
        {
            TimerTick();
        }

        protected void SetTimer(float t)
        { timer = t; }

        public float GetTimer()
        { return timer; }

        //public float Timer
        //{
        //    get { return timer; }  
        //    protected set { timer = value; }
        //}

        protected void SetTimer(float t, Action func)
        {
            timer = t;
            OnTimerElapsed += func;
        }

        protected virtual void Start() { }

        protected virtual void Update() { }

        void TimerTick()
        {
            // (timer != 0)
            if (timer > 0.0001f)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                timer = 0;

                // вызываем делегат для события завершения таймера
                if (OnTimerElapsed != null)
                    OnTimerElapsed();
            }
        }

        protected virtual void SelfDestroy()
        {
            Destroy(gameObject);
        }
    }
}