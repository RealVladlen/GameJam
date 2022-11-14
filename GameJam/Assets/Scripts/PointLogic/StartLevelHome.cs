using System.Collections;
using UnityEngine;

public class StartLevelHome : MonoBehaviour
{
    [SerializeField] string _text;
    [SerializeField] EventPoint _eventPoint;

    private void Start()
    {
        StartCoroutine(StartShow());
    }

    IEnumerator StartShow()
    {
        yield return new WaitForSeconds(1);
        ShowStartText();
    }

    private void ShowStartText()
    {
        UILogicPoint.Instance.ShowText(_text);
        _eventPoint.StateOn();
    }
}
