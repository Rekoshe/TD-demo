using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapSelectionMenu : Menu
{

    public void OnFirstMapClick()
    {
        SceneManager.LoadScene("MapLayout");
    }
}
