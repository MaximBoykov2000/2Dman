using UnityEngine;


public class Checkpoint : MonoBehaviour
{
    [SerializeField] private Transform target = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            var loader = FindObjectOfType<SceneLoader>();
            if (loader)
            {
                loader.checkpoint = target.position;
            }
        }
    }
}
