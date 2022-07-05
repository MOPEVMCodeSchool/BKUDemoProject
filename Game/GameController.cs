using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace InvadersEngine
{
    public class GameController : MonoBehaviour
    {
        public UnityEvent<int> OnChangeScore;
        public int PlayerScore;

        public void AddPlayerScore(int value)
        {
            PlayerScore += value;
            OnChangeScore.Invoke(PlayerScore);
        }

        public void GameOver()
        {
            SceneManager.LoadScene("Gamover");
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}