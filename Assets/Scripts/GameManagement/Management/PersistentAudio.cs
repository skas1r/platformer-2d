using UnityEngine;

public class PersistentAudio : MonoBehaviour
{
    private static PersistentAudio instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Може бути лише одна фонова доріжка,
            // що не знищується при переході на
            // іншу сцену
            Destroy(gameObject);
        }
    }
}