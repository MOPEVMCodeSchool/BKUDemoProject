using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InvadersEngine
{
    public class Spawner : Entity
    {
        public float IntervalMin = 5.0f;
        public float IntervalMax = 10.0f;
        public GameObject[] Prefabs;
        Collider col;

        protected override void Start() 
        { 
            base.Start();

            col = GetComponent<Collider>(); 

            SetTimer(Random.Range(IntervalMin, IntervalMax));
            OnTimerElapsed += Spawn;
        }

        void Spawn()
        {
            GameObject go;
            GameController gc;
            EnemyBase enemy;

            int id = Random.Range(0, Prefabs.Length);

            Vector3 v = new Vector3(
            Random.Range(col.bounds.min.x, col.bounds.max.x),
            0,
            Random.Range(col.bounds.min.z, col.bounds.max.z));

            go = Instantiate(Prefabs[id], v, Prefabs[id].transform.rotation);
            enemy = go.GetComponent<EnemyBase>();

            go = GameObject.FindGameObjectWithTag("GameController");

            if (go != null)
            {
                gc = go.GetComponent<GameController>();

                if (enemy != null)
                    enemy.OnDestroy.AddListener(gc.AddPlayerScore);
            }

            SetTimer(Random.Range(IntervalMin, IntervalMax));
        }
    }
}