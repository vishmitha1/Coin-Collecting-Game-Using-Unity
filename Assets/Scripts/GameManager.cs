using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject go = new GameObject("GameManager");
                instance = go.AddComponent<GameManager>();
                DontDestroyOnLoad(go);
            }
            return instance;
        }
    }

    private int collectedCoins;
    private int victoryCondition = 10;

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

    private void Start()
    {
        UIManager.Instance.UpdateCoinUI(collectedCoins, victoryCondition);
    }

    public void AddCoins(int coins)
    {
        this.collectedCoins += coins;
        UIManager.Instance.UpdateCoinUI(collectedCoins, victoryCondition);
    }
}
