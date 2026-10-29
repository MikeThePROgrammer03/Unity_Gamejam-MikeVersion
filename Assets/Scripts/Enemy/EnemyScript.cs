using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyScript : MonoBehaviour
{
    public NavMeshAgent enemy;
    public float velocidad;
    public bool Perseguir;
    public float Rango;
    public float RangoKill;
    float Distancia;
    public Transform Objetivo;
    [SerializeField] private PlayerController playerController;

    [Header("Patrullaje")]
    public float velocidadPatrulla = 2f;
    public float radioPatrulla = 10f;
    public float tiempoEspera = 2f;
    private Vector3 puntoInicial;
    private float temporizador;
    private bool patrullando;

    private void Start()
    {
        puntoInicial = enemy.transform.position;
    }

    private void Update()
    {
        Distancia = Vector3.Distance(enemy.transform.position, Objetivo.position);

        if (Distancia < Rango)
        {
            Perseguir = playerController.GetVelocity() > 0.1f;
        }
        else if (Distancia > Rango + 1 || playerController.GetVelocity() < 0.1f)
        {
            Perseguir = false;
        }

        if (Perseguir)
        {
            patrullando = false;
            enemy.speed = velocidad;
            enemy.SetDestination(Objetivo.position);
            if(Distancia < RangoKill)
            {
                SceneManager.LoadScene(1);
            }
        }
        else
        {
            Patrullar();
        }
    }

    private void Patrullar()
    {
        enemy.speed = velocidadPatrulla;

        // Primera vez que entra a patrullar: elige un destino de inmediato
        if (!patrullando)
        {
            patrullando = true;
            NuevoDestino();
            return;
        }

        // Si llegó al destino, espera y elige otro
        if (!enemy.pathPending && enemy.remainingDistance <= enemy.stoppingDistance)
        {
            temporizador += Time.deltaTime;
            if (temporizador >= tiempoEspera)
            {
                NuevoDestino();
            }
        }
    }

    private void NuevoDestino()
    {
        temporizador = 0;
        Vector3 puntoRandom = puntoInicial + Random.insideUnitSphere * radioPatrulla;

        if (NavMesh.SamplePosition(puntoRandom, out NavMeshHit hit, radioPatrulla, NavMesh.AllAreas))
        {
            enemy.SetDestination(hit.position);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(enemy.transform.position, Rango);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(enemy.transform.position, radioPatrulla);
    }
}