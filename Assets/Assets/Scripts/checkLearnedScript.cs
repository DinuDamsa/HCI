using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkLearnedScript : MonoBehaviour
{
    GameObject squirrelFW;
    GameObject meniu;

    private bool completed = false;

    public void OnFocusChanged(bool hasFocus)
    {
        checkSkipPossible();
    }

    public void checkSkipPossible()
    {
        squirrelFW.SetActive(completed);
        squirrelFW.transform.Rotate(50 * Time.deltaTime, 0, 0);
    }

    public void setCompleted()
    {
        this.completed = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        squirrelFW = GameObject.Find("squirrel.fw");
        meniu = GameObject.Find("meniu");
    }

    // Update is called once per frame
    void Update()
    {
        squirrelFW.transform.Rotate(0, 100 * Time.deltaTime, 0);
    }
}
