using UnityEngine;

public class ContainerPointForMove : MonoBehaviour
{
    [SerializeField] public GameObject container;

    private void OnTriggerStay(Collider other)
    {
        if (container == null)
        {
            if (other.CompareTag("Hero"))
            {
                container = other.gameObject;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (container != null)
        {
            container = null;
        }
    }
}
