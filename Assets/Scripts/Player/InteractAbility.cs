using UnityEngine;

public class InteractAbility : MonoBehaviour
{
    private RayCast raycast;
    private PlayerInventary playerInventary;
    [SerializeField] private GameObject itemSelected;
    [SerializeField] private Transform parentTransform;
    void Start()
    {
        raycast = GetComponent<RayCast>();
        playerInventary = GetComponent<PlayerInventary>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject hitObject = raycast.Raycast();
        if (Input.GetKeyDown(KeyCode.E)){
            if(hitObject != null)
            {
               ItemPickup pickup = hitObject.GetComponent<ItemPickup>();
               if (pickup == null)
                {
                    if (itemSelected != null)
                    {
                        ItemPickup itemPickup = itemSelected.GetComponent<ItemPickup>();
                        if (itemPickup != null && itemPickup.item.nombre == hitObject.name)
                        {
                            UnlockDoor unlockDoor = hitObject.GetComponent<UnlockDoor>();
                            if (unlockDoor != null)
                            {
                                unlockDoor.Unlock();
                            }
                        }
                    }
                }
                else{
                    hitObject.transform.SetParent(parentTransform);
                    hitObject.transform.localPosition = Vector3.zero;
                    hitObject.transform.localRotation = Quaternion.identity;
                    hitObject.SetActive(false);
                    hitObject.tag = "Untagged";
                    Rigidbody rb = hitObject.GetComponent<Rigidbody>();
                    rb.isKinematic = true;
                    playerInventary.AddItemToInventary(hitObject, pickup.item);
                    hitObject.SetActive(false);
                }
            }
        
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(itemSelected != null)
            {
                TakOffItem(itemSelected);
                itemSelected = null;
            }
        }

    }
    public void SelectItem(GameObject item)
    {
        itemSelected = item;
    }
    public void TakOffItem(GameObject item, bool takeOfF = true)
    {
        item.transform.SetParent(null);
        item.SetActive(true);  
        Rigidbody rb = item.GetComponent<Rigidbody>();
        KeysApper keysApper = item.GetComponent<KeysApper>();
        keysApper.ResetPosition(); 
        rb.isKinematic = false;
        item.tag = "Interactable";
        playerInventary.RemoveItemFromInventary(item);
        if (!takeOfF)
        {
            Debug.Log("ItemHit: " + item.name);
        }
    

    }

}
