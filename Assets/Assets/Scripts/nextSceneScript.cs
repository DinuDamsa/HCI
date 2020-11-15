using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextSceneScript : MonoBehaviour
{
    public string nextScene;

    public void OnMouseUp()
    {
        SceneManager.LoadScene(nextScene);
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
