using UnityEngine;
using UnityEngine.InputSystem;

public class MovimentInputSystem : MonoBehaviour
{

    public float velocidade = 8;
    CharacterController cc;

    InputAction inputMove;
    InputAction inputAttack;
    InputAction inputInteract;
    void Start()
    {
        cc = GetComponent<CharacterController>();
        inputMove = InputSystem.actions.FindAction("Move");
        inputAttack = InputSystem.actions.FindAction("Attack");
        inputInteract = InputSystem.actions.FindAction("Interact");
    }

    void Update()
    {
        if (inputAttack.WasPressedThisFrame())
        {
            Debug.Log("Geometry Dash");
        }

        if (inputInteract.WasPressedThisFrame())
        {
            Debug.Log("Supermarket Simulator");
        }

        Vector2 direcoes = inputMove.ReadValue<Vector2>();

        Vector3 movimento = new Vector3(direcoes.x, 0, direcoes.y);
        movimento *= velocidade * Time.deltaTime;

        cc.Move(movimento);
    }
}
//AAAAAAAAAAAAAAAaaaaaaaaaauuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuu!!!!!!!!!!!!!!!!! 