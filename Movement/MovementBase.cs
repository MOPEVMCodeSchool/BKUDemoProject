using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InvadersEngine
{
    public abstract class MovementBase : MonoBehaviour
    {
        public bool bUseWorldCoords;
        protected Rigidbody rb;
        public abstract Vector2 UpdateCoords(float t, object[] values);
    }
}
