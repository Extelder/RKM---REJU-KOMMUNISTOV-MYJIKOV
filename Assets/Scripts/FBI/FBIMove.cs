using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.AI;

public class FBIMove : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private Transform _target;
    [SerializeField] private Animator _animator;

    private CompositeDisposable _disposable = new CompositeDisposable();
    
    public void MoveToDestination()
    {
        Observable.EveryUpdate().Subscribe(_ =>
        {
            _navMeshAgent.SetDestination(_target.position);
            if (_navMeshAgent.remainingDistance <= 0.5f)
            {
                
            }
        }).AddTo(_disposable);
    }

    private void OnDisable()
    {
        _disposable.Clear();
    }
}
