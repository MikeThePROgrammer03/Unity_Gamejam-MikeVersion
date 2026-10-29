using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class RangoVisual : MonoBehaviour
{
    [SerializeField] private EnemyScript enemigo;
    [SerializeField] private Color color = Color.red;
    [SerializeField] private float grosor = 0.1f;
    [SerializeField] private float alturaSobreSuelo = 0.05f;
    [SerializeField] private int segmentos = 40;

    private LineRenderer linea;

    void Awake()
    {

        linea = GetComponent<LineRenderer>();
        linea.loop = true;
        linea.useWorldSpace = true;
        linea.positionCount = segmentos;
        linea.startWidth = grosor;
        linea.endWidth = grosor;
        linea.material = new Material(Shader.Find("Sprites/Default"));
        linea.startColor = color;
        linea.endColor = color;
    }

    void LateUpdate()
    {
        Vector3 centro = enemigo.enemy.transform.position;

        for (int i = 0; i < segmentos; i++)
        {
            float angulo = i * Mathf.PI * 2f / segmentos;
            Vector3 punto = centro + new Vector3(Mathf.Cos(angulo), 0, Mathf.Sin(angulo)) * enemigo.Rango;
            punto.y = centro.y + alturaSobreSuelo;
            linea.SetPosition(i, punto);
        }
    }
}
