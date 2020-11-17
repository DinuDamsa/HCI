using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generateSoundsAndAnimalScript : MonoBehaviour
{

    private GameObject animal;

    private GameObject speaker1;
    private GameObject speaker2;
    private GameObject speaker3;

    private string[] animals = { "bear.fw", "boar.fw", "deer.fw", "fox.fw", "hedgehog.fw", "owl.fw", "squirrel.fw" };
    private float[] animalSizes = { 0.2256717f, 0.5291776f, 0.7277227f, 0.2454485f, 1f, 0.4649033f, 0.3867876f };
    private int totalAnimals = 7;

    public int correctNumber;

    private string path = "";




    private int generateRandInt(int min, int max)
    {
        System.Random rnd = new System.Random();
        return rnd.Next(min, max);
    }

    // Start is called before the first frame update
    void Start()
    {
        animal = GameObject.Find("animal");

        speaker1 = GameObject.Find("speaker1");
        speaker2 = GameObject.Find("speaker2");
        speaker3 = GameObject.Find("speaker3");

        int randint = generateRandInt(0, totalAnimals);

        string animalName = animals[randint];
        string pathToNewSound = path + animalName;
        AudioSource newAudio = Resources.Load<AudioSource>(pathToNewSound);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
