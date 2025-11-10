using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    InputAction moveAction;
    [SerializeField] float MoveSpeed;
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");   
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)moveAction.ReadValue<Vector2>() * Time.deltaTime * MoveSpeed;
    }
}
