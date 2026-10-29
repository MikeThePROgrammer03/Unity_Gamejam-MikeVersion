using System.Collections.Generic;
using UnityEngine;

public class PlayerInventary : MonoBehaviour
{
    [SerializeField] private List<GameObject> inventaryPane; 
    [SerializeField] private InventaryUI inventaryUI;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            for(int i = 0; i < inventaryPane.Count; i++)
            {
                GameObject item = inventaryPane[i];
                item.SetActive(false);
            }
            if(inventaryPane.Count > 0)
            {
                GameObject item = inventaryPane[0];
                item.SetActive(true);
                ItemPickup pickup = item.GetComponent<ItemPickup>();
                inventaryUI.SeleccionarIcono(pickup.item.nombre);
                InteractAbility interactAbility = GetComponent<InteractAbility>();
                interactAbility.SelectItem(item);
            }
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            for(int i = 0; i < inventaryPane.Count; i++)
            {
                GameObject item = inventaryPane[i];
                item.SetActive(false);
            }
            if(inventaryPane.Count > 1)
            {
                GameObject item = inventaryPane[1];
                item.SetActive(true);
                ItemPickup pickup = item.GetComponent<ItemPickup>();
                inventaryUI.SeleccionarIcono(pickup.item.nombre);
                InteractAbility interactAbility = GetComponent<InteractAbility>();
                interactAbility.SelectItem(item);
            }
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            for(int i = 0; i < inventaryPane.Count; i++)
            {
                GameObject item = inventaryPane[i];
                item.SetActive(false);
            }
            if(inventaryPane.Count > 2)
            {
                GameObject item = inventaryPane[2];
                item.SetActive(true);
                ItemPickup pickup = item.GetComponent<ItemPickup>();
                inventaryUI.SeleccionarIcono(pickup.item.nombre);
                InteractAbility interactAbility = GetComponent<InteractAbility>();
                interactAbility.SelectItem(item);
            }
        }
    }
    public int GetInventaryCount()
    {
        return inventaryPane.Count;
    }
    public GameObject GetItemWithName(string itemName)
    {
        foreach(GameObject item in inventaryPane)
        {
            ItemPickup pickup = item.GetComponent<ItemPickup>();
            if(pickup.item.nombre == itemName)
            {
                return item;
            }
        }
        return null;
    }
    public void AddItemToInventary(GameObject item, ItemData itemData)
    {
        if(inventaryPane.Count < 3)
        {
            inventaryPane.Add(item);
            inventaryUI.AgregarIcono(itemData);
        }
    }
    public void RemoveItemFromInventary(GameObject item)
    {
        if(inventaryPane.Contains(item))
        {
            ItemPickup pickup = item.GetComponent<ItemPickup>();
            inventaryPane.Remove(item);
            inventaryUI.DeleteIcono(pickup.item.nombre);
        }
    }
    
 
}


