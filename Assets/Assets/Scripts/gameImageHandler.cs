using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameImageHandler : MonoBehaviour
{
    // Start is called before the first frame update

    AudioSource audioSource;
    public string scenename;
    public Sprite[] imagesGood;
    public Sprite[] imagesBad;
    static int correctNumber;

    GameObject spriteRendererA;
    GameObject spriteRendererB;


    public static bool checkAnswer(int answer)
    {
        return answer == correctNumber;
    }


    void Start()
    {
        spriteRendererA = GameObject.Find("spriteRendererA");
        spriteRendererB = GameObject.Find("spriteRendererB");


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

    public void UpdateImage()
    {
        System.Random rnd = new System.Random();
        int num = rnd.Next(imagesGood.Length);
        int num2 = rnd.Next(2);
        Debug.Log(num);
        Debug.Log(num2);
        if (num2 % 2 == 0)
        {
            spriteRendererA.GetComponent<SpriteRenderer>().sprite = imagesGood[num];
            correctNumber = 0;
            spriteRendererB.GetComponent<SpriteRenderer>().sprite = imagesBad[num];
        }
        else
        {
            spriteRendererB.GetComponent<SpriteRenderer>().sprite = imagesGood[num];
            correctNumber = 1;
            spriteRendererA.GetComponent<SpriteRenderer>().sprite = imagesBad[num];
        }
    }

}
