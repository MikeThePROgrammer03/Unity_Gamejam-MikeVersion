using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [Tooltip("Arrastra aquí el objeto 'screamer'")]
    public VideoPlayer screamer;

    [Tooltip("Índice de la escena en Build Settings")]
    public int numeroEscena = 0;

    void Start()
    {
        // Si no lo arrastras, intenta tomarlo del mismo objeto
        if (screamer == null)
            screamer = GetComponent<VideoPlayer>();

        screamer.loopPointReached += AlTerminarVideo;
    }

    void AlTerminarVideo(VideoPlayer vp)
    {
        SceneManager.LoadScene(numeroEscena);
    }

    void OnDestroy()
    {
        if (screamer != null)
            screamer.loopPointReached -= AlTerminarVideo;
    }
}