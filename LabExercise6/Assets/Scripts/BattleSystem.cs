using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BattleSystem : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI dialogText;

    public static BattleSystem bsInstance;

    private void Awake()
    {
        if (bsInstance == null)
        {
            bsInstance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
