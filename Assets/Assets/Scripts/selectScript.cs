using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectScript : MonoBehaviour
{
    public int selectedValue;

    public void OnMouseUp()
    {
        Debug.Log(selectedValue);
        
        if(generateRandomScript.checkAnswer(selectedValue))
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
