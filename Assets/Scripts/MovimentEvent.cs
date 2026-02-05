using UnityEngine;
using UnityEngine.InputSystem;

public class MovimentEvent : MonoBehaviour
{

    public Vector2 movimento;
    InputAction inputMove;

    bool isMobile = false;

    public static MovimentEvent instancia;
    private void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        isMobile = Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer;
        inputMove = InputSystem.actions.FindAction("Move");
    }

    void Update()
    {
        if (isMobile)
        {
            movimento = FloatingJoystick.instancia.Direction;
        }

        else
        {
            movimento = inputMove.ReadValue<Vector2>();
        }
    }

    public void OnMove() //O nome após "On" precisa ser o exato mesmo nome do mapeamento do Input. "Move" no caso.
    {
        Debug.Log("Gustavo.");
    }
}
