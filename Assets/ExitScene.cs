using UnityEngine;


public class ExitScene : MonoBehaviour
{
    [SerializeField] private string targetSceneName = "";
    [SerializeField] private float reloadTime = 0.5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Invoke("Reload", reloadTime);
        }
    }

    private void Reload()
    {
        SceneLoader.LoadScene(targetSceneName);
    }
}
