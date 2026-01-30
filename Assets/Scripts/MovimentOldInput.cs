using UnityEngine;

public class MovimentOldInput : MonoBehaviour
{
    public float velocidade = 8;
    CharacterController cc;
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        float vertical = Input.GetAxis("Vertical");

        Vector3 movimento = new Vector3(horizontal, 0, vertical);
        movimento *= velocidade * Time.deltaTime;

        cc.Move(movimento);
    }
}
