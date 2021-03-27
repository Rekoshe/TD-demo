using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    [SerializeField] GameObject parentObj;

    
    //List the waypoints and store them in MapModele.Lanes
    public void ListWaypoints()
    {
        List<Transform> children = new List<Transform>();
        for (int i = 0; i < parentObj.transform.childCount; i++)
        {
            children.Add(parentObj.transform.GetChild(i));
        }

        foreach (Transform child in children)
        {
            List<Transform> waypoint = new List<Transform>();
            for (int i = 0; i < child.transform.childCount; i++)
            {
                waypoint.Add(child.transform.GetChild(i));
            }
            MapModel.Lanes.Add(waypoint);
        }

        //Debug.Log("waypoints listed");
    }

}
