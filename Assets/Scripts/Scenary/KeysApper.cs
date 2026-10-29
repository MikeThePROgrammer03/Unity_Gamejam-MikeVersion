using UnityEngine;

public class KeysApper : MonoBehaviour
{
    [SerializeField] private GameObject keyZone;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ResetPosition();
    }

    // Update is called once per frame
    void ResetPosition()
    {
        gameObject.transform.position = keyZone.transform.position;
    }
}
