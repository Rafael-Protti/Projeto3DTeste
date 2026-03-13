using Cinemachine;
using UnityEditor.UIElements;
using UnityEngine;

public class CollisionCallBack : MonoBehaviour
{
    [TagField] public string tag;
    public System.Action callback;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(tag))
        {
            callback?.Invoke();
        }
    }
}
