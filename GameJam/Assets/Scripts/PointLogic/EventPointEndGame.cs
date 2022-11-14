public class EventPointEndGame : EventPoint
{
    public override void ShowTextUI()
    {
        base.ShowTextUI();

        Invoke(nameof(MainMenu), 0.5f);
    }

    private void MainMenu()
    {
        UILogicPoint.Instance._endGameState = true;
    }
}
