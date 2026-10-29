using UnityEngine;

public class SelectedItem : MonoBehaviour
{   
    
    public void TakOfItem()
    {
        Debug.Log("tHis is the item name: " + gameObject.name);
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        PassingOtherWorld passingOtherWorld = player.GetComponent<PassingOtherWorld>();
        InteractAbility playerInteract = player.GetComponent<InteractAbility>();
        PlayerInventary playerInventary = player.GetComponent<PlayerInventary>();
        GameObject itemObject = playerInventary.GetItemWithName(gameObject.name);
        playerInteract.TakOffItem(itemObject, false);
        passingOtherWorld.CanPass();
    }
}
