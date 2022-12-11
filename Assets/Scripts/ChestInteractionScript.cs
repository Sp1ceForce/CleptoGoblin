
using UnityEngine;

enum ChestState
{
    Locked,
    Empty,
    GoblinInside
}
public class ChestInteractionScript : BaseInteractableLogic
{
    private ChestState chestState = ChestState.Locked;
    public override void Use()
    {
        switch (chestState)
        {
            case ChestState.Locked:
                break;
            case ChestState.Empty:
                break;
            case ChestState.GoblinInside:
                Debug.Log("Goblin Inside");
                break;
            default:
                Debug.LogError("Impossible chest state");
                break;
        }
    }
}
