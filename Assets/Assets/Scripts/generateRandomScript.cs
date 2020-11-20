using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class generateRandomScript : MonoBehaviour
{
    private GameObject animal1;
    private GameObject animal2;
    private GameObject animal3;

    private GameObject oneFW;
    private GameObject twoFW;
    private GameObject threeFW;


    private string[] animals = { "bear.fw", "boar.fw", "deer.fw", "fox.fw", "hedgehog.fw", "owl.fw", "squirrel.fw" };
    private float[] animalSizes = { 0.2256717f, 0.5291776f, 0.7277227f, 0.2454485f, 1f, 0.4649033f, 0.3867876f };
    private int totalAnimals = 7;
    //private GameplayManager gameplayManager = GameObject.FindObjectOfType<GameplayManager>();
    // https://www.youtube.com/watch?v=ck6OyNBC95c
    public static int correctNumber;

    private SpriteRenderer spriteRenderer;
    private string path = "";



    public static bool checkAnswer(int answer)
    {
        return answer == correctNumber;
    }




    private int generateRandInt(int min, int max)
    {
        System.Random rnd = new System.Random();
        return rnd.Next(min, max);
    }

    private void handleShowCorrectNumberOfAnimals()
    {
        if (correctNumber == 1)
        {
            animal2.SetActive(false);
            animal3.SetActive(false);
        }
        else if (correctNumber == 2)
        {
            animal3.SetActive(false);
        }
    }

    private void generateRandomAnimals()
    {
        int randint = generateRandInt(0, totalAnimals);
        string animalName = animals[randint];
        float animalSize = animalSizes[randint];
        string pathToNewSprite = path + animalName;


        Debug.Log(pathToNewSprite);
        Sprite newSprite = Resources.Load<Sprite>(pathToNewSprite);
        Debug.Log(newSprite);
        spriteRenderer = animal1.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = newSprite;
        spriteRenderer = animal2.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = newSprite;
        spriteRenderer = animal3.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = newSprite;

        animal1.transform.localScale = new Vector3(animalSize, animalSize, animalSize);
        animal2.transform.localScale = new Vector3(animalSize, animalSize, animalSize);
        animal3.transform.localScale = new Vector3(animalSize, animalSize, animalSize);
    }

    // Start is called before the first frame update
    void Start()
    {
        correctNumber = generateRandInt(1,4);

        animal1 = GameObject.Find("animal1");
        animal2 = GameObject.Find("animal2");
        animal3 = GameObject.Find("animal3");

        oneFW = GameObject.Find("one.fw");
        twoFW = GameObject.Find("two.fw");
        threeFW = GameObject.Find("three.fw");

        handleShowCorrectNumberOfAnimals();
        generateRandomAnimals();

        Debug.Log("DONE");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
