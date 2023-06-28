using UnityEngine;


public class TeleportPlayer : MonoBehaviour
{
    [SerializeField] private Transform target = null;
    public void Teleport()
    {
        GameObject.FindWithTag("Player").transform.position = target.position;
    }
}
