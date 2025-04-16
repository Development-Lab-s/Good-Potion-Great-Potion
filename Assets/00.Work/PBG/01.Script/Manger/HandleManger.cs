using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class HandleManger : MonoBehaviour
{
    [SerializeField] private LayerMask whatIsTarget;
    private Vector2 camPos;

    private void OnMousePosition(InputValue value)
    {
        camPos = value.Get<Vector2>();
    }

    private void OnAttack(InputValue value)
    {
        Camera cam = Camera.main;
        Vector2 raycastPos = cam.ScreenToWorldPoint(camPos);

        RaycastHit2D hit = Physics2D.Raycast(raycastPos, Vector3.forward, Mathf.Infinity, whatIsTarget);
        if (hit)
        {
            if (hit.collider.TryGetComponent(out Interactable interactable))
            {
                interactable.OnClickInteractable();
            }
        }
    }
}
