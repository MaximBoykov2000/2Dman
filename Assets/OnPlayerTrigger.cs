using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnPlayerTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent playerEnterEvent;
    [SerializeField] private UnityEvent playerExitEvent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerEnterEvent.Invoke();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerExitEvent.Invoke();
        }
    }

}
