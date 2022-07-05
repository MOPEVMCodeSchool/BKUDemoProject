using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IndexedImageController : MonoBehaviour
{
    public Sprite[] Pictures;
    Image img;
    int cur_image = 0;


    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateImage(int value)
    {
        cur_image = Mathf.Clamp(value, 0, Pictures.Length-1);
        img.sprite = Pictures[cur_image];
    }
}
