using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Container : MonoBehaviour
{
    [SerializeField] Button TurretButtonPrefab;
    [SerializeField] List<TurretSpt> Prefabs;

    [SerializeField] int screenwidth = 30;
    // Start is called before the first frame update
    void Start()
    {
        CreateContainer(Prefabs);
    }
    
    public void CreateContainer(List<TurretSpt> turrets) 
    {
        float margin = screenwidth/turrets.Count;
        int counter = 0;

        foreach(TurretSpt turret in turrets )
        {
            
            Button thisButton =
                Instantiate(TurretButtonPrefab, new Vector3(margin * counter + 100, 100), Quaternion.identity, gameObject.transform);
            
            thisButton.image = TurretSpt.Icon;
            thisButton.onClick.AddListener(() =>
            {
                Instantiate( turret, new Vector3(0, 0, 0), Quaternion.identity);
            });
            counter++;
        }
    }

}
