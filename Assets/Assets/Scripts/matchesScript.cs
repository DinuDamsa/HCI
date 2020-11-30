using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class matchesScript : MonoBehaviour
{
    public int selectedValue;
    public static int firstSelected;
    public static int lastSelected;

    public void OnMouseUp()
    {
        if(selectedValue < 3)
        {
            firstSelected = selectedValue;
        }
        else if(firstSelected != -1 && lastSelected == -1 && selectedValue >= 3 )
        {
            lastSelected  = selectedValue;
        }
       
    }

    // Start is called before the first frame update
    void Start()
    {
        lastSelected = -1;
        firstSelected = -1;
    }

    // Update is called once per frame
    void Update()
    {

    }
}