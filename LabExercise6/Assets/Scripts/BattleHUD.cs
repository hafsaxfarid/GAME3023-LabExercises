using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BattleHUD : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI nameText;
    
    [SerializeField]
    public TextMeshProUGUI levelText;

    public void SetHUD(string name, int level)
    {
        nameText.text = name;
        levelText.text = level.ToString();
    }
}
