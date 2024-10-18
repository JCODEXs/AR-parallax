using UnityEngine;
using Vuforia;

public class ARGoalManager : MonoBehaviour
{
    [Tooltip("The greeting prompt Game Object to show when onboarding begins.")]
    [SerializeField]
    GameObject m_GreetingPrompt;

    [Tooltip("The Vuforia Behaviour component responsible for handling AR functionality.")]
    [SerializeField]
    VuforiaBehaviour m_VuforiaBehaviour;

    [Tooltip("Audio Source to play when the image target is detected.")]
    [SerializeField]
    AudioSource m_AudioSource;

    private ObserverBehaviour m_ObserverBehaviour;

    void Start()
    {
        // Asegurarse de que Vuforia está desactivado inicialmente.
        if (m_VuforiaBehaviour != null)
        {
            m_VuforiaBehaviour.enabled = false;
        }

        // Obtener el comportamiento de rastreo de la imagen objetivo (ObserverBehaviour).
        m_ObserverBehaviour = GetComponent<ObserverBehaviour>();
        if (m_ObserverBehaviour != null)
        {
            // Suscribirse al evento de cambio de estado de rastreo.
            m_ObserverBehaviour.OnTargetStatusChanged += OnTargetStatusChanged;
        }

        // Asegurarse de que el AudioSource está listo, pero sin reproducir al inicio.
        if (m_AudioSource != null)
        {
            m_AudioSource.playOnAwake = false;
        }
    }

    /// <summary>
    /// Oculta el saludo y activa el modo AR.
    /// </summary>
    public void DismissGreeting()
    {
        // Ocultar el saludo
        if (m_GreetingPrompt != null)
        {
            m_GreetingPrompt.SetActive(false);
        }

        // Activar Vuforia para la detección AR.
        if (m_VuforiaBehaviour != null)
        {
            m_VuforiaBehaviour.enabled = true;
            Debug.Log("Vuforia AR Mode Activated");
        }
    }

    /// <summary>
    /// Método del evento cuando cambia el estado de rastreo de la imagen objetivo.
    /// </summary>
    /// <param name="behaviour">Comportamiento del observador (imagen objetivo).</param>
    /// <param name="status">Nuevo estado del rastreo.</param>
    private void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus status)
    {
        if (status.Status == Status.TRACKED || status.Status == Status.EXTENDED_TRACKED)
        {
            // Imagen detectada y rastreada: reproducir el audio.
            if (m_AudioSource != null && !m_AudioSource.isPlaying)
            {
                m_AudioSource.Play();
                Debug.Log("Image detected - Playing audio.");
            }
        }
        else
        {
            // Imagen no detectada: detener el audio.
            if (m_AudioSource != null && m_AudioSource.isPlaying)
            {
                m_AudioSource.Stop();
                Debug.Log("Image lost - Stopping audio.");
            }
        }
    }

    private void OnDestroy()
    {
        // Asegurarse de desuscribirse del evento cuando el objeto sea destruido.
        if (m_ObserverBehaviour != null)
        {
            m_ObserverBehaviour.OnTargetStatusChanged -= OnTargetStatusChanged;
        }
    }
}
