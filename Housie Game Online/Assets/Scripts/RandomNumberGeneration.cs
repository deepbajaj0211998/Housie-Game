using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomNumberGeneration : MonoBehaviour
{

    public int num;
    public GameObject numberText;
    public Button rnButton;

    // Start is called before the first frame update
    void Start()
    {
        numberText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void OnClick_NumberGenerator()
    {
        numberText.SetActive(true);
        num = Random.Range(0, 99);
        numberText.GetComponent<Text>().text = "" + num;
        rnButton.GetComponent<Button>().enabled = false;
    }

}
