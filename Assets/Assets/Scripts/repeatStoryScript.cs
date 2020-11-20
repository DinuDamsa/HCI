using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repeatStoryScript : MonoBehaviour
{
    AudioSource story;

    public void OnMouseUp()
    {
        story.Play();
    }

    // Start is called before the first frame update
    void Start()
    {
        story = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
