using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InvadersEngine
{
    public sealed class MovementLine : Movement
    {
        public Vector2 Velocity;

        public override Vector2 UpdateCoords(float t, object[] values)
        {
            // y = kx + b -> y(t) = y0 + vy*t; x(t) = x0 + vx*t
            Vector2 res;

            float x0 = (float)values[0];
            float y0 = (float)values[1];
            float vx = (float)values[2];
            float vy = (float)values[3];
            
            res = new Vector2(x0, y0) + new Vector2(vx, vy) * t;
            return res;
        }

        protected override Vector2 GetMovementVect()
        {
            return UpdateCoords(time, new object[] { StartPos.x, StartPos.y, Velocity.x, Velocity.y });
        }

        protected override void Start()
        {
            base.Start();
        }
    }
}
