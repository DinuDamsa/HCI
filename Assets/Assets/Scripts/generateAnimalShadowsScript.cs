using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class generateAnimalShadowsScript : MonoBehaviour
{
    private GameObject animal1;
    private GameObject animal2;
    private GameObject animal3;

    private GameObject animal1Shadow;
    private GameObject animal2Shadow;
    private GameObject animal3Shadow;
     
    private string[] animals = { "bear.fw", "boar.fw", "deer.fw", "fox.fw", "hedgehog.fw", "owl.fw", "squirrel.fw" };
    private float[] animalSizes = { 0.2056717f, 0.35f, 0.68f, 0.1554485f, 0.53f, 0.3f, 0.2567876f };
    private int totalAnimals = 7;

    private SpriteRenderer spriteRenderer;
    private string path = ""; 

    private int[] correctPositions = { 0, 1, 2 }; // animalul din stanga de pe pozitia i va match-ui umbra din dreapta de pe pozitia correctPositions[i]
    private GameObject[] correctShadows = new GameObject[3];
    private GameObject[] correctAnimals = new GameObject[3];

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
        Debug.Log("c:" + correctPositions[0]);
        Debug.Log("c:" + correctPositions[1]);
        Debug.Log("c:" + correctPositions[2]);


        System.Random rnd = new System.Random();
        
        int randint1 = rnd.Next(0, totalAnimals);
        int randint2 = rnd.Next(0, totalAnimals);
        int randint3 = rnd.Next(0, totalAnimals);

        while (randint2 == randint1 || randint2 == randint3)
            randint2 = rnd.Next(0, totalAnimals);

        while (randint3 == randint1 || randint3 == randint2)
            randint3 = rnd.Next(0, totalAnimals);

        Debug.Log("p:" + randint1);
        Debug.Log("p:" + randint2);
        Debug.Log("p:" + randint3);

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
        var size1 = animal1.GetComponent<Renderer>().bounds.size;
        var size2 = animal2.GetComponent<Renderer>().bounds.size;
        var size3 = animal3.GetComponent<Renderer>().bounds.size;
        var center1 = animal1.GetComponent<Renderer>().bounds.center;
        var center2 = animal2.GetComponent<Renderer>().bounds.center;
        var center3 = animal3.GetComponent<Renderer>().bounds.center;

        //BoxCollider2D boxCollider2D1 = animal1.AddComponent<BoxCollider2D>();
        //boxCollider2D1.size = size1 / animalSize1;
        //boxCollider2D1.offset = center1;

        //BoxCollider2D boxCollider2D2 = animal1.AddComponent<BoxCollider2D>();
        //boxCollider2D2.size = size2 / animalSize2;
        //boxCollider2D2.offset = center2;

        //BoxCollider2D boxCollider2D3 = animal1.AddComponent<BoxCollider2D>();
        //boxCollider2D3.size = size3 / animalSize3;
        //boxCollider2D3.offset = center3;

        //BoxCollider2D boxColldier2D11 = correctShadows[correctPositions[0]].AddComponent<BoxCollider2D>();
        //boxCollider2D11.size = size;
        //boxCollider2D11.center = center;

        //BoxCollider2D boxColldier2D22 = correctShadows[correctPositions[1]].AddComponent<BoxCollider2D>();
        //boxCollider2D22.size = size;
        //boxCollider2D22.center = center;

        //BoxCollider2D boxColldier2D33 = correctShadows[correctPositions[2]].AddComponent<BoxCollider2D>();
        //boxCollider2D33.size = size;
        //boxCollider2D33.center = center;

        correctAnimals[0] = animal1;
        correctAnimals[1] = animal2;
        correctAnimals[2] = animal3;
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
        checkMatch();
    }

    void checkMatch()
    {
        var firstSelected = matchesScript.firstSelected;
        var lastSelected = matchesScript.lastSelected;
        if (firstSelected != -1 && lastSelected != -1)
        {
            //Debug.Log(correctPositions[0]);
            //Debug.Log(correctPositions[1]);
            //Debug.Log(correctPositions[2]);
            Debug.Log(firstSelected);
            Debug.Log(lastSelected);
            //Debug.Log(correctPositions[firstSelected]); 
            //Debug.Log((lastSelected - 3)); 
            Debug.Log(correctAnimals[firstSelected].name);
            Debug.Log(correctShadows[lastSelected - 3].name);
            if (correctShadows[lastSelected - 3].name.Contains(correctAnimals[firstSelected].name))
            {
                Debug.Log("Bravo");
            }
            else
            {
                Debug.Log("Ai gresit");
            }
            matchesScript.firstSelected = -1;
            matchesScript.lastSelected = -1;
        }
    }

}
