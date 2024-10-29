using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class KillEnemyButton : MonoBehaviour
{
    public EnemySpawner enemySpawner;
    public float killRadius = 5f; 
    [SerializeField] private Button ButtonKill;
    [SerializeField] private Button ButtonKill4;
    [SerializeField] private Button ButtonKill3;
    [SerializeField] private Button ButtonKill2;
    PoolableEnemy Poorb;

    private void Awake()
    {
        ButtonKill.onClick.AddListener(OnButtonClick);
        ButtonKill2.onClick.AddListener(OnButtonClick);
        ButtonKill3.onClick.AddListener(OnButtonClick);
        ButtonKill4.onClick.AddListener(OnButtonClick);
    }
    public void OnButtonClick()
    {
        if (enemySpawner != null)
        {
            foreach (var pool in enemySpawner.pooler)
            {
                foreach (var enemy in pool.GetPool())
                {
                    if (enemy.activeInScene)
                    {
                        float distance = Vector3.Distance(transform.position, enemy.transform.position);
                        if (distance <= killRadius)
                        {
                            enemy.Deactivate();
                        }
                    }
                }
            }
        }
    }
}