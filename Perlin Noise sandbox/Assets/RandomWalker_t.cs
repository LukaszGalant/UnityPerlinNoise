using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RandomWalker4
{
    public int RW_x { get; set; }
    public int RW_y { get; set; }
    public int RW_steps { get; set; }

    public float RW_prob_N { get; set; }
    public float RW_prob_E { get; set; }
    public float RW_prob_W { get; set; }
    public float RW_prob_S { get; set; }

}









public class Tuple
{
    public int Iks { get; set; }
    public int Ygrek { get; set; }
}

public class RandomWalker_t : MonoBehaviour
{
    public GameObject CubeB1;
    public GameObject CubeB2;
    public GameObject CubeB3;
    public GameObject CubeB4;
    public GameObject CubeB5;
    public GameObject CubeB6;
    public GameObject CubeB7;
    public GameObject CubeB8;
    public GameObject CubeAdd;

    public int limit = 30;


    int x, y;
    int objectCounter = 0;
    public List<Tuple> ListOfTuples;
    // Start is called before the first frame update


    void Start()
    {
        List<Tuple> ListOfTuples = new List<Tuple>();
        x = -25;
        y = 0;
        ListOfTuples.Add(new Tuple { Iks = x, Ygrek = y });
        //Instantiate(CubeB1, new Vector3(x, 0, y), Quaternion.identity);
        Debug.Log(ListOfTuples.Count);
        int licznik = 0;
        while (licznik < 400)
        {
            int r = Random.Range(0, 100);

            if (r <= 45)
            { x++; }
            else if (r <= 63)
            { x--; }
            else if (r <= 81)
            { y++; }
            else
            { y--; }

            ListOfTuples.Add(new Tuple { Iks = x, Ygrek = y });
            //Instantiate(CubeB1, new Vector3(x, 0, y), Quaternion.identity);
            licznik++;
            objectCounter++;


        }

        x = 0;
        y = -25;
        ListOfTuples.Add(new Tuple { Iks = x, Ygrek = y });
        //Instantiate(CubeB2, new Vector3(x, 0, y), Quaternion.identity);
        licznik = 0;
        while (licznik < 400)
        {
            int r = Random.Range(0, 100);

            if (r <= 45)
            { y++; }
            else if (r <= 63)
            { x--; }
            else if (r <= 81)
            { x++; }
            else
            { y--; }


            ListOfTuples.Add(new Tuple { Iks = x, Ygrek = y });
            //Instantiate(CubeB2, new Vector3(x, 0, y), Quaternion.identity);
            licznik++;
            objectCounter++;


        }

        x = 0;
        y = 25;
        ListOfTuples.Add(new Tuple { Iks = x, Ygrek = y });
        //Instantiate(CubeB3, new Vector3(x, 0, y), Quaternion.identity);
        licznik = 0;
        while (licznik < 400)
        {
            int r = Random.Range(0, 100);

            if (r <= 45)
            { y--; }
            else if (r <= 63)
            { x--; }
            else if (r <= 81)
            { x++; }
            else
            { y++; }



            ListOfTuples.Add(new Tuple { Iks = x, Ygrek = y });
            //Instantiate(CubeB3, new Vector3(x, 0, y), Quaternion.identity);
            licznik++;
            objectCounter++;

        }

        x = 25;
        y = 0;
        ListOfTuples.Add(new Tuple { Iks = x, Ygrek = y });
        //Instantiate(CubeB4, new Vector3(x, 0, y), Quaternion.identity);
        licznik = 0;
        while (licznik < 400)
        {
            int r = Random.Range(0, 100);

            if (r <= 45)
            { x--; }
            else if (r <= 63)
            { y--; }
            else if (r <= 81)
            { x++; }
            else
            { y++; }


            ListOfTuples.Add(new Tuple { Iks = x, Ygrek = y });
            //Instantiate(CubeB4, new Vector3(x, 0, y), Quaternion.identity);
            licznik++;
            objectCounter++;


        }

        x = 25;
        y = 25;
        ListOfTuples.Add(new Tuple { Iks = x, Ygrek = y });
        //Instantiate(CubeB5, new Vector3(x, 0, y), Quaternion.identity);
        licznik = 0;
        while (licznik < 400)
        {
            int r = Random.Range(0, 100);

            if (r <= 32)
            { x--; }
            else if (r <= 65)
            { y--; }
            else if (r <= 82)
            { x++; }
            else
            { y++; }



            ListOfTuples.Add(new Tuple { Iks = x, Ygrek = y });
            //Instantiate(CubeB5, new Vector3(x, 0, y), Quaternion.identity);
            licznik++;
            objectCounter++;


        }

        x = -25;
        y = 25;
        ListOfTuples.Add(new Tuple { Iks = x, Ygrek = y });
        //Instantiate(CubeB6, new Vector3(x, 0, y), Quaternion.identity);
        licznik = 0;
        while (licznik < 400)
        {
            int r = Random.Range(0, 100);

            if (r <= 32)
            { x++; }
            else if (r <= 65)
            { y--; }
            else if (r <= 82)
            { x--; }
            else
            { y++; }



            ListOfTuples.Add(new Tuple { Iks = x, Ygrek = y });
            //Instantiate(CubeB6, new Vector3(x, 0, y), Quaternion.identity);
            licznik++;
            objectCounter++;


        }

        x = 25;
        y = -25;
        ListOfTuples.Add(new Tuple { Iks = x, Ygrek = y });
        //Instantiate(CubeB7, new Vector3(x, 0, y), Quaternion.identity);
        licznik = 0;
        while (licznik < 400)
        {
            int r = Random.Range(0, 100);

            if (r <= 32)
            { x--; }
            else if (r <= 65)
            { y++; }
            else if (r <= 82)
            { x++; }
            else
            { y--; }


            ListOfTuples.Add(new Tuple { Iks = x, Ygrek = y });
            //Instantiate(CubeB7, new Vector3(x, 0, y), Quaternion.identity);
            licznik++;
            objectCounter++;


        }

        x = -25;
        y = -25;
        ListOfTuples.Add(new Tuple { Iks = x, Ygrek = y });
        //Instantiate(CubeB8, new Vector3(x, 0, y), Quaternion.identity);
        licznik = 0;
        while (licznik < 400)
        {
            int r = Random.Range(0, 100);

            if (r <= 32)
            { x++; }
            else if (r <= 65)
            { y++; }
            else if (r <= 82)
            { x--; }
            else
            { y--; }


            ListOfTuples.Add(new Tuple { Iks = x, Ygrek = y });
            //Instantiate(CubeB8, new Vector3(x, 0, y), Quaternion.identity);
            licznik++;
            objectCounter++;


        }

        Debug.Log("CounteR: " + objectCounter);


        int InitialBlockCounter = ListOfTuples.Count;
        int blockx;
        int blocky;

        for (int k = 1; k <= InitialBlockCounter; k++)
        {
            blockx = ListOfTuples[k].Iks;
            blocky = ListOfTuples[k].Ygrek;


                ListOfTuples.Add(new Tuple { Iks = blockx, Ygrek = blocky + 1 });
                ListOfTuples.Add(new Tuple { Iks = blockx, Ygrek = blocky - 1 });
                ListOfTuples.Add(new Tuple { Iks = blockx + 1, Ygrek = blocky });
                ListOfTuples.Add(new Tuple { Iks = blockx - 1, Ygrek = blocky });
            
        }
            Debug.Log("CounteR: " + objectCounter);


            InitialBlockCounter = ListOfTuples.Count;

        for (int kh = 1; kh <= InitialBlockCounter; kh++)
        {
            blockx = ListOfTuples[kh].Iks;
            blocky = ListOfTuples[kh].Ygrek;


                ListOfTuples.Add(new Tuple { Iks = blockx, Ygrek = blocky + 1 });
                ListOfTuples.Add(new Tuple { Iks = blockx, Ygrek = blocky - 1 });
                ListOfTuples.Add(new Tuple { Iks = blockx + 1, Ygrek = blocky });
                ListOfTuples.Add(new Tuple { Iks = blockx - 1, Ygrek = blocky });
            

            
        }
        Debug.Log("CounteR: " + objectCounter);

        bool Founter;

                for (int xx = -30; xx <= 30; xx++)
                {
                    for (int yy = -30; yy <= 30; yy++)
                    {
                        Founter = false;
                        foreach (Tuple TT in ListOfTuples)
                        {
                            if (xx == -30 || xx == 30 || yy == -30 || yy == 30)
                            {
                                Founter = false;
                                break;
                            }

                        

                            if (TT.Iks == xx && TT.Ygrek == yy)
                            {
                                Founter = true;
                                break;
                            }
                                                       
                        }


                        if (!Founter)
                        {
                            Instantiate(CubeAdd, new Vector3(xx, 0, yy), Quaternion.identity);
                        }



                    }




                }





            }
        
    

}
