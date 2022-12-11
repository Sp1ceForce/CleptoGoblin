using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemsController : MonoBehaviour
{
    public int Keys { get; private set; }
    public int Coins { get; private set; }  
    public void AddKey(int keysToAdd)
    {
        Keys += keysToAdd;
    }
    public void AddCoins(int coinsToAdd)
    {
        Coins += coinsToAdd;
    }
    //Returns result of spending key 
    //False if not enough keys, True if enough
    public bool SpendKey()
    {
        if(Keys-1 >= 0)
        {
            Keys--;
            return true;
        }
        else return false;
    }
}
