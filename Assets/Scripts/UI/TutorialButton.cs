using UnityEngine;

public class TutorialButton : MonoBehaviour
{
    [Header("Botones del menú principal")]
    [SerializeField] private GameObject botonPlay;
    [SerializeField] private GameObject botonTutorial;
    [SerializeField] private GameObject botonExit;

    [Header("Pantalla del tutorial")]
    [SerializeField] private GameObject tutorial;

    public void AbrirInstrucciones()
    {
        botonPlay.SetActive(false);
        botonTutorial.SetActive(false);
        botonExit.SetActive(false);

        tutorial.SetActive(true);
    }

    public void RegresarMenu()
    {
        tutorial.SetActive(false);

        botonPlay.SetActive(true);
        botonTutorial.SetActive(true);
        botonExit.SetActive(true);
    }

    public void SalirJuego()
    {
        Application.Quit();
    }
}
