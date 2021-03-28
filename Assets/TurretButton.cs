using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretButton 
{
    public UnityAction Action;
    public Image TurretIcon;
    public TurretButton( Image turretIcon, UnityAction action)
    {
        TurretIcon = turretIcon;
        Action = action;
    }
}
