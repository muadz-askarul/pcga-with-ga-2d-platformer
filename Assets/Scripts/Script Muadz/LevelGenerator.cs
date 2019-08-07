using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public PlayerScript player;

    float GenerateTime;
    bool showed=false;

    public int NumberOfLevel;
    public GA_Script gA;

    public GameObject GPrefeb;
    public GameObject GSPrefeb;
    public GameObject GWPrefeb;
    public GameObject G2WPrefeb;
    public GameObject G3WPrefeb;
    public GameObject GWSPrefeb;
    public GameObject G2WSPrefeb;

    Vector3 distanceEachGen;

    bool generateDone = true;

    Vector3 lastGenPosition;

    int levelCount = 0;

    // jumlah jurang
    int jumlahJurang = 0;

    // didapatkan dari GA
    List<Individu> Population = new List<Individu>();

    // menyimpan level yang sudah di terjemahkan dari populasi GA
    public GameObject Levels;

    public Dictionary<string, GameObject> TranslateToLevel = new Dictionary<string, GameObject>();

    void Awake()
    {
        GenerateTime = 0;
        TranslateToLevel = new Dictionary<string, GameObject>()
        {
            { Gen.genes[1], GPrefeb },
            { Gen.genes[2], GSPrefeb },
            { Gen.genes[3], GWPrefeb },
            { Gen.genes[4], G2WPrefeb },
            { Gen.genes[5], G3WPrefeb },
            { Gen.genes[6], GWSPrefeb },
            { Gen.genes[7], G2WSPrefeb }
        };

        distanceEachGen = new Vector3((float)GPrefeb.GetComponent<Renderer>().bounds.size.x, 0, 0);
    }

    // Use this for initialization
    void Start()
    {
        GenerateLevel();
        gA.Printing(Population);
    }

    // Update is called once per frame
    void Update()
    {
        //if(!showed)
        //    GenerateTime += Time.deltaTime;

        // tambahkan kondisi dimana harus generate level baru
        if (Levels.transform.childCount < NumberOfLevel && generateDone)
        {
            GenerateLevel();
        }
        //else if (Levels.transform.childCount == NumberOfLevel && generateDone) {
        //    if (!showed) {
        //        Debug.Log("Generate Time : " + GenerateTime);
        //        showed = true;
        //    }

        //}
    }

    public void GenerateLevel()
    {
        generateDone = false;

        GameObject gO = new GameObject();
        gO.gameObject.name = "Level_" + levelCount;

        // dapatkan populasi dari ga
        Population = gA.GeneticAlgorithm();
        
        // terjemahkan dari string ke gameobject dan masukkan dalam parent
        for (int i = 0; i < Population.Count; i++)
        {
            GameObject obj = LevelMaker(Population[i], i);
            obj.transform.SetParent(gO.transform);
            obj.transform.localPosition = distanceEachGen * i * 10;
            lastGenPosition = obj.transform.TransformPoint(obj.transform.position);
        }
        gO.transform.SetParent(Levels.transform);

        gO.transform.localPosition = distanceEachGen * levelCount * 100;

        levelCount++;

        generateDone = true;
        
    }

    public GameObject LevelMaker(Individu individu, int index)
    {
        GameObject Individu = new GameObject();

        Individu.gameObject.name = "Individu_" + index;

        

        for (int i = 0; i < individu.kromosomLength; i++)
        {

            if (individu.kromosom[i] == Gen.genes[0])
            {
                jumlahJurang++;
                continue;

            }

            // buat gameobject
            GameObject obj = GameObject.Instantiate(TranslateToLevel[individu.kromosom[i]]);

            // tentukan posisi
            obj.transform.position = (distanceEachGen * i) + (distanceEachGen * jumlahJurang * 2f);

            // rename gameobject
            obj.gameObject.name = "gen_" + i;

            // tentukan parent
            obj.transform.SetParent(Individu.transform);

        }

        return Individu;
    }

}
