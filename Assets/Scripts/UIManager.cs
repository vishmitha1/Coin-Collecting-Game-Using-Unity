using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txtCoin , txtVictoryCondition;
    [SerializeField] private GameObject victoryCondition;
       private static UIManager instance;

    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject go = new GameObject("UIManager");
                instance = go.AddComponent<UIManager>();
                DontDestroyOnLoad(go);
            }
            return instance;
        }
    }

    private int coins;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

    public void UpdateCoinUI(int coins, int victoryCondition)
    {
        this.coins += coins;
        txtCoin.text = "Coins: " + coins + "/" + victoryCondition;
        
    }

    public void ShowVictoryConditionUI(int _coins , int _victoryCondition)
    {
        victoryCondition.SetActive(true);
        txtVictoryCondition.text = "You need  " + (_victoryCondition - _coins) + " more coins to win!";
    }
    public void HideVictoryConditionUI()
    {
        victoryCondition.SetActive(false);
    
    }
    
}
