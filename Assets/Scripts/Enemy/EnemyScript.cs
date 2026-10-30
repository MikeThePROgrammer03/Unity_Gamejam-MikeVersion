
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

    [Header("Sonido de pasos")]
    [SerializeField] private AudioSource audioPasos;

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

        if (audioPasos != null)
        {
            audioPasos.playOnAwake = false;
            audioPasos.loop = true;
            audioPasos.Stop();
        }
    }

    private void Update()
    {
        Distancia = Vector3.Distance(
            enemy.transform.position,
            Objetivo.position
        );

        // El sacerdote solamente detecta al fantasma
        // cuando está cerca y se está moviendo.
        if (Distancia < Rango)
        {
            Perseguir = playerController.GetVelocity() > 0.1f;
        }
        else if (Distancia > Rango + 1 ||
                 playerController.GetVelocity() < 0.1f)
        {
            Perseguir = false;
        }

        if (Perseguir)
        {
            patrullando = false;
            enemy.speed = velocidad;
            enemy.SetDestination(Objetivo.position);

            if (Distancia < RangoKill)
            {
                SceneManager.LoadScene(2);
            }
        }
        else
        {
            Patrullar();
        }

        // Reproducir pasos según el movimiento.
        ReproducirPasos();
    }

    private void ReproducirPasos()
    {
        if (audioPasos == null)
            return;

        bool caminando = enemy.velocity.magnitude > 0.15f;

        if (caminando)
        {
            // Acelera el audio durante la persecución.
            audioPasos.pitch = Perseguir ? 1.3f : 1f;

            if (!audioPasos.isPlaying)
            {
                audioPasos.Play();
            }
        }
        else
        {
            if (audioPasos.isPlaying)
            {
                audioPasos.Stop();
            }
        }
    }

    private void Patrullar()
    {
        enemy.speed = velocidadPatrulla;

        if (!patrullando)
        {
            patrullando = true;
            NuevoDestino();
            return;
        }

        if (!enemy.pathPending &&
            enemy.remainingDistance <= enemy.stoppingDistance)
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

        Vector3 puntoRandom =
            puntoInicial +
            Random.insideUnitSphere * radioPatrulla;

        if (NavMesh.SamplePosition(
            puntoRandom,
            out NavMeshHit hit,
            radioPatrulla,
            NavMesh.AllAreas))
        {
            enemy.SetDestination(hit.position);
        }
    }

    private void OnDrawGizmos()
    {
        if (enemy == null)
            return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(
            enemy.transform.position,
            Rango
        );

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(
            enemy.transform.position,
            radioPatrulla
        );
    }
}
