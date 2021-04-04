using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretPlacement : MonoBehaviour
{
    [SerializeField] private GameObject applyAndCancelButtons;
    [SerializeField] private GameObject selectionPanel;

    private TurretSpt turret;

    public void SpwanTurret(TurretSpt turret)
    {
        this.turret = Instantiate(turret, new Vector3(0, 0, 0), Quaternion.identity);
        selectionPanel.SetActive(false);
        applyAndCancelButtons.SetActive(true);
    }

    public void OnApplyButtonClicked()
    {
        turret.Activated = true;
        applyAndCancelButtons.SetActive(false);
    }

    public void OnCancelButtonClicked()
    {
        Destroy(turret.gameObject);
        applyAndCancelButtons.SetActive(false);
        selectionPanel.SetActive(true);

    }

    
}
