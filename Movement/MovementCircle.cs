using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InvadersEngine
{
    public class MovementCircle : Movement
    {
        public float Radius;
        public float AngularVelocity;

        public override Vector2 UpdateCoords(float t, object[] values)
        {
            Vector2 res;

            float x0 = (float)values[0];
            float y0 = (float)values[1];
            float r = (float)values[2];
            float a = (float)values[3];

            res.x = x0 + r * Mathf.Cos(a * t);
            res.y = y0 + r * Mathf.Sin(a * t);
            
            return res;
        }

        protected override Vector2 GetMovementVect()
        {
            return UpdateCoords(time, new object[] { StartPos.x, StartPos.y, Radius, AngularVelocity });
        }

        protected override void Start()
        {
            base.Start();
        }
    }
}