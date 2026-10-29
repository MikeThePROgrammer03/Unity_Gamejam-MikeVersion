using UnityEngine;

[CreateAssetMenu(fileName = "NuevoItem", menuName = "Inventary/Item")]
public class ItemData : ScriptableObject
{
    public string nombre;
    public Sprite icono;
}