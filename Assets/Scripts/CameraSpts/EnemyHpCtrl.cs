using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyHpCtrl : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI EnemyHp;

    private Enemy _enemy;

    private void Start()
    {
        _enemy = gameObject.GetComponent<Enemy>();
        _enemy.OnTookDamage.AddListener(SetHp);
    }

    public void SetHp(int hp)
    {
        EnemyHp.text = hp.ToString();
    }

    
}
