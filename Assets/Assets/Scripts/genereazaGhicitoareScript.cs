using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class genereazaGhicitoareScript : MonoBehaviour
{
    private GameObject animal1;
    private GameObject animal2;
    private GameObject animal3;

    private string[] animals = { "bear.fw", "boar.fw", "deer.fw", "fox.fw", "hedgehog.fw", "owl.fw", "squirrel.fw" };
    private float[] animalSizes = { 0.2256717f, 0.5291776f, 0.7277227f, 0.2454485f, 1f, 0.4649033f, 0.3867876f };
    private int totalAnimals = 7; // TODO: aici trebuie sa avem si o lista de ghicitori (animalele sunt raspunsul ghicitorii)

    public int correctAnimal; // TODO: asta este raspunsul ghicitorii

    private SpriteRenderer spriteRenderer;
    private string path = "";

    private int generateRandInt(int min, int max)
    {
        System.Random rnd = new System.Random();
        return rnd.Next(min, max);
    }



    private void generateGhicitoareSiAnimale()
    {
        var renderer = animal1.GetComponent<SpriteRenderer>();


        int randint = generateRandInt(0, totalAnimals);
        string animalName = animals[randint];
        float animalSize = animalSizes[randint];
        string pathToNewSprite = path + animalName;


        //TODO: trebuie sa alegem ghicitoarea
        // Ghicitoare ghicitoare = ghicitori[randint];
        // string numeAnimalRaspunsCorect = ghicitoare.numeAnimalRaspunsCorect;
        // string spriteAnimalRaspunsCorect = ghicitoare.spriteAnimalRaspunsCorect;
        // AudioSource ghicitoareAudio = ghicitoare.audio;
        // ghicitoareAudio.Start();


        Debug.Log(pathToNewSprite);
        Sprite newSprite = Resources.Load<Sprite>(pathToNewSprite); // aici vom genera 2/3 animale random si vom adauga pe cel raspuns al ghicitorii
        // shuffled = shuffle([animal1, animal2, animal3])
        // shuffled[0].sprite = spriteAnimalRaspunsCorect
        // shuffled[0].value = numeAnimalRaspunsCorect
        // shuffled[1,2].sprite = randomSprite
        // shuffled[1,2].value = whateverElse
        
        

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
        animal1 = GameObject.Find("animal1");
        animal2 = GameObject.Find("animal2");
        animal3 = GameObject.Find("animal3");

        generateGhicitoareSiAnimale();
        Debug.Log("DONE");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
