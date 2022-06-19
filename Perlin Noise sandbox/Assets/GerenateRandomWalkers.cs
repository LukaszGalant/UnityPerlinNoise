using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RandomWalker
{
    public float RW_x { get; set; }
    public float RW_y { get; set; }
    public float RW_range { get; set; }

    public float RW_prob_N { get; set; }
    public float RW_prob_E { get; set; }
    public float RW_prob_W { get; set; }
    public float RW_prob_S { get; set; }
}


public class GerenateRandomWalkers : MonoBehaviour
{

    public GameObject Cube;
    public int RoomMiddle_x;
    public int RoomMiddle_y;
    public int RoomSize_x;
    public int RoomSize_y;
    public float Border_N;
    public float Border_E;
    public float Border_W;
    public float Border_S;
    public static List<RandomWalker> ListOfWalkers = new List<RandomWalker>();



    void Start()
    {
        //dla ka¿dego pokoju z listy pokojow
        RoomMiddle_x = 30;
        RoomMiddle_y = 50;
        RoomSize_x = 51;
        RoomSize_y = 51;

        SetBorders(RoomMiddle_x, RoomMiddle_y, RoomSize_x, RoomSize_y);

        CreateWalkers();
        ListWalkers();
        LetsTakeAWalk();

    }

    void SetBorders(float RoomMiddle_x, float RoomMiddle_y, float RoomSize_x, float RoomSize_y)
    {
        Border_N = RoomMiddle_y + (1 / 2.0f) * (RoomSize_y - 1) - 1;
        Border_E = RoomMiddle_x + (1 / 2.0f) * (RoomSize_x - 1) - 1;
        Border_W = RoomMiddle_x - (1 / 2.0f) * (RoomSize_x - 1) + 1;
        Border_S = RoomMiddle_y - (1 / 2.0f) * (RoomSize_y - 1) + 1;
    }

    void CreateWalkers()
    {
        int NumberOfWalkers = Random.Range(5, 15);
        CreateMandatoryWalkers();
        CreateRandomWalkers(NumberOfWalkers);
    }


    void CreateMandatoryWalkers()
    {
        //NORTH towards SOUTH
        ListOfWalkers.Add(new RandomWalker
        {
            RW_x = RoomMiddle_x,
            RW_y = Border_N + 1,
            RW_range = 50,
            RW_prob_N = 10, //10%
            RW_prob_E = 35, //25%
            RW_prob_W = 60, //25%
            RW_prob_S = 100  //40%
        });

        //EAST towards WEST
        ListOfWalkers.Add(new RandomWalker
        {
            RW_x = Border_E + 1,
            RW_y = RoomMiddle_y,
            RW_range = 50, 
            RW_prob_N = 25, //25%
            RW_prob_E = 35, //10%
            RW_prob_W = 75, //40%
            RW_prob_S = 100  //25%
        });

        //WEST towards EAST
        ListOfWalkers.Add(new RandomWalker
        {
            RW_x = Border_W - 1,
            RW_y = RoomMiddle_y,
            RW_range = 50,
            RW_prob_N = 25, //25%
            RW_prob_E = 65, //40%
            RW_prob_W = 75, //10%
            RW_prob_S = 100  //25%
        });

        //SOUTH towards NORTH
        ListOfWalkers.Add(new RandomWalker
        {
            RW_x = RoomMiddle_x,
            RW_y = Border_S - 1,
            RW_range = 50,
            RW_prob_N = 40, //40%
            RW_prob_E = 65, //25%
            RW_prob_W = 90, //25%
            RW_prob_S = 10  //10%
        });
    }

    void CreateRandomWalkers(int NumberOfWalkers)
    {
        for (int i = 1; i <= NumberOfWalkers; i++)
        {
            float GW_init_x = Mathf.Floor(Random.Range(Border_W, (Border_E + 1)));
            float GW_init_y = Mathf.Floor(Random.Range(Border_S, (Border_N + 1)));

            ListOfWalkers.Add(new RandomWalker
            {
                RW_x = GW_init_x,
                RW_y = GW_init_y,
                RW_range = 150,
                RW_prob_N = 25, //25%
                RW_prob_E = 50, //25%
                RW_prob_W = 75, //25%
                RW_prob_S = 100  //25%
            });
        }
    }

    void ListWalkers()
    {
        foreach (RandomWalker RW in ListOfWalkers)
        {
            Debug.Log(RW.RW_x + " ; " + RW.RW_y + " ; " + RW.RW_range);
        }
    }


    void LetsTakeAWalk()
    {
        foreach (RandomWalker RW in ListOfWalkers)
        {
            int Steps = 0;
            while(Steps <= RW.RW_range)
            {
                int r = Random.Range(0, 100);

                if (r <= RW.RW_prob_N) //NORTH-start
                {
                    if (RW.RW_y + 1 >= Border_N)
                    {
                        RW.RW_y--;
                        Steps--;
                    }
                    else
                    {
                        RW.RW_y++;
                    }
                }  //NORTH-end

                else if (r <= RW.RW_prob_E) //EAST-start
                {
                    if (RW.RW_x + 1 >= Border_E)
                    {
                        RW.RW_x--;
                        Steps--;
                    }
                    else
                    {
                        RW.RW_x++;
                    }
                }  //EAST-end

                else if (r <= RW.RW_prob_W) //WEST-start
                {
                    if (RW.RW_x - 1 <= Border_W)
                    {
                        RW.RW_x++;
                        Steps--;
                    }
                    else
                    {
                        RW.RW_x--;
                    }
                }  //WEST-end
                else
                {
                    if(RW.RW_y - 1 <= Border_S)
                    {
                        RW.RW_y++;
                        Steps--;
                    }
                    else
                    {
                        RW.RW_y--;
                    }
                }
                Instantiate(Cube, new Vector3(RW.RW_x, 0, RW.RW_y), Quaternion.identity);
                Steps++;
            }
        }
    }


}
