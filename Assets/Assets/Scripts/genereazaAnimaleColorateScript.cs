using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class genereazaAnimaleColorateScript : MonoBehaviour
{
    private GameObject animal1;
    private GameObject animal2;
    private GameObject animal3;

    private string[] animals = { "bear.fw", "fox.fw", "hedgehog.fw",  "squirrel.fw" };
    private float[] animalSizes = { 0.2256717f, 0.2454485f, 0.7f, 0.3867876f };
    private int totalAnimals = 4;

    public static int correctNumber; // TODO: asta e animalul corect colorat de pe ecran

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


    private void generateRandomColouredAnimals()
    {
        int randint = generateRandInt(0, totalAnimals);

        // TODO: CULORITE TREBUIE NEAPARAT SA FIE EVIDENTA (exista sansa sa fie 255,255,255 - alb => nicio diferenta intre real si fake...)
        Color colorFake1 = new Color(Random.Range(0F, 1F), Random.Range(0, 1F), Random.Range(0, 1F));
        Color colorFake2 = new Color(Random.Range(0F, 1F), Random.Range(0, 1F), Random.Range(0, 1F));

        string animalName = animals[randint];
        string pathToNewSprite = path + animalName;
        Sprite newSprite = Resources.Load<Sprite>(pathToNewSprite);

        if (correctNumber == 1)
        {
            animal2.GetComponent<Renderer>().material.color = colorFake1;
            animal3.GetComponent<Renderer>().material.color = colorFake2;
        }
        else if (correctNumber == 2)
        {
            animal1.GetComponent<Renderer>().material.color = colorFake1;
            animal3.GetComponent<Renderer>().material.color = colorFake2;
        }
        else
        {
            animal1.GetComponent<Renderer>().material.color = colorFake1;
            animal2.GetComponent<Renderer>().material.color = colorFake2;
        }


        Debug.Log(newSprite);
        spriteRenderer = animal1.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = newSprite;
        spriteRenderer = animal2.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = newSprite;
        spriteRenderer = animal3.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = newSprite;

        float animalSize = animalSizes[randint];
        animal1.transform.localScale = new Vector3(animalSize, animalSize, animalSize);
        animal2.transform.localScale = new Vector3(animalSize, animalSize, animalSize);
        animal3.transform.localScale = new Vector3(animalSize, animalSize, animalSize);
    }




    // Start is called before the first frame update
    void Start()
    {
        correctNumber = generateRandInt(1, 4);

        animal1 = GameObject.Find("animal1");
        animal2 = GameObject.Find("animal2");
        animal3 = GameObject.Find("animal3");

        generateRandomColouredAnimals();
        Debug.Log("DONE");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
