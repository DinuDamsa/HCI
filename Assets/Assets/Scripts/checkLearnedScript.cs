using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class checkLearnedScript : MonoBehaviour
{
    static GameObject completed; // this is supposed to never be destroyed and to be obj.position.x == 0 if not finished and == 1 if yes.
    GameObject squirrel;

    void handleFinishedLearning()
    {
        Debug.Log("completed");
        Debug.Log(completed);

        Debug.Log("completed.transform.position.x");
        Debug.Log(completed.transform.position.x);

        if (completed.transform.position.x == 0)
        {
            squirrel.SetActive(false);
        }
        else
        {
            squirrel.SetActive(true);
        }
    }

    public static void setFinished()
    {
        Debug.Log("public void setFinished()");

        Debug.Log("completed");
        Debug.Log(completed);

        Debug.Log("completed.transform.position.x");
        Debug.Log(completed.transform.position.x);


        completed.transform.position = new Vector3(1,8,0);
    }


    // Start is called before the first frame update
    void Start()
    {
        completed = GameObject.Find("completed");
        squirrel = GameObject.Find("squirrel.fw");

        DontDestroyOnLoad(completed);
        
        handleFinishedLearning();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
