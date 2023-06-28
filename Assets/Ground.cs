using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField] private bool isGrounded = false;
    public bool IsGrounded() => isGrounded;

    private Collider2D grounCollider = null;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (grounCollider == null)
        {
            grounCollider = collision.collider;
            isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (grounCollider == collision.collider)
        {
            grounCollider = null;
            isGrounded = false;
        }
    }
}
