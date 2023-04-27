using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(MoveComponent))]

/// TESTT TETSTETSETSTE TSETTES
public class PlayerMoveComponent : MonoBehaviour
{
    [SerializeField] InputAction moveAction;
    [SerializeField] float speed = 5;

    MoveComponent moveComponent;

    Vector2 direction = Vector2.zero;

    void Awake()
    {
        moveComponent = GetComponent<MoveComponent>();
    }

    private void OnEnable()
    {
        moveAction.Enable();
        moveAction.performed += (InputAction.CallbackContext context) => direction = context.ReadValue<Vector2>();
        moveAction.canceled += _ => direction = Vector2.zero;
    }

    private void OnDisable()
    {
        moveAction.Disable();
        moveAction.performed -= (InputAction.CallbackContext context) => direction = context.ReadValue<Vector2>();
        moveAction.canceled -= _ => direction = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        moveComponent.Move(direction, speed);
    }
}
