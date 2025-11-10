using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    InputAction moveAction;
    [SerializeField] float MoveSpeed;
    [SerializeField] float boundsPadding;
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");   
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)moveAction.ReadValue<Vector2>() * Time.deltaTime * MoveSpeed;



        ConstrainPlayer();
    }

    void ConstrainPlayer()
    {
        Vector2 minBounds = Camera.main.ViewportToWorldPoint(Vector2.zero);
        Vector2 maxBounds = Camera.main.ViewportToWorldPoint(Vector2.one);

        transform.position =
            new Vector2(
                Mathf.Clamp(transform.position.x, minBounds.x + boundsPadding, maxBounds.x - boundsPadding),
                Mathf.Clamp(transform.position.y, minBounds.y + boundsPadding, maxBounds.y - boundsPadding)
                );

    }
}
