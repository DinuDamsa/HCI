using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generateSoundsAndAnimalScript : MonoBehaviour
{

    private GameObject animal;

    private GameObject speaker1;
    private GameObject speaker2;
    private GameObject speaker3;

    private List<string> animals = new List<string>(new string[] { "bear.fw", "boar.fw", "deer.fw", "fox.fw", "hedgehog.fw", "owl.fw", "squirrel.fw" });
    private List<string> animalSounds = new List<string>(new string[] { "wednesday", "wednesday", "wednesday", "wednesday", "wednesday", "wednesday", "wednesday" });
    private List<float> animalSizes = new List<float>(new float[] { 0.2256717f, 0.5291776f, 0.7277227f, 0.2454485f, 1f, 0.4649033f, 0.3867876f });
    private int totalAnimals = 7;

    private int correctAnswer;
    private GameObject[] speakerObjects = new GameObject[3];




    private int generateRandInt(int min, int max)
    {
        System.Random rnd = new System.Random();
        return rnd.Next(min, max);
    }


    private void setupRandomAnimalSound(GameObject speaker)
    {
        int randIndex = generateRandInt(0, totalAnimals);

        AudioSource audio = speaker.GetComponent<AudioSource>();
        audio.clip = Resources.Load<AudioClip>(animalSounds[randIndex]);

        // removed used animals
        animals.RemoveAt(randIndex);
        animalSizes.RemoveAt(randIndex);
        totalAnimals -= 1;
    }


    private void generateRandomSound()
    {
        // choose which speaker is the good one
        int randSpeaker = generateRandInt(0, 3); // 3 speakere

        // choose an animal to listen to their sound
        int randindex = generateRandInt(0, 7); // 7 animale

        // assign the correct information to the animal
        animal.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(animals[randindex]);
        float size = animalSizes[randindex];
        animal.transform.localScale = new Vector3(size, size, size);

        // assign the correct information to the good speaker
        AudioSource audio = speakerObjects[randSpeaker].GetComponent<AudioSource>(); //Assets / Resources / wednesday.mp3
        audio.clip = Resources.Load<AudioClip>(animalSounds[randindex]);
        
        correctAnswer = randindex;

        // eliminam animalul corect (interzis duplicate)
        animals.RemoveAt(correctAnswer);
        animalSizes.RemoveAt(correctAnswer);
        totalAnimals -= 1;

        // restul sunetelor animalelor sunt random
        setupRandomAnimalSound(speakerObjects[(randSpeaker + 1) % 3]);
        setupRandomAnimalSound(speakerObjects[(randSpeaker + 2) % 3]);

    }

    // Start is called before the first frame update
    void Start()
    {
        animal = GameObject.Find("animal");

        speaker1 = GameObject.Find("speaker1");
        speaker2 = GameObject.Find("speaker2");
        speaker3 = GameObject.Find("speaker3");

        speakerObjects[0] = speaker1;
        speakerObjects[1] = speaker2;
        speakerObjects[2] = speaker3;


        generateRandomSound();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
