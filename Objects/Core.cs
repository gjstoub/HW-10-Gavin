using System.Collections.Generic;
using UnityEngine;

public class Core
{
    public static Player thePlayer = new Player("Mike");
    public static Monster theMonster = new Monster("Goblin");
    public static Vector3 mmStartPos = new Vector3(14.95f, 0, 0);

    public static List<string> roomNames = new List<string>();

    public static void AddRoomName(string roomName)
    {
        roomNames.Add(roomName);
    }

    public static void DisplayRoomNames()
    {
        Debug.Log("Rooms in the Dungeon:");
        foreach (string room in roomNames)
        {
            Debug.Log(room);
        }
    }
}
