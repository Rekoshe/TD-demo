using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretModel : MonoBehaviour
{
    public static List<TurretSpt> turrets;
    public static List<Projectile> Projectiles;
    public static Material angryColor;
    public static Material chillColor;

    public Material angryMat;
    public Material chillMat;

    private void Start()
    {
        turrets = new List<TurretSpt>();
        Projectiles = new List<Projectile>();
        angryColor = angryMat;
        chillColor = chillMat;
    }

    public enum Types
    {
        Main,
        Lazer,
        ML
    }

}
