using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InvadersEngine
{
    public class HomingShooter : Shooter
    {
        public GameObject TargetPos;
        public float MuzzleOffset = 3.0f;
        public float BulletExtraVelocity = 1.0f;

        protected override GameObject[] MakeProjectiles()
        {
            if (TargetPos == null)
                return new GameObject[0];

            Vector3 dir = (TargetPos.transform.position - transform.position).normalized;

            GameObject prj = Instantiate(Projectile, transform.position + dir * MuzzleOffset, Projectile.transform.rotation);
            Rigidbody rb = prj.GetComponent<Rigidbody>();
            MovementLine prj_move = prj.GetComponent<MovementLine>();

            if (prj.GetComponent<Rigidbody>() != null)
                rb.rotation = Quaternion.LookRotation(dir, Vector3.up);
            else
                prj.transform.rotation = Quaternion.LookRotation(dir, Vector3.up);

            prj_move.Velocity = new Vector2(dir.x, dir.z).normalized * BulletExtraVelocity;

            return new GameObject[] { prj };
        }
    }
}