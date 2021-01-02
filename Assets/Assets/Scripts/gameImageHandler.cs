using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameImageHandler : MonoBehaviour
{
    // Start is called before the first frame update

    public Sprite[] imagesGood;
    public Sprite[] imagesBad;
    public int spriteRendererID;
    public bool isGoodImage;
    private AudioSource audioSource;
    public GameObject audioSourceGameObject;
    public AudioClip rightClip;
    public AudioClip wrongClip;
    public string scenename;

    void Start()
    {
        UpdateImage();
        

    }

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }


    IEnumerator Waiter()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(scenename);
    }

    public void OnMouseUp()
    {
        Debug.Log(audioSource);
        if(isGoodImage)
        {
            Debug.Log("CORECT");
            audioSource.clip = Resources.Load<AudioClip>("wednesday"); ;
            audioSource.Play();
            StartCoroutine(Waiter());
        }
        else
        {
            Debug.Log("INCORECT");
            audioSource.clip = Resources.Load<AudioClip>("wednesday");
            audioSource.Play();
        }
    }

    public void UpdateImage()
    {
        System.Random rnd = new System.Random();
        int num = rnd.Next(imagesGood.Length);
        int num2 = rnd.Next(2);
        Debug.Log(num);
        Debug.Log(num2);
        if(num2 % 2 == 0)
        {
            if(spriteRendererID == 1)
            {
                GetComponent<SpriteRenderer>().sprite = imagesGood[num];
                isGoodImage = true;
            }
                
            else
            {
                GetComponent<SpriteRenderer>().sprite = imagesBad[num];
                isGoodImage = false;
            }
                
        }
        else
        {
            if (spriteRendererID == 2)
            {
                GetComponent<SpriteRenderer>().sprite = imagesGood[num];
                isGoodImage = true;
            }
                
            else
            {
                GetComponent<SpriteRenderer>().sprite = imagesBad[num];
                isGoodImage = false;
            }
                
        }
    }

}
