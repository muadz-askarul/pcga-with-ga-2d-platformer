using UnityEngine;

public class Individu : MonoBehaviour
{

    public string[] kromosom = new string[10];

    public int fitness = 0;

    public int kromosomLength = 10;

    public Individu()
    {

        for (int i = 0; i < kromosomLength; i++)
        {
            int rand = Random.RandomRange(0, 100);

            if (rand <= 17)
            {
                kromosom[i] = Gen.genes[0];
            }
            else if (rand > 17 && rand <= 55)
            {
                kromosom[i] = Gen.genes[1];
            }
            else if (rand > 55 && rand <= 65)
            {
                kromosom[i] = Gen.genes[2];
            }
            else if (rand > 65 && rand <= 75)
            {
                kromosom[i] = Gen.genes[3];
            }
            else if (rand > 75 && rand <= 83)
            {
                kromosom[i] = Gen.genes[4];
            }
            else if (rand > 83 && rand <= 88)
            {
                kromosom[i] = Gen.genes[5];
            }
            else if (rand > 88 && rand <= 95)
            {
                kromosom[i] = Gen.genes[6];
            }
            else if (rand > 95 && rand <= 100)
            {
                kromosom[i] = Gen.genes[7];
            }

            // penentuan gen dari kromosom secara acak
            //kromosom[i] = Gen.genes[Random.Range(0, 8)];
        }

        fitness = 0;

    }

    // Fitness Function
    public void CalculateFitness()
    {
        fitness = 0;

        // penilaian berdasarkan value gen 
        for (int i = 0; i < kromosomLength; i++)
        {
            fitness += Gen.genValue[kromosom[i]];
        }

        // pengecekan susunan kromosom dan penalty fitness
        for (int j = 0; j < kromosomLength; j++)
        {
            if (j == 0)
            {
                if (!kromosom[j].Equals("G"))
                {
                    fitness -= 1000;
                    break;
                }
                if (kromosom[j].Equals("G") && kromosom[j + 1].Equals("G2WS"))
                {
                    fitness -= 1000;
                    break;
                }
                if (kromosom[j].Equals("G") && kromosom[j + 1].Equals("G3W"))
                {
                    fitness -= 1000;
                    break;
                }
                continue;
            }

            if (j != (kromosomLength - 1))
            {
                // 3 jurang berdampingan
                if (kromosom[j - 1].Equals("") && kromosom[j].Equals("") && kromosom[j + 1].Equals(""))
                {
                    fitness -= 1000;
                    break;
                }
                if (kromosom[j - 1].Equals("GS") && kromosom[j].Equals("GS") && kromosom[j + 1].Equals("GS"))
                {
                    fitness -= 1000;
                    break;
                }
                if (kromosom[j - 1].Equals("GS") && kromosom[j].Equals("GS") && kromosom[j + 1].Equals("GWS"))
                {
                    fitness -= 1000;
                    break;
                }
                if (kromosom[j - 1].Equals("GS") && kromosom[j].Equals("GS") && kromosom[j + 1].Equals("G2WS"))
                {
                    fitness -= 1000;
                    break;
                }
                if (kromosom[j - 1].Equals("GS") && kromosom[j].Equals("GWS") && kromosom[j + 1].Equals("GS"))
                {
                    fitness -= 1000;
                    break;
                }
                if (kromosom[j - 1].Equals("GS") && kromosom[j].Equals("GWS") && kromosom[j + 1].Equals("GWS"))
                {
                    fitness -= 1000;
                    break;
                }
                if (kromosom[j - 1].Equals("GS") && kromosom[j].Equals("GWS") && kromosom[j + 1].Equals("G2WS"))
                {
                    fitness -= 1000;
                    break;
                }
                if (kromosom[j - 1].Equals("GS") && kromosom[j].Equals("G2WS") && kromosom[j + 1].Equals("GS"))
                {
                    fitness -= 1000;
                    break;
                }
                if (kromosom[j - 1].Equals("GS") && kromosom[j].Equals("G2WS") && kromosom[j + 1].Equals("GWS"))
                {
                    fitness -= 1000;
                    break;
                }
                if (kromosom[j - 1].Equals("GS") && kromosom[j].Equals("G2WS") && kromosom[j + 1].Equals("G2WS"))
                {
                    fitness -= 1000;
                    break;
                }
                //
                if (kromosom[j - 1].Equals("GWS") && kromosom[j].Equals("GS") && kromosom[j + 1].Equals("GWS"))
                {
                    fitness -= 1000;
                    break;
                }
                if (kromosom[j - 1].Equals("GWS") && kromosom[j].Equals("GS") && kromosom[j + 1].Equals("G2WS"))
                {
                    fitness -= 1000;
                    break;
                }
                if (kromosom[j - 1].Equals("GWS") && kromosom[j].Equals("GWS") && kromosom[j + 1].Equals("GS"))
                {
                    fitness -= 1000;
                    break;
                }
                if (kromosom[j - 1].Equals("GWS") && kromosom[j].Equals("GWS") && kromosom[j + 1].Equals("GWS"))
                {
                    fitness -= 1000;
                    break;
                }
                if (kromosom[j - 1].Equals("GWS") && kromosom[j].Equals("GWS") && kromosom[j + 1].Equals("G2WS"))
                {
                    fitness -= 1000;
                    break;
                }
                if (kromosom[j - 1].Equals("GWS") && kromosom[j].Equals("G2WS") && kromosom[j + 1].Equals("GS"))
                {
                    fitness -= 1000;
                    break;
                }
                if (kromosom[j - 1].Equals("GWS") && kromosom[j].Equals("G2WS") && kromosom[j + 1].Equals("GWS"))
                {
                    fitness -= 1000;
                    break;
                }
                if (kromosom[j - 1].Equals("GWS") && kromosom[j].Equals("G2WS") && kromosom[j + 1].Equals("G2WS"))
                {
                    fitness -= 1000;
                    break;
                }
                //
                if (kromosom[j - 1].Equals("G2WS") && kromosom[j].Equals("GS") && kromosom[j + 1].Equals("GWS"))
                {
                    fitness -= 1000;
                    break;
                }
                if (kromosom[j - 1].Equals("G2WS") && kromosom[j].Equals("GS") && kromosom[j + 1].Equals("G2WS"))
                {
                    fitness -= 1000;
                    break;
                }
                if (kromosom[j - 1].Equals("G2WS") && kromosom[j].Equals("GWS") && kromosom[j + 1].Equals("GS"))
                {
                    fitness -= 1000;
                    break;
                }
                if (kromosom[j - 1].Equals("G2WS") && kromosom[j].Equals("GWS") && kromosom[j + 1].Equals("GWS"))
                {
                    fitness -= 1000;
                    break;
                }
                if (kromosom[j - 1].Equals("G2WS") && kromosom[j].Equals("GWS") && kromosom[j + 1].Equals("G2WS"))
                {
                    fitness -= 1000;
                    break;
                }
                if (kromosom[j - 1].Equals("G2WS") && kromosom[j].Equals("G2WS") && kromosom[j + 1].Equals("GS"))
                {
                    fitness -= 1000;
                    break;
                }
                if (kromosom[j - 1].Equals("G2WS") && kromosom[j].Equals("G2WS") && kromosom[j + 1].Equals("GWS"))
                {
                    fitness -= 1000;
                    break;
                }
                if (kromosom[j - 1].Equals("G2WS") && kromosom[j].Equals("G2WS") && kromosom[j + 1].Equals("G2WS"))
                {
                    fitness -= 1000;
                    break;
                }
                if (kromosom[j - 1].Equals("") && kromosom[j].Equals("GS") && kromosom[j + 1].Equals(""))
                {
                    fitness -= 1000;
                    break;
                }
                if (kromosom[j - 1].Equals("") && kromosom[j].Equals("GWS") && kromosom[j + 1].Equals(""))
                {
                    fitness -= 1000;
                    break;
                }
                if (kromosom[j - 1].Equals("") && kromosom[j].Equals("G2WS") && kromosom[j + 1].Equals(""))
                {
                    fitness -= 1000;
                    break;
                }
                if ((j - 1) != 0) {
                    if (kromosom[j - 1].Equals("GS") && kromosom[j - 1].Equals("GS") && kromosom[j].Equals("") && kromosom[j + 1].Equals(""))
                    {
                        fitness -= 1000;
                        break;
                    }
                    if (kromosom[j - 1].Equals("GS") && kromosom[j - 1].Equals("GWS") && kromosom[j].Equals("") && kromosom[j + 1].Equals(""))
                    {
                        fitness -= 1000;
                        break;
                    }
                    if (kromosom[j - 1].Equals("GWS") && kromosom[j - 1].Equals("GS") && kromosom[j].Equals("") && kromosom[j + 1].Equals(""))
                    {
                        fitness -= 1000;
                        break;
                    }
                    if (kromosom[j - 1].Equals("GWS") && kromosom[j - 1].Equals("GWS") && kromosom[j].Equals("") && kromosom[j + 1].Equals(""))
                    {
                        fitness -= 1000;
                        break;
                    }
                    if (kromosom[j - 1].Equals("GS") && kromosom[j - 1].Equals("G2WS") && kromosom[j].Equals("") && kromosom[j + 1].Equals(""))
                    {
                        fitness -= 1000;
                        break;
                    }
                    if (kromosom[j - 1].Equals("G2WS") && kromosom[j - 1].Equals("GS") && kromosom[j].Equals("") && kromosom[j + 1].Equals(""))
                    {
                        fitness -= 1000;
                        break;
                    }
                    if (kromosom[j - 1].Equals("G2WS") && kromosom[j - 1].Equals("GWS") && kromosom[j].Equals("") && kromosom[j + 1].Equals(""))
                    {
                        fitness -= 1000;
                        break;
                    }
                    if (kromosom[j - 1].Equals("GWS") && kromosom[j - 1].Equals("G2WS") && kromosom[j].Equals("") && kromosom[j + 1].Equals(""))
                    {
                        fitness -= 1000;
                        break;
                    }
                    if (kromosom[j - 1].Equals("G2WS") && kromosom[j - 1].Equals("GWS2") && kromosom[j].Equals("") && kromosom[j + 1].Equals(""))
                    {
                        fitness -= 1000;
                        break;
                    }
                    if (kromosom[j - 1].Equals("GS") && kromosom[j - 1].Equals("GS") && kromosom[j].Equals("") && kromosom[j + 1].Equals("GS"))
                    {
                        fitness -= 1000;
                        break;
                    }
                    if (kromosom[j - 1].Equals("GS") && kromosom[j - 1].Equals("GWS") && kromosom[j].Equals("") && kromosom[j + 1].Equals("GS"))
                    {
                        fitness -= 1000;
                        break;
                    }
                    if (kromosom[j - 1].Equals("GWS") && kromosom[j - 1].Equals("GS") && kromosom[j].Equals("") && kromosom[j + 1].Equals("GS"))
                    {
                        fitness -= 1000;
                        break;
                    }
                    if (kromosom[j - 1].Equals("GWS") && kromosom[j - 1].Equals("GWS") && kromosom[j].Equals("") && kromosom[j + 1].Equals("GS"))
                    {
                        fitness -= 1000;
                        break;
                    }
                    if (kromosom[j - 1].Equals("GS") && kromosom[j - 1].Equals("G2WS") && kromosom[j].Equals("") && kromosom[j + 1].Equals("GS"))
                    {
                        fitness -= 1000;
                        break;
                    }
                    if (kromosom[j - 1].Equals("G2WS") && kromosom[j - 1].Equals("GS") && kromosom[j].Equals("") && kromosom[j + 1].Equals("GS"))
                    {
                        fitness -= 1000;
                        break;
                    }
                    if (kromosom[j - 1].Equals("G2WS") && kromosom[j - 1].Equals("GWS") && kromosom[j].Equals("") && kromosom[j + 1].Equals("GS"))
                    {
                        fitness -= 1000;
                        break;
                    }
                    if (kromosom[j - 1].Equals("GWS") && kromosom[j - 1].Equals("G2WS") && kromosom[j].Equals("") && kromosom[j + 1].Equals("GS"))
                    {
                        fitness -= 1000;
                        break;
                    }
                    if (kromosom[j - 1].Equals("G2WS") && kromosom[j - 1].Equals("GWS2") && kromosom[j].Equals("") && kromosom[j + 1].Equals("GS"))
                    {
                        fitness -= 1000;
                        break;
                    }
                    if (kromosom[j - 1].Equals("GS") && kromosom[j - 1].Equals("GS") && kromosom[j].Equals("") && kromosom[j + 1].Equals("GWS"))
                    {
                        fitness -= 1000;
                        break;
                    }
                    if (kromosom[j - 1].Equals("GS") && kromosom[j - 1].Equals("GWS") && kromosom[j].Equals("") && kromosom[j + 1].Equals("GWS"))
                    {
                        fitness -= 1000;
                        break;
                    }
                    if (kromosom[j - 1].Equals("GWS") && kromosom[j - 1].Equals("GS") && kromosom[j].Equals("") && kromosom[j + 1].Equals("GWS"))
                    {
                        fitness -= 1000;
                        break;
                    }
                    if (kromosom[j - 1].Equals("GWS") && kromosom[j - 1].Equals("GWS") && kromosom[j].Equals("") && kromosom[j + 1].Equals("GWS"))
                    {
                        fitness -= 1000;
                        break;
                    }
                    if (kromosom[j - 1].Equals("GS") && kromosom[j - 1].Equals("G2WS") && kromosom[j].Equals("") && kromosom[j + 1].Equals("GWS"))
                    {
                        fitness -= 1000;
                        break;
                    }
                    if (kromosom[j - 1].Equals("G2WS") && kromosom[j - 1].Equals("GS") && kromosom[j].Equals("") && kromosom[j + 1].Equals("GWS"))
                    {
                        fitness -= 1000;
                        break;
                    }
                    if (kromosom[j - 1].Equals("G2WS") && kromosom[j - 1].Equals("GWS") && kromosom[j].Equals("") && kromosom[j + 1].Equals("GWS"))
                    {
                        fitness -= 1000;
                        break;
                    }
                    if (kromosom[j - 1].Equals("GWS") && kromosom[j - 1].Equals("G2WS") && kromosom[j].Equals("") && kromosom[j + 1].Equals("GWS"))
                    {
                        fitness -= 1000;
                        break;
                    }
                    if (kromosom[j - 1].Equals("G2WS") && kromosom[j - 1].Equals("GWS2") && kromosom[j].Equals("") && kromosom[j + 1].Equals("GWS"))
                    {
                        fitness -= 1000;
                        break;
                    }
                    if (kromosom[j - 1].Equals("GS") && kromosom[j - 1].Equals("GS") && kromosom[j].Equals("") && kromosom[j + 1].Equals("G2WS"))
                    {
                        fitness -= 1000;
                        break;
                    }
                    if (kromosom[j - 1].Equals("GS") && kromosom[j - 1].Equals("GWS") && kromosom[j].Equals("") && kromosom[j + 1].Equals("G2WS"))
                    {
                        fitness -= 1000;
                        break;
                    }
                    if (kromosom[j - 1].Equals("GWS") && kromosom[j - 1].Equals("GS") && kromosom[j].Equals("") && kromosom[j + 1].Equals("G2WS"))
                    {
                        fitness -= 1000;
                        break;
                    }
                    if (kromosom[j - 1].Equals("GWS") && kromosom[j - 1].Equals("GWS") && kromosom[j].Equals("") && kromosom[j + 1].Equals("G2WS"))
                    {
                        fitness -= 1000;
                        break;
                    }
                    if (kromosom[j - 1].Equals("GS") && kromosom[j - 1].Equals("G2WS") && kromosom[j].Equals("") && kromosom[j + 1].Equals("G2WS"))
                    {
                        fitness -= 1000;
                        break;
                    }
                    if (kromosom[j - 1].Equals("G2WS") && kromosom[j - 1].Equals("GS") && kromosom[j].Equals("") && kromosom[j + 1].Equals("G2WS"))
                    {
                        fitness -= 1000;
                        break;
                    }
                    if (kromosom[j - 1].Equals("G2WS") && kromosom[j - 1].Equals("GWS") && kromosom[j].Equals("") && kromosom[j + 1].Equals("G2WS"))
                    {
                        fitness -= 1000;
                        break;
                    }
                    if (kromosom[j - 1].Equals("GWS") && kromosom[j - 1].Equals("G2WS") && kromosom[j].Equals("") && kromosom[j + 1].Equals("G2WS"))
                    {
                        fitness -= 1000;
                        break;
                    }
                    if (kromosom[j - 1].Equals("G2WS") && kromosom[j - 1].Equals("GWS2") && kromosom[j].Equals("") && kromosom[j + 1].Equals("G2WS"))
                    {
                        fitness -= 1000;
                        break;
                    }
                }
                if (kromosom[j - 1].Equals("GWS") && kromosom[j].Equals("GWS") && kromosom[j + 1].Equals("GWS"))
                {
                    fitness -= 1000;
                    break;
                }
                if (kromosom[j - 1].Equals("G2WS") && kromosom[j].Equals("G2WS") && kromosom[j + 1].Equals("G2WS"))
                {
                    fitness -= 1000;
                    break;
                }

                if (kromosom[j - 1].Equals("") && kromosom[j].Equals("") && kromosom[j + 1].Equals("GS"))
                {
                    fitness -= 1000;
                    break;
                }
                if (kromosom[j - 1].Equals("") && kromosom[j].Equals("") && kromosom[j + 1].Equals("GWS"))
                {
                    fitness -= 1000;
                    break;
                }
                if (kromosom[j - 1].Equals("") && kromosom[j].Equals("") && kromosom[j + 1].Equals("G2WS"))
                {
                    fitness -= 1000;
                    break;
                }
                if (kromosom[j - 1].Equals("") && kromosom[j].Equals("") && kromosom[j + 1].Equals("GW"))
                {
                    fitness -= 1000;
                    break;
                }
                if (kromosom[j - 1].Equals("") && kromosom[j].Equals("") && kromosom[j + 1].Equals("G2W"))
                {
                    fitness -= 1000;
                    break;
                }
                if (kromosom[j - 1].Equals("") && kromosom[j].Equals("") && kromosom[j + 1].Equals("G3W"))
                {
                    fitness -= 1000;
                    break;
                }

                // 3 spike berdampingan
                if (kromosom[j - 1].Equals("GS") && kromosom[j].Equals("GS") && kromosom[j + 1].Equals("GS"))
                {
                    fitness -= 1000;
                    break;
                }
                if (kromosom[j - 1].Equals("GWS") && kromosom[j].Equals("GWS") && kromosom[j + 1].Equals("GWS"))
                {
                    fitness -= 1000;
                    break;
                }
                if (kromosom[j - 1].Equals("G2WS") && kromosom[j].Equals("G2WS") && kromosom[j + 1].Equals("G2WS"))
                {
                    fitness -= 1000;
                    break;
                }

                // 
                if (kromosom[j].Equals("G") && kromosom[j + 1].Equals("G2WS"))
                {
                    fitness -= 1000;
                    break;
                }
                if (kromosom[j].Equals("G") && kromosom[j + 1].Equals("G3W"))
                {
                    fitness -= 1000;
                    break;
                }
                if (kromosom[j].Equals("GS") && kromosom[j + 1].Equals("G2WS"))
                {
                    fitness -= 1000;
                    break;
                }
                if (kromosom[j].Equals("GS") && kromosom[j + 1].Equals("G3W"))
                {
                    fitness -= 1000;
                    break;
                }
                if (kromosom[j].Equals("GW") && kromosom[j + 1].Equals("G2WS"))
                {
                    fitness -= 1000;
                    break;
                }
                if (kromosom[j].Equals("GW") && kromosom[j + 1].Equals("G3W"))
                {
                    fitness -= 1000;
                    break;
                }
                if (kromosom[j].Equals("GWS") && kromosom[j + 1].Equals("G2WS"))
                {
                    fitness -= 1000;
                    break;
                }
                if (kromosom[j].Equals("GWS") && kromosom[j + 1].Equals("G3W"))
                {
                    fitness -= 1000;
                    break;
                }
                if (kromosom[j].Equals("") && kromosom[j + 1].Equals("G3W"))
                {
                    fitness -= 1000;
                    break;
                }
                if (kromosom[j].Equals("") && kromosom[j + 1].Equals("G2WS"))
                {
                    fitness -= 1000;
                    break;
                }
                if (kromosom[j].Equals("") && kromosom[j + 1].Equals("G2W"))
                {
                    fitness -= 1000;
                    break;
                }
            }
        }
    }


}
