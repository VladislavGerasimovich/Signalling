using UnityEngine;

public class FreeWayChecker : MonoBehaviour
{
    [SerializeField] private Alarm _alarm;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _alarm.Play();
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        _alarm.Stop();
    }
}