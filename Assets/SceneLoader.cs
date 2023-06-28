using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    public static void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    private string sceneName = "";
    public Vector3? checkpoint = null;

    private void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoad;
        sceneName = SceneManager.GetActiveScene().name;
    }
    private void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == sceneName)
        {
            if (checkpoint != null)
            {
                GameObject.FindWithTag("Player").transform.position = (Vector3) checkpoint;
            }
        }
        else
        {
            checkpoint = null;
            sceneName = scene.name;
        }
    }
}
