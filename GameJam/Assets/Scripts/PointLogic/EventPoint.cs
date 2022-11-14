using DG.Tweening;
using UnityEngine;

public class EventPoint : MonoBehaviour
{
    [SerializeField] string _textPoint;
    [SerializeField] EventPoint _nexStep;
    [SerializeField] ParticleSystem _question;
    [SerializeField] Sprite _face;

    private bool _state;
    public bool state => _state;


    private void OnTriggerEnter(Collider other)
    {
        if (_state)
            if (other.attachedRigidbody.GetComponent<PlayerControls>())
                ShowTextUI();
    }

    public virtual void ShowTextUI()
    {
        UILogicPoint.Instance.ShowText(_textPoint, gameObject, _face);

        if (_nexStep != null)
            _nexStep.StateOn();
        else
            Debug.Log("No next points");
    }

    public void StateOn()
    {
        _state = true;

        _question.Play();
    }
}
