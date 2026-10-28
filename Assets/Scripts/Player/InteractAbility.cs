using UnityEngine;

public class InteractAbility : MonoBehaviour
{
    private RayCast raycast;
    [SerializeField] private Transform parentTransform;
    void Start()
    {
        raycast = GetComponent<RayCast>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject hitObject = raycast.Raycast();
        if (hitObject != null && hitObject.tag == "Interactable")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                hitObject.transform.SetParent(parentTransform);
                hitObject.transform.localPosition = Vector3.zero;
                hitObject.SetActive(false);
            }
        }
    }
}
