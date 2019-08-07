using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GA_Script : MonoBehaviour
{

    public int PopulationNumber = 10;

    bool FinishGenerating;
    //bool ShouldInitPopulation;

    [Range(0.0f, 1.0f)]
    public float MutationRate;

    List<Individu> population = new List<Individu>();

    int Generation = 0;

    public Text T,T2;
    

    // Update is called once per frame
    void Update()
    {

    }

    public List<Individu> GeneticAlgorithm()
    {
        int iteration = 0;
        
        while (!FinishGenerating)
        {
            if (population == null)
            {
                population = new List<Individu>();
                population = InitPopulation(PopulationNumber);
            }

            if (population.Count <= 0)
            {
                population.Clear();
                population = InitPopulation(PopulationNumber);
            }

            // menghitung nilai fitness dari populasi
            CalculatePopulationFitness(population);

            // Natural Selection
            population = Selection(population);

            population = NewGeneration(population);
            if(population != null)
            {
                if (population.Count == PopulationNumber)
                {
                    FinishGenerating = true;
                }
            }
            iteration++;
        }
        Generation = iteration;
        //Debug.Log("Total generation : " + iteration);
        return population;
    }

    // Inisialisasi Populasi
    List<Individu> InitPopulation(int populationSize)
    {
        List<Individu> pops = new List<Individu>();

        for (int i = 0; i < populationSize; i++)
        {
            Individu ind = new Individu();
            pops.Add(ind);
        }
        return pops;
    }

    // seleksi 
    List<Individu> Selection(List<Individu> pop)
    {
        List<Individu> selectedIndividu = new List<Individu>();

        // cek nilai fitness
        foreach (var p in pop)
        {
            if (p.fitness > 4)
            {
                selectedIndividu.Add(p);
            }
        }

        return selectedIndividu;
    }

    // Reprodiuksi populasi
    List<Individu> NewGeneration(List<Individu> pop)
    {
        if (population.Count <= 0)
        {
            return null;
        }
        
        List<Individu> newPopulation = pop;

        int n = PopulationNumber - pop.Count;

        for (int i = 0; i < n; i++)
        {
            // get parent1 and parent2
            Individu[] parent = ChooseParent();

            //child = hasil crossover
            Individu child = new Individu();
            child = CrossOver(parent[0], parent[1]);

            //mutate(mutationrate)
            child = Mutation(child, MutationRate);

            //add to new population
            newPopulation.Add(child);
        }
        CalculatePopulationFitness(newPopulation);
        newPopulation = Selection(newPopulation);
        Printing(newPopulation);
        return newPopulation;
        //return child;

    }

    Individu[] ChooseParent()
    {
        Individu[] res = new Individu[2];

        res[0] = RouletteWheelSelection();
        res[1] = RouletteWheelSelection();

        return res;
    }

    Individu RouletteWheelSelection()
    {
        Individu res = new Individu();
        int totalSum = 0;

        for (int i = 0; i < population.Count; i++)
        {
            totalSum += population[i].fitness;
        }

        int rand = Random.Range(0, totalSum);
        int partialSum = 0;

        for (int i = 0; i < population.Count; i++)
        {
            partialSum += population[i].fitness;
            if (partialSum >= rand)
            {
                return population[i];
            }
        }
        return res;
    }

    Individu CrossOver(Individu A, Individu B)
    {
        Individu child = new Individu();

        for (int i = 0; i < A.kromosomLength; i++)
        {
            child.kromosom[i] = Random.Range(0.0f, 1.0f) < 0.5f ? A.kromosom[i] : B.kromosom[i];
        }
        return child;
    }

    Individu Mutation(Individu A, float mutationRate)
    {

        Individu res = A;
        for (int i = 0; i < res.kromosomLength; i++)
        {
            if (Random.Range(0.0f, 1.0f) < mutationRate)
            {
                res.kromosom[i] = Gen.genes[Random.Range(0, 8)];
            }
        }

        return res;
    }

    void CalculatePopulationFitness(List<Individu> pop)
    {

        int n = pop.Count;

        for (int j = 0; j < n; j++)
        {
            pop[j].CalculateFitness();
        }

    }

    // debugging
    public void Printing(List<Individu> pop)
    {
        string str = "";
        int n = pop.Count;
        string kromosomAgen = "";

        for (int j = 0; j < n; j++)
        {
            for (int i = 0; i < pop[0].kromosomLength; i++)
            {
                kromosomAgen += pop[j].kromosom[i] + "  ->  ";
            }

            //str += "individu " + j + "\n" + kromosomAgen + "\n" + pop[j].fitness + "\n";
            Debug.Log("individu " + j + "\n" + kromosomAgen + "\n" + pop[j].fitness + "\n");
            kromosomAgen = "";
        }
        
        T.text = str;
        T2.text = "Total Generations \n" + Generation;
    }

}
