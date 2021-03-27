using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScene : MonoBehaviour
{
    [SerializeField] private Menu _firstMenu;
    // Start is called before the first frame update
    void Start()
    {
        _firstMenu.GotoMenu(_firstMenu);
        OptionsMenu.SettingsData = SaveManager.LoadSettings();
    }
    

}
