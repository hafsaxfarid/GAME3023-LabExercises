using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUnit : MonoBehaviour
{
    [SerializeField]
    public List<EnemyBase> enemies = new List<EnemyBase>();

    [SerializeField]
    public Image enemyImageSprite;

    private EnemyBase enemyBase;

    public int enemyNumber;

    void Start()
    {
        RandomEnemy();
    }

    private void Update()
    {
        if (GameManager.gmInstance.inBattle == false)
        {
            RandomEnemy();
        }
        
        if (GameManager.gmInstance.inBattle == true)
        {
            StartBattle();
        }
    }

    void StartBattle()
    {
        enemyImageSprite.sprite = enemies[enemyNumber].enemyIcon;
        BattleSystem.bsInstance.dialogText.text = enemies[enemyNumber].enemyDescription;
    }

    void RandomEnemy()
    {
        enemyNumber = Random.Range(0, enemies.Count);
    }
}
