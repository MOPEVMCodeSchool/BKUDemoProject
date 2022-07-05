using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InvadersEngine
{
    public sealed class  MovementUser : Movement
    {
        public float Velocity = 0.25f;
        Vector2 ScreenPos;

        void GetInput()
        { 
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                ScreenPos.x -= Velocity;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                ScreenPos.x += Velocity;
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                ScreenPos.y += Velocity;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                ScreenPos.y -= Velocity;
            }
        }
        public override Vector2 UpdateCoords(float t, object[] values)
        {
            if (ScreenPos.x < -5)
                ScreenPos.x = -5;
            if (ScreenPos.x > 5)
                ScreenPos.x = 5;
            if (ScreenPos.y < -2)
                ScreenPos.y = -2;
            if (ScreenPos.y > 5)
                ScreenPos.y = 5;

            return ScreenPos;
        }

        protected override void FixedUpdate()
        {
            GetInput();
            base.FixedUpdate();
        }
    }
}