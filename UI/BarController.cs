using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace InvadersEngine
{
    public class BarController : MonoBehaviour
    {
        public int Value;

        float width, height;
        RectTransform rt;

        // Start is called before the first frame update
        void Start()
        {
            rt = GetComponent<RectTransform>();
            width = rt.offsetMax.x;
            height = rt.offsetMax.y;
        }

        // Update is called once per frame
        void Update()
        {
            rt.offsetMax = new Vector2(width * 0.01f * Value, height);
        }

        public void UpdateBar(int value)
        {
            Value = value;
        }
    }

}