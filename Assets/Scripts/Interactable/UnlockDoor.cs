using UnityEngine;

public class UnlockDoor : MonoBehaviour
{
    [SerializeField] private OpenDoor openDoor;

    public void Unlock()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = false;
        }
        if (openDoor != null)
        {
            openDoor.Abrir();
        }
    }
}
