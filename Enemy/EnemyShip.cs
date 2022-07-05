using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace InvadersEngine
{
    // можно сделать и так...
    // [RequireComponent(typeof(HomingShooter))]
    public class EnemyShip : EnemyBase
    {
        Shooter shooter;
        bool b_is_homing;

        protected override void Start() 
        { 
            base.Start();

            shooter = GetComponent<Shooter>();

            if (shooter.GetType() == typeof(Shooter))
            {
                b_is_homing = false;
            }
            else if (shooter.GetType() == typeof(HomingShooter))
            {
                b_is_homing = true;
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                ((HomingShooter)shooter).TargetPos = player;
            }
            else
            {
                b_is_homing = false;
            }
        }

        protected override void FixedUpdate()
        {
            base.FixedUpdate();

            if (Random.Range(0.0f, 1.0f) >= 0.5f)
                shooter.Shoot();
        }
    }
}