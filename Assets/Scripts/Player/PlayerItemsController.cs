using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemsController : MonoBehaviour
{
    public System.Action OnItemsChange;
    public int Keys { get; private set; }
    public int Coins { get; private set; }  

    void Start(){
        DontDestroyOnLoad(gameObject); 
    }
    public void AddKey(int keysToAdd)
    {
        Keys += keysToAdd;
        OnItemsChange?.Invoke();
    }
    
    public void AddCoins(int coinsToAdd)
    {
        Coins += coinsToAdd;
        OnItemsChange?.Invoke();
    }
    //Returns result of spending key 
    //False if not enough keys, True if enough
    public bool SpendKey()
    {
        if(Keys-1 >= 0)
        {
            Keys--;
            OnItemsChange?.Invoke();
            return true;
        }
        else return false;
    }
}
