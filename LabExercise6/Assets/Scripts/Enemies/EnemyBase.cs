using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyEffect
{
    None,
    Poison,
    Stun,
    Bleed,
    Burn
}

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemies/New Enemy")]
public class EnemyBase : ScriptableObject
{
    public Sprite enemyIcon;
    public string enemyName = "";
    public string enemyDescription = "";

    // Enemy Stats
    [Range(1, 10)]
    public int enemyLevel;

    [Range(1, 100)]
    public int enemyHealth;

    [Range(1, 100)]
    public int enemyAttrack;

    public EnemyEffect enemyEff1;
    //public EnemyEffect enemyEff2;
}