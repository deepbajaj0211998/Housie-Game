using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomNumberGeneration : MonoBehaviour
{

    public int num;
    public GameObject numberText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void OnClick_NumberGenerator()
    {
        num = Random.Range(0, 99);
        numberText.GetComponent<Text>().text = "Number is: " + num;
    }

}
