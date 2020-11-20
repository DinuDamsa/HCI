using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class genereazaGhicitoareScript : MonoBehaviour
{
    private class Ghicitoare
    {
        public Ghicitoare(int correctAnimal, string animalSpritePath, float animalSize, string soundPath)
        {
            this.correctAnimal = correctAnimal;
            this.animalSpritePath = animalSpritePath;
            this.animalSize = animalSize;
            this.soundPath = soundPath;
            this.correctAnimal = correctAnimal;
        }

        public int correctAnimal;
        public string animalSpritePath;
        public float animalSize;
        public string soundPath;
    }

    private GameObject animal1;
    private GameObject animal2;
    private GameObject animal3;

    private GameObject speaker;

    private Ghicitoare[] ghicitori = {
        new Ghicitoare(0, "bear.fw", 0.2256717f, "wednesday"),
        new Ghicitoare(1, "boar.fw", 0.5291776f, "wednesday"),
        new Ghicitoare(2, "deer.fw", 0.7277227f, "wednesday"),
        new Ghicitoare(3, "fox.fw", 0.2454485f, "wednesday"),
        new Ghicitoare(4, "hedgehog.fw", 1f, "wednesday"),
        new Ghicitoare(5, "owl.fw", 0.4649033f, "wednesday"),
        new Ghicitoare(6, "squirrel.fw", 0.3867876f, "wednesday")
    };


    private List<string> animals = new List<string>(new string[] { "bear.fw", "boar.fw", "deer.fw", "fox.fw", "hedgehog.fw", "owl.fw", "squirrel.fw" });
    private List<float> animalSizes = new List<float>(new float[] { 0.2256717f, 0.5291776f, 0.7277227f, 0.2454485f, 1f, 0.4649033f, 0.3867876f });
    private int totalAnimals = 7;

    private static int correctNumber;
    private GameObject[] animalsObjects = new GameObject[3];


    public static bool checkAnswer(int answer)
    {
        return answer == correctNumber;
    }


    private int generateRandInt(int min, int max)
    {
        System.Random rnd = new System.Random();
        return rnd.Next(min, max);
    }


    private void setupRandomAnimal(GameObject animal)
    {
        int randIndex = generateRandInt(0, totalAnimals);
        animal.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(animals[randIndex]);
        float size = animalSizes[randIndex];
        animal.transform.localScale = new Vector3(size, size, size);

        // removed used animals
        animals.RemoveAt(randIndex);
        animalSizes.RemoveAt(randIndex);
        totalAnimals -= 1;
    }


    private void generateGhicitoareSiAnimale()
    {
        // am ales ghicitoarea
        int randint = generateRandInt(0, totalAnimals); // total ghicitori = total animale
        Ghicitoare ghicitoare = ghicitori[randint];

        // alegem obiectul din joc care va fi cel corect
        int randindex = generateRandInt(0, 3); // 3 animale pe ecran

        // setam animalului din joc detaliile corecte
        animalsObjects[randindex].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(ghicitoare.animalSpritePath);
        float size = ghicitoare.animalSize;
        animalsObjects[randindex].transform.localScale = new Vector3(size, size, size);

        // setam sunetul pe speaker, pentru a putea fi repetat on demand
        AudioSource audio = speaker.GetComponent<AudioSource>(); //Assets / Resources / wednesday.mp3
        audio.clip = Resources.Load<AudioClip>(ghicitoare.soundPath);
        Debug.Log(ghicitoare.soundPath);
        audio.Play();

        correctNumber = ghicitoare.correctAnimal;

        // scoatem din lista de animale animalul corect (INTERZIS duplicate)
        animals.RemoveAt(correctNumber);
        animalSizes.RemoveAt(correctNumber);
        totalAnimals -= 1;

        // setam restul animalelor gresite random
        setupRandomAnimal(animalsObjects[(randindex + 1) % 3]);
        setupRandomAnimal(animalsObjects[(randindex + 2) % 3]);


        // LA FINAL, (PUTEM FOLOSI DOAR INDEXUL SA IL TRANSMITEM DIN INTERFATA - nu stiu altfel mai simplu) POZITIA ANIMALULUI CORECT ESTE RASPUNSUL.
        correctNumber = randindex + 1;
    }


    // Start is called before the first frame update
    void Start()
    {
        animal1 = GameObject.Find("animal1");
        animal2 = GameObject.Find("animal2");
        animal3 = GameObject.Find("animal3");

        speaker = GameObject.Find("speaker");

        // adaugam in lista de animale toate obiectele din joc pentru a le procesa
        animalsObjects[0] = animal1;
        animalsObjects[1] = animal2;
        animalsObjects[2] = animal3;

        generateGhicitoareSiAnimale();
        Debug.Log("DONE");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
