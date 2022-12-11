
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
    [SerializeField] int goldInside = 550;
    [SerializeField] Transform lidTransform;
    [SerializeField] float closedLidRotation = 1.5f;
    [SerializeField] float openLidRotation = 0f;
    public override void Use()
    {
        switch (chestState)
        {
            case ChestState.Locked:
                OpenChest();
                break;
            case ChestState.Empty:
                PutGoblinInside();
                break;
            case ChestState.GoblinInside:
                ReleaseTheGoblin();
                break;
            default:
                Debug.LogError("Impossible chest state");
                break;
        }
    }
    void OpenChest()
    {
        var itemController = FindObjectOfType<PlayerItemsController>();
       /* if (itemController.SpendKey())
        {*/
            itemController.AddCoins(goldInside);
            chestState = ChestState.Empty;
            lidTransform.SetLocalPositionAndRotation(lidTransform.localPosition, Quaternion.Euler(openLidRotation, 0, 0));
        //}
    }
    void ReleaseTheGoblin()
    {
        HideSystem.Instance.StopHiding();
        chestState = ChestState.Empty;
        lidTransform.SetLocalPositionAndRotation(lidTransform.localPosition, Quaternion.Euler(openLidRotation, 0, 0));
    }

    void PutGoblinInside()
    {
        HideSystem.Instance.Hide();
        chestState = ChestState.GoblinInside;
        lidTransform.SetLocalPositionAndRotation(lidTransform.localPosition, Quaternion.Euler(closedLidRotation, 0, 0));
    }
}
