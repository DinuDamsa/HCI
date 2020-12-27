using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class selectCuloareScript : MonoBehaviour
{
    public int selectedValue;

    private AudioSource audioSource;
    public GameObject audioSourceGameObject;
    public AudioClip rightClip;
    public AudioClip wrongClip;
    public GameObject otherAnimal1;
    public GameObject otherAnimal2;

    public void OnMouseUp()
    {
        Debug.Log(selectedValue);

        if (genereazaAnimaleColorateScript.checkAnswer(selectedValue))
        {
            // felicitari
            Debug.Log("FELICITARI!");
            audioSource.clip = rightClip;
            audioSource.Play();
            otherAnimal1.SetActive(false);
            otherAnimal2.SetActive(false);
            StartCoroutine(Waiter());
        }
        else
        {
            // oof
            Debug.Log("OOF!");
            audioSource.clip = wrongClip;
            audioSource.Play();
        }
    }

    IEnumerator Waiter()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
