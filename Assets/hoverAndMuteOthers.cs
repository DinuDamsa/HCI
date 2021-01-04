using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hoverAndMuteOthers : MonoBehaviour
{
    private AudioSource sound;

    public void OnMouseEnter()
    {
        Debug.Log("MOUSE OVER");
        sound.Play();
        GameObject.Find("gameBkg.fw").GetComponent<AudioSource>().Stop();
    }

    public void OnMouseExit()
    {
        Debug.Log("MOUSE EXIT");
        sound.Stop();
    }

    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
