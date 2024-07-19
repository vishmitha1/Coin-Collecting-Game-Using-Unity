using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Collectable
{
    [SerializeField] private int coinValue = 1;

    protected override void Collected()
    {
        GameManager.Instance.AddCoins(coinValue);
        Destroy(this.gameObject);
    }
}
