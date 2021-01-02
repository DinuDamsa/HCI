using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helpScript : MonoBehaviour
{
    private int direction = 1;
    GameObject pointerFW;
    GameObject pointerFW1;
    GameObject pointerLeftFW;
    GameObject bear;

    private AudioSource sound1;
    private AudioSource sound2;
    private AudioSource sound3;
    private bool firstPlaying = false;
    private bool secondPlaying = false;
    private bool thirdPlaying = false;
    private float trackLength = -1;

    private float[] Xpos = { 4.25f, 3.25f, 0f }; //{ 7.5f, 3.75f, 0f }; 
    private float[] Nextpos = { 4.25f, -4f, 0f }; //{ 7.5f, -3.75f, 0f }; 
    private float[] Prevpos = { -4.25f, -4f, 0f }; //{ -7.5f, 3.75f, 0f }; 

    private float upperBound = 0.15f;
    private float lowerBound = -0.15f;

    public void OnMouseUp()
    {
        // disable bear.fw
        bear.GetComponent<Collider2D>().enabled = false;
        bear.GetComponent<AudioSource>().Stop();

        pointerFW1.SetActive(false);
        pointerLeftFW.SetActive(false);

        firstPlaying = true;
        pointerFW.SetActive(true);

        sound1.Play();
        trackLength = sound1.clip.length;
    }

    // Start is called before the first frame update
    void Start()
    {
        pointerFW = GameObject.Find("pointer.fw");
        pointerFW1 = GameObject.Find("pointer.fw (1)");
        pointerLeftFW = GameObject.Find("pointerLeft.fw");

        bear = GameObject.Find("bear.fw");

        sound1 = GameObject.Find("pointer.fw").GetComponent<AudioSource>();
        sound2 = GameObject.Find("pointer.fw (1)").GetComponent<AudioSource>();
        sound3 = GameObject.Find("pointerLeft.fw").GetComponent<AudioSource>();

        Debug.Log("LENGTH = " + sound1.clip.length);
        Debug.Log("LENGTH = " + sound2.clip.length);
        Debug.Log("LENGTH = " + sound3.clip.length);

        pointerFW.transform.position = new Vector3(Xpos[0], Xpos[1], Xpos[2]);
        pointerFW1.transform.position = new Vector3(Nextpos[0], Nextpos[1], Nextpos[2]);
        pointerLeftFW.transform.position = new Vector3(Prevpos[0], Prevpos[1], Prevpos[2]);

        pointerFW.SetActive(false);
        pointerFW1.SetActive(false);
        pointerLeftFW.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (pointerFW.transform.rotation.z > upperBound || pointerFW.transform.rotation.z < lowerBound)
        {
            Debug.Log(pointerFW.transform.rotation.z);
            direction *= -1;
        }

        pointerFW.transform.Rotate(0, 0, 25 * direction * Time.deltaTime);
        pointerFW1.transform.Rotate(0, 0, 25 * direction * Time.deltaTime);
        pointerLeftFW.transform.Rotate(0, 0, 25 * direction * Time.deltaTime);

        if (firstPlaying && trackLength <= 0)
        {
            pointerFW.SetActive(false);
            pointerFW1.SetActive(true);

            sound2.Play();
            firstPlaying = false;
            secondPlaying = true;
            trackLength = sound2.clip.length;
            Debug.Log("LENGTH = " + sound2.clip.length);
        }
        else if (secondPlaying && trackLength <= 0)
        {
            pointerFW1.SetActive(false);
            pointerLeftFW.SetActive(true);

            sound3.Play();
            secondPlaying = false;
            thirdPlaying = true;
            trackLength = sound3.clip.length;
            Debug.Log("LENGTH = " + sound3.clip.length);
        }
        else if (thirdPlaying && trackLength <= 0)
        {
            pointerLeftFW.SetActive(false);
            
            // enable bear.fw
            bear.GetComponent<Collider2D>().enabled = true;
        }

        trackLength -= Time.deltaTime;
        Debug.Log(trackLength);
    }
}
