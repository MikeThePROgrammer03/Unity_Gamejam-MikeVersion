using System.Collections;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] private float anguloAbierta = 90f;
    [SerializeField] private float velocidad = 2f;

    private bool abierta;

    public void Abrir()
    {
        if (abierta) return;
        abierta = true;
        StartCoroutine(AbrirPuerta());
    }

    private IEnumerator AbrirPuerta()
    {
        Quaternion inicio = transform.localRotation;
        Quaternion destino = inicio * Quaternion.Euler(0, 0, anguloAbierta);
        float t = 0;

        while (t < 1)
        {
            t += Time.deltaTime * velocidad;
            transform.localRotation = Quaternion.Lerp(inicio, destino, t);
            yield return null;
        }

        transform.localRotation = destino;
    }
}
