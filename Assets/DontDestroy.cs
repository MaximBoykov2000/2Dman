using UnityEngine;


public class DontDestroy : MonoBehaviour
{
    private static GameObject savedObject = null;

    void Awake()
    {
        if (savedObject)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            savedObject = gameObject;
        }
    }
}
