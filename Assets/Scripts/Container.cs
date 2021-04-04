using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Container : MonoBehaviour
{
    [SerializeField] Button TurretButtonPrefab;
    [SerializeField] List<TurretSpt> Prefabs;

    [SerializeField] int SpaceBetweenTurrets = 100;
    [SerializeField] TurretPlacement placementSpt;
    // Start is called before the first frame update
    void Start()
    {
        CreateContainer(Prefabs);
        
    }
    
    public void CreateContainer(List<TurretSpt> turrets) 
    {
        
        int counter = 0;
        
        foreach(TurretSpt turret in turrets )
        {
            
            Button thisButton =
                Instantiate(TurretButtonPrefab,
                 gameObject.transform);

            thisButton.transform.position = new Vector3(100 + SpaceBetweenTurrets * counter, gameObject.transform.position.y);
            thisButton.image = TurretSpt.Icon;
            thisButton.onClick.AddListener(() =>
            {
                placementSpt.SpwanTurret(turret);

            });
            counter++;
        }
    }

}
