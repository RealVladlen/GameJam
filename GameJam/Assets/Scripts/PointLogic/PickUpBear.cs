using UnityEngine;

public class PickUpBear : MonoBehaviour
{
    [SerializeField] GameObject _firstBear, _secondBear;
    [SerializeField] EventPoint _eventPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (_eventPoint.state)
            if (other.attachedRigidbody.GetComponent<PlayerControls>())
            {
                _firstBear.SetActive(false);
                _secondBear.SetActive(true);
            }
    }
}
