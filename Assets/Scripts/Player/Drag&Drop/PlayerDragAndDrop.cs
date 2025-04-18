using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class PlayerDragAndDrop : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private LayerMask _mask;
    [SerializeField] private float _range;
    [SerializeField] private float _dragSpeed;
    [SerializeField] private Vector3 _dragOffset;

    private DragAndDropObject _currentDragAndDropObject;

    [field: SerializeField] public static Vector3 DragPosition { get; private set; }

    private CompositeDisposable _disposable = new CompositeDisposable();

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(_camera.ScreenPointToRay(Input.mousePosition));
    }

    public void ObjectStartDragged(DragAndDropObject dragAndDropObject)
    {
        _currentDragAndDropObject = dragAndDropObject;
        Observable.EveryUpdate().Subscribe(_ =>
        {
            _currentDragAndDropObject.transform.position =
                Vector3.MoveTowards(_currentDragAndDropObject.transform.position, DragPosition,
                    _dragSpeed * Time.deltaTime);

            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                _disposable.Clear();
                _currentDragAndDropObject.DragEnded();
            }
        }).AddTo(_disposable);
    }

    private void OnDisable()
    {
        _disposable.Clear();
    }

    private void FixedUpdate()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, _range, _mask))
        {
            if (!hit.collider.TryGetComponent<DragAndDropBarrier>(out DragAndDropBarrier DragAndDropBarrier))
                DragPosition = hit.point + _dragOffset;
        }
    }
}