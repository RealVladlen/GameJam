using UnityEngine;
using UnityEngine.AI;

public class AnimationController : MonoBehaviour
{
    private Animator _animator;
    [SerializeField] NavMeshAgent _agent;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }


    private void Update()
    {
        _animator.SetFloat("Speed", _agent.velocity.magnitude);
    }
}
