using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generateAnimalShadowsScript : MonoBehaviour
{
    private GameObject animal1;
    private GameObject animal2;
    private GameObject animal3;

    private GameObject animal1Shadow;
    private GameObject animal2Shadow;
    private GameObject animal3Shadow;

    private string[] animals = { "bear.fw", "boar.fw", "deer.fw", "fox.fw", "hedgehog.fw", "owl.fw", "squirrel.fw" };
    private float[] animalSizes = { 0.2256717f, 0.5291776f, 0.7277227f, 0.2454485f, 1f, 0.4649033f, 0.3867876f };
    private int totalAnimals = 7;

    private SpriteRenderer spriteRenderer;
    private string path = "";

    private int[] correctPositions = { 0, 1, 2 }; // animalul din stanga de pe pozitia i va match-ui umbra din dreapta de pe pozitia correctPositions[i]
    private GameObject[] correctShadows = new GameObject[3];



    private void shuffle<T>(System.Random rng, T[] array)
    {
        int n = array.Length;
        while (n > 1)
        {
            int k = rng.Next(n--);
            T temp = array[n];
            GameObject temp1 = correctShadows[n];

            array[n] = array[k];
            correctShadows[n] = correctShadows[k];

            array[k] = temp;
            correctShadows[k] = temp1;
        }
    }
    private void shuffleAnimalShadows()
    {
        var rng = new System.Random();
        shuffle(rng, correctPositions);
    }

    private void generateRandomAnimalsAndShadows()
    {
        // TODO:
        // left side is exactly unchanged
        // right side is shuffled => map it using correctPositions and correctShadows
        // right side are shadows
        // left side are random animals; right side are the exact animals but shuffled
        // left side animals are resized according animalSizes and 0,1,2 order
        // right side shadows are resized according animalSizes[correctPositions[0,1,2]] (MAYBE I AM WRONG...)

        shuffleAnimalShadows();
        Debug.Log(correctPositions[0]);
        Debug.Log(correctPositions[1]);
        Debug.Log(correctPositions[2]);


        System.Random rnd = new System.Random();
        
        int randint1 = rnd.Next(0, totalAnimals);
        int randint2 = rnd.Next(0, totalAnimals);
        int randint3 = rnd.Next(0, totalAnimals);

        Debug.Log(randint1);
        Debug.Log(randint2);
        Debug.Log(randint3);

        string animalName1 = animals[randint1];
        string animalName2 = animals[randint2];
        string animalName3 = animals[randint3];

        string pathToNewSprite1 = path + animalName1;
        string pathToNewSprite2 = path + animalName2;
        string pathToNewSprite3 = path + animalName3;
        Sprite newSprite1 = Resources.Load<Sprite>(pathToNewSprite1);
        Sprite newSprite2 = Resources.Load<Sprite>(pathToNewSprite2);
        Sprite newSprite3 = Resources.Load<Sprite>(pathToNewSprite3);

        spriteRenderer = animal1.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = newSprite1;
        spriteRenderer = animal2.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = newSprite2;
        spriteRenderer = animal3.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = newSprite3;

        animal1Shadow.GetComponent<Renderer>().material.color = new Color(0, 0, 0);
        animal2Shadow.GetComponent<Renderer>().material.color = new Color(0, 0, 0);
        animal3Shadow.GetComponent<Renderer>().material.color = new Color(0, 0, 0);

        spriteRenderer = correctShadows[correctPositions[0]].GetComponent<SpriteRenderer>(); // TODO: bugs...
        spriteRenderer.sprite = newSprite1;
        spriteRenderer = correctShadows[correctPositions[1]].GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = newSprite2;
        spriteRenderer = correctShadows[correctPositions[2]].GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = newSprite3;

        float animalSize1 = animalSizes[randint1];
        float animalSize2 = animalSizes[randint2];
        float animalSize3 = animalSizes[randint3];
        animal1.transform.localScale = new Vector3(animalSize1, animalSize1, animalSize1);
        animal2.transform.localScale = new Vector3(animalSize2, animalSize2, animalSize2);
        animal3.transform.localScale = new Vector3(animalSize3, animalSize3, animalSize3);



        correctShadows[correctPositions[0]].transform.localScale = new Vector3(animalSize1, animalSize1, animalSize1); // TODO: i think i messed up..
        correctShadows[correctPositions[1]].transform.localScale = new Vector3(animalSize2, animalSize2, animalSize2);
        correctShadows[correctPositions[2]].transform.localScale = new Vector3(animalSize3, animalSize3, animalSize3);
    }



    // Start is called before the first frame update
    void Start()
    {
        animal1 = GameObject.Find("animal1");
        animal2 = GameObject.Find("animal2");
        animal3 = GameObject.Find("animal3");

        animal1Shadow = GameObject.Find("animal1Shadow");
        animal2Shadow = GameObject.Find("animal2Shadow");
        animal3Shadow = GameObject.Find("animal3Shadow");


        correctShadows[0] = animal1Shadow;
        correctShadows[1] = animal2Shadow;
        correctShadows[2] = animal3Shadow;

        generateRandomAnimalsAndShadows();
        Debug.Log("DONE");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
