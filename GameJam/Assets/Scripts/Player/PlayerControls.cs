using UnityEngine;
using UnityEngine.AI;

public class PlayerControls : MonoBehaviour
{
    private Camera _camera;
    private NavMeshAgent _agent;

    private void Start()
    {
        _camera = Camera.main;
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && UILogicPoint.Instance.WindowState == false)
        {
            RaycastHit hit;
            if (Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition),out hit))
            {
                _agent.SetDestination(hit.point);
            }
        }
    }

    private void FixedUpdate()
    {
        // Debug.Log(_agent.hasPath); // Определение, есть у агента путь или нет, можно проверять через корутину для экономии проверок
    }
}
