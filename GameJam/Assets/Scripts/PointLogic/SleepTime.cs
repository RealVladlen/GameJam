using UnityEngine;

public class SleepTime : MonoBehaviour
{
    [SerializeField] EventPoint _eventPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (_eventPoint.state)
            if (other.attachedRigidbody.GetComponent<PlayerControls>())
                Fade.Instance.HideFade();
    }
}
