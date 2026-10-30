using UnityEngine;
using UnityEngine.Video;

public class PlayButton : MonoBehaviour
{
    [Tooltip("Arrastra aquí el objeto con el Video Player")]
    public VideoPlayer video;

    [Tooltip("Opcional: objeto que muestra el video (RawImage, etc.)")]
    public GameObject pantallaVideo;
    [SerializeField] private GameObject Pantalla; 
    [SerializeField] private GameObject Script; 

    void Start()
    {
        if (video != null)
            video.playOnAwake = false;

        if (pantallaVideo != null)
            pantallaVideo.SetActive(false);
    }

    // Llama a este método desde el botón Play
    public void Reproducir()
    {
        if (pantallaVideo != null)
            pantallaVideo.SetActive(true);

        video.Play();
        Pantalla.SetActive(false); 
        Script.SetActive(true); 
    }
}