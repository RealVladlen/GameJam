using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] Transform _target;
    [SerializeField] float _lerpRate;
    [SerializeField] float sensitivity = 3;
    [SerializeField] Vector3 _offset;

    private float Y;

    void Update()
    {
        if (Input.GetMouseButton(1) && !UILogicPoint.Instance.WindowState)
        {
            Y += Input.GetAxis("Mouse X") * sensitivity;
            transform.localEulerAngles = new Vector3(0, Y, 0);
        }
    }

    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, _target.position, Time.deltaTime * _lerpRate);
    }
}
