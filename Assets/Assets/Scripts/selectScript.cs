using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectScript : MonoBehaviour
{
    public int selectedValue;

    private AudioSource audioSource;
    public GameObject audioSourceGameObject;
    public AudioClip rightClip;
    public AudioClip wrongClip;
    public GameObject otherNumber1;
    public GameObject otherNumber2;

    public void OnMouseUp()
    {
        Debug.Log(selectedValue);
        if (generateRandomScript.checkAnswer(selectedValue))
        {
            // felicitari
            Debug.Log("FELICITARI!");
            audioSource.clip = rightClip;
            audioSource.Play();
            otherNumber1.SetActive(false);
            otherNumber2.SetActive(false);
            //audioSource.PlayOneShot(rightClip, 1f);
        }
        else
        {
            // oof
            Debug.Log("OOF!"); 
            audioSource.clip = wrongClip;
            audioSource.Play();
            //audioSource.PlayOneShot(wrongClip, 1f);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = audioSourceGameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
