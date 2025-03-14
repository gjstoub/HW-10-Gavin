using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Room : MonoBehaviour
{
    private static List<string> visitedRooms = new List<string>();
    private static Dictionary<string, Vector2> roomPositions = new Dictionary<string, Vector2>();
    private static Transform miniMapParent;
    private static GameObject roomPrefab;

    private Player thePlayer;
    private string name;
    
    public Room(string name)
    {
        this.name = name;

        if (miniMapParent == null)
        {
            miniMapParent = GameObject.Find("MiniMap").transform;
            roomPrefab = Resources.Load<GameObject>("MiniMapRoom");
        }
    }

    public void setPlayer(Player p)
    {
        this.thePlayer = p;
        this.thePlayer.setCurrentRoom(this);

        if (!visitedRooms.Contains(name))
        {
            visitedRooms.Add(name);
            Vector2 newPosition = GetNewRoomPosition();
            roomPositions[name] = newPosition;

            GameObject roomIcon = GameObject.Instantiate(roomPrefab, miniMapParent);
            roomIcon.GetComponent<RectTransform>().anchoredPosition = newPosition;
        }
    }

    private Vector2 GetNewRoomPosition()
    {
        if (visitedRooms.Count == 1) return Vector2.zero;
        return new Vector2(visitedRooms.Count * 50, 0);
    }
}

}
