using UnityEngine;
using UnityEngine.UI;

public class InventaryUI : MonoBehaviour
{
    [SerializeField] private Transform panel;
    [SerializeField] private Transform panel2;
    [SerializeField] private GameObject slotPrefab;
    private Color32 selectedColor = new Color32(200, 200, 200, 255); // yellow color for selected icon
    private Color32 defaultColor = new Color32(87, 87, 87, 255); // white color for unselected icons

    public void AgregarIcono(ItemData item)
    {
        CrearSlot(item, panel);
        CrearSlot(item, panel2);
    }

    private void CrearSlot(ItemData item, Transform destino)
    {
        GameObject slot = Instantiate(slotPrefab, destino);
        slot.name = item.nombre;
        slot.transform.GetChild(0).GetComponent<Image>().sprite = item.icono;
    }
    public void SeleccionarIcono(string itemName)
    {
        foreach (Transform slot in panel)
        {
            if (slot.name == itemName)
            {
                slot.GetComponent<Image>().color = selectedColor; 
            }
            else
            {
                slot.GetComponent<Image>().color = defaultColor; 
            }
        }
    }
    public void DeleteIcono(string itemName)
    {
        foreach (Transform slot in panel)
        {
            if (slot.name == itemName)
            {
                Destroy(slot.gameObject);
                break;
            }
        }
        foreach (Transform slot in panel2)
        {
            if (slot.name == itemName)
            {
                Destroy(slot.gameObject);
                break;
            }
        }
    }
}
