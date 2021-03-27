using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapModel : MonoBehaviour
{
    /* list of lists where the first list inside
     * is the slow list, second is meduim etc.. */
    public static List<List<Transform>> Lanes; 

    public enum Lane // static is not valid for this so I decided to move it here to test
    {
        Slow,
        Medium,
        Fast
    }

    private void Start()
    {

        Lanes = new List<List<Transform>>();
    }
}
