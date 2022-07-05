using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InvadersEngine
{
    public class HealBonus : BonusBase
    {
        public int Heal = 30;
        protected override void ApplyBonus(GameObject target)
        {
            PlayerShip ps = target.GetComponent<PlayerShip>();

            if (ps != null)
            {
                ps.RestoreDamage(Heal);
            }
        }
    }
}