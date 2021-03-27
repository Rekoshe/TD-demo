using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuModel : MonoBehaviour
{
    // This Class is considered static
    public static List<Menu> Menus;
    [SerializeField] private List<Menu> _menus;

    void Start()
    {
        Menus = _menus;
    }


}
