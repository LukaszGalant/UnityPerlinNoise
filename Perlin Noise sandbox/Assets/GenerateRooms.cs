using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GenerateRooms : MonoBehaviour
{
    public class Room
    {
        public int X { set; get; } // x coordintace of middle of the room
        public int Y { set; get; } // y coordintace of middle of the room
        public int RoomType { set; get; } // 1 = Room // 2 - Corridor
        public bool Finished { set; get; } //Do we want to generate neighbours for this room?
        public int EntranceN { set; get; } // Does it have an north entrance? (0 - no, 1 - yes)
        public int EntranceE { set; get; } // Does it have an east entrance? (0 - no, 1 - yes)
        public int EntranceW { set; get; } // Does it have an west entrance? (0 - no, 1 - yes)
        public int EntranceS { set; get; } // Does it have an south entrance? (0 - no, 1 - yes)
    }

    public class GridCell
    {
        public int X { set; get; }
        public int Y { set; get; }

    }

    // Variables
    public int RoomLimit;
    public List<Room> ListOfRooms = new List<Room>();
    bool SuccessfulCheck = false;
    bool NeighbourRoomBool;
    bool NeighbourCorridorBool;
    int RoomCounter = 1;


    void Start()
    {
        while (SuccessfulCheck != true)
        {
            CreateRooms();
        }
        Debug.Log("Succesful! Spawned " + RoomCounter + " rooms");
    }

    void CreateRooms()
    {
        // Variables
        Room SelectedRoom = new Room();
        int deltaX = 0;
        int deltaY = 0;
        int deltaN = 0;
        int deltaE = 0;
        int deltaW = 0;
        int deltaS = 0;

        // Create new list - if SuccessfulCheck fails, it will overwrite data from last run
        List<Room> ListOfRooms = new List<Room>();

        // Create initial Room
        ListOfRooms.Add(new Room
        {
            X = 0,
            Y = 0,
            RoomType = 1,
            Finished = false,
            EntranceN = 0,
            EntranceE = 0,
            EntranceW = 0,
            EntranceS = 0
        });

        while (RoomCounter < RoomLimit)
        {

            // check if there are any rooms that haven't been processed
            bool RoomFound = false;
            foreach (Room Room in ListOfRooms)
            {
                if (Room.Finished == false && Room.RoomType == 1)
                {
                    SelectedRoom = Room;
                    RoomFound = true;
                    break;
                }
            }

            if (RoomFound == false) // can't find a room
            {
                SuccessfulCheck = false;
                return;
            }
            else
            {
                // found room that needs some neighbourhood
                for (int i = 1; i <= 4; i++)
                {
                    switch (i)
                    {
                        case 1: // NORTH
                            deltaX = 0;
                            deltaY = 1;
                            deltaN = 1;
                            deltaE = 0;
                            deltaW = 0;
                            deltaS = 1;
                            break;

                        case 2: // EAST
                            deltaX = 1;
                            deltaY = 0;
                            deltaN = 0;
                            deltaE = 1;
                            deltaW = 1;
                            deltaS = 0;
                            break;

                        case 3: // WEST
                            deltaX = -1;
                            deltaY = 0;
                            deltaN = 0;
                            deltaE = 1;
                            deltaW = 1;
                            deltaS = 0;
                            break;

                        case 4: // SOUTH
                            deltaX = 0;
                            deltaY = -1;
                            deltaN = 1;
                            deltaE = 0;
                            deltaW = 0;
                            deltaS = 1;
                            break;
                    }

                    int CoinFlip = Random.Range(0, 4); // 75% success chance (0 == fail, 1-3 == success)

                    if (CoinFlip != 0)
                    {
                        // success
                        NeighbourRoomBool = false;
                        NeighbourCorridorBool = false;

                        foreach (Room Room in ListOfRooms)
                        {
                            if (Room.X == SelectedRoom.X + deltaX && Room.Y == SelectedRoom.Y + deltaY)
                            {
                                NeighbourCorridorBool = true;
                            }

                            if (Room.X == SelectedRoom.X + 2 * deltaX && Room.Y == SelectedRoom.Y + 2 * deltaY)
                            {
                                NeighbourRoomBool = true;
                            }
                        }

                        CoinFlip = Random.Range(0, 3); //33% success chance (0 == success, 1 == failure, 2 == failure)

                        if (NeighbourCorridorBool == false)
                        {
                            if (NeighbourRoomBool == false)
                            {
                                //spawn corridor
                                ListOfRooms.Add(new Room
                                {
                                    X = SelectedRoom.X + deltaX,
                                    Y = SelectedRoom.Y + deltaY,
                                    RoomType = 2,
                                    Finished = false,
                                    EntranceN = deltaN,
                                    EntranceE = deltaE,
                                    EntranceW = deltaW,
                                    EntranceS = deltaS
                                });

                                //spawn room
                                ListOfRooms.Add(new Room
                                {
                                    X = SelectedRoom.X + 2 * deltaX,
                                    Y = SelectedRoom.Y + 2 * deltaY,
                                    RoomType = 1,
                                    Finished = false,
                                    EntranceN = 0,
                                    EntranceE = 0,
                                    EntranceW = 0,
                                    EntranceS = 0
                                });
                                RoomCounter++;
                            }

                            if (NeighbourRoomBool == true && CoinFlip == 0) //success
                            {
                                //spawn corridor
                                ListOfRooms.Add(new Room
                                {
                                    X = SelectedRoom.X + deltaX,
                                    Y = SelectedRoom.Y + deltaY,
                                    RoomType = 2,
                                    Finished = false,
                                    EntranceN = deltaN,
                                    EntranceE = deltaE,
                                    EntranceW = deltaW,
                                    EntranceS = deltaS
                                });
                            }
                        }
                    }



                }
                SelectedRoom.Finished = true;
            }
        }

        SuccessfulCheck = true;
        foreach (Room Room in ListOfRooms)
        {
            DebugRoom(Room);
        }

    }




    void DebugRoom(Room R)
    {
        Debug.LogFormat("x: {0}; y: {1}; RoomType: {2}; Finished?: {3}; Entrances: {4}, {5}, {6}, {7}", R.X, R.Y, R.RoomType, R.Finished, R.EntranceN, R.EntranceE, R.EntranceW, R.EntranceS);
    }





}
