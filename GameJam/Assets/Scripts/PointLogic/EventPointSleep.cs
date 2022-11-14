using UnityEngine;

public class EventPointSleep : EventPoint
{
    [SerializeField] GameObject _bear;
    [SerializeField] Transform _door;

    public override void ShowTextUI()
    {
        base.ShowTextUI();

        Invoke(nameof(SetActiveVear), 0.5f);
    }

    private void SetActiveVear()
    {
        _bear.SetActive(false);
    }

}
