using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    [SerializeField] private Transform jugador;

    private void LateUpdate()
    {
        if (jugador == null)
            return;

        transform.position = new Vector3(
            jugador.position.x,
            jugador.position.y,
            transform.position.z
        );
    }
}