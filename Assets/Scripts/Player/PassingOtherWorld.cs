using UnityEngine;

public class PassingOtherWorld : MonoBehaviour
{
    [SerializeField] GameObject InventaryUI;
    [SerializeField] GameObject InventaryUI2;
    [SerializeField] private bool isInOtherWorld = false;
    private bool canPass = false;
    [SerializeField] private Collider otherWorldCollider;
    [SerializeField] private PlayerInventary playerInventary;
    [SerializeField] private TimePasing timePasing; 


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Passing"))
        {
            if (!isInOtherWorld)
            {
                if(playerInventary.GetInventaryCount() == 0)
                {
                    CanPass();
                }
                else
                {
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                    InventaryUI.SetActive(false);
                    InventaryUI2.SetActive(true); 
                }
               
            }
            else
            {
                isInOtherWorld = false;
                otherWorldCollider.isTrigger = false;
            }
        }
        if (other.CompareTag("ResetTime"))
        {
            timePasing.ResetTimer();
        }
        
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Passing"))
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            InventaryUI.SetActive(true);
            InventaryUI2.SetActive(false);
        }
        if (other.CompareTag("ResetTime"))
        {
            timePasing.StartTimer();
        }
    }

    public void CanPass()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        InventaryUI.SetActive(true);
        InventaryUI2.SetActive(false);
        isInOtherWorld = true;
        otherWorldCollider.isTrigger = true;
    }
}
