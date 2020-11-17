using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectScript : MonoBehaviour
{
    public int selectedValue;
    public int correctNumber;

    public void OnMouseUp()
    {
        Debug.Log(selectedValue);
        Debug.Log(correctNumber);
        
        if(selectedValue == correctNumber)
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
