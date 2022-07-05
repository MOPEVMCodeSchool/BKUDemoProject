using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ValueLabelController : MonoBehaviour
{
    public int Value;
    public string Header = "Score: ";
    Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = Header + Value.ToString();
    }

    public void UpdateText(int value)
    {
        Value = value;
    }
}
