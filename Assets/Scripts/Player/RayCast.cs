using UnityEngine;

public class RayCast : MonoBehaviour
{
    [SerializeField] private Transform raycastOrigin;
    [SerializeField] private float maxDistance = 10f;
    
    private RaycastHit hit;

    public GameObject Raycast()
    {
    
        if (Physics.Raycast(raycastOrigin.position, raycastOrigin.forward, out hit, maxDistance))
        {
           return hit.collider.gameObject;
        }

        return null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(raycastOrigin.position, raycastOrigin.forward * maxDistance);
    }
}