using UnityEngine;
using UnityEngine.Events;

public class FreeWayChecker : MonoBehaviour
{
    [SerializeField] private UnityEvent _entered;
    [SerializeField] private UnityEvent _exited;

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.TryGetComponent<Player>(out Player player))
        {
            _entered?.Invoke();
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        _exited?.Invoke();
    }
}