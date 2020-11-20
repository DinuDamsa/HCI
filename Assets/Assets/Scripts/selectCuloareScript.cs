using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectCuloareScript : MonoBehaviour
{
    public int selectedValue;

    public void OnMouseUp()
    {
        Debug.Log(selectedValue);

        if (genereazaAnimaleColorateScript.checkAnswer(selectedValue))
        {
            // felicitari
            Debug.Log("FELICITARI!");
        }
        else
        {
            // oof
            Debug.Log("OOF!");
        }
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
