using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    public NavMeshAgent enemy;
    public float velocidad;
    public bool Perseguir;
    public float Rango;
    float Distancia;

    public Transform Objetivo;

    //[Header("Animaciones")]
    //public Animation Anim;
    //public string NombreAnimacionCaminar;
    //public string NombreAnimacionIdle;

    private void Update()
    {
        //Debug.Log("Entro al Update");
        Distancia = Vector3.Distance(enemy.transform.position, Objetivo.position);

        if (Distancia < Rango)
        {
            //Debug.Log("El enemigo debería de estar persiguiendo");
            Perseguir = true;
        }
        else if (Distancia > Rango + 3)
        {
            Perseguir = false;
        }

        if (Perseguir == false)
        {
            enemy.speed = 0;
            //Anim.CrossFade(NombreAnimacionIdle);
        }
        else if (Perseguir == true)
        {
            enemy.speed = velocidad;
            //Anim.CrossFade(NombreAnimacionCaminar);
            enemy.SetDestination(Objetivo.position);
        }
    }
    
    private void OnDrawGizmos()
    {
        //Debug.Log("Entro al Gizmos");
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(enemy.transform.position, Rango);
    }
}
