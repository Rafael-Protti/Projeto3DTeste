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
    }

    void Update()
    {

        Vector2 direcoes = MovimentEvent.instancia.movimento;

        Vector3 movimento = new Vector3(direcoes.x, 0, direcoes.y);
        movimento *= velocidade * Time.deltaTime;

        cc.Move(movimento);
    }
}
//AAAAAAAAAAAAAAAaaaaaaaaaauuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuu!!!!!!!!!!!!!!!!! 