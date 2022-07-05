using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InvadersEngine
{
    public class Movement : MovementBase
    {
        public Vector2 StartPos;

        protected float time = 0;


        // Здесь происходит просчёт самого движения
        public override Vector2 UpdateCoords(float t, object[] values)
        {
            return new Vector2(0, 0);
        }

        // Здесь происходит передача парамтеров в "движение"
        protected virtual Vector2 GetMovementVect()
        {
            return UpdateCoords(time, new object[] { });
        }

        protected void Move()
        {
            Vector2 v = GetMovementVect(); 

            if (rb != null)
                rb.MovePosition(new Vector3(v.x, 0, v.y));
            else
                transform.position = new Vector3(v.x, 0, v.y);
        }

        protected virtual void FixedUpdate()
        {
            time += Time.deltaTime;
            Move();
        }

        protected virtual void Start()
        { 
            rb = GetComponent<Rigidbody>();

            if (bUseWorldCoords)
                StartPos = new Vector2(transform.position.x, transform.position.z);
        }
    }
}