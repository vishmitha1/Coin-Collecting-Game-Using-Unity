using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    private int victoryCondition = 12;

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

    public void ResetCoins()
    {
        this.collectedCoins = 0;
        UIManager.Instance.UpdateCoinUI(collectedCoins, victoryCondition);
    }

    public void Finish()
    {
        if (collectedCoins >= victoryCondition)
        {
            SceneManager.LoadScene("SampleScene");
            this.ResetCoins();
        }
        else
        {
            UIManager.Instance.ShowVictoryConditionUI(collectedCoins, victoryCondition);
        }
    }
}
