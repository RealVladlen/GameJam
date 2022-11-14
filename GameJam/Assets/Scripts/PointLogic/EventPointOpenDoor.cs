using UnityEngine;

public class EventPointOpenDoor : EventPoint
{
    [SerializeField] Transform _door;
    public override void ShowTextUI()
    {
        base.ShowTextUI();

        Invoke(nameof(OpenDoor), 0.5f);
    }

    private void OpenDoor()
    {
        _door.rotation = Quaternion.identity;
    }
}
