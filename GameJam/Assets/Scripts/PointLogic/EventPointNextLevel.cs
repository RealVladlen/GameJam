public class EventPointNextLevel : EventPoint
{
    public override void ShowTextUI()
    {
        base.ShowTextUI();

        Invoke(nameof(NextLevel), 0.5f);
        //Fade.Instance.HideFade();
    }

    private void NextLevel()
    {
        UILogicPoint.Instance._endLevelState = true;
    }
}
