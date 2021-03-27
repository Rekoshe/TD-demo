using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TurretMenuController : MonoBehaviour
{
    [SerializeField] GameObject TurretMenu;
    [SerializeField] TextMeshProUGUI DablageTxt;
    [SerializeField] Button AddDamageButton;
    private TurretSpt _selectedTurret;

    public void OpenMenu(bool bol)
    {
        TurretMenu.SetActive(bol);
    }
    public void SetType(TurretModel.Types type)
    {
        //TypeTxt.text = "Type: " + type.ToString();
    }
    public void SetDablage(int dablage)
    {
        DablageTxt.text = "Dablage: " + dablage;
    }

    public void SetSelectedTurret(TurretSpt turret)
    {
        _selectedTurret = turret;
        SetDablage(turret.Damage);
    }
    public void AddDamgeToTurret(int damage)
    {
        _selectedTurret.Damage += damage;
        SetDablage(_selectedTurret.Damage);
    }
    public void UpgradeTurret()
    {
        _selectedTurret.UpgradeTurret();
    }
}
