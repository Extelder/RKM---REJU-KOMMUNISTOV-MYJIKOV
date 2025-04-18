using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class PlayerDragAndDrop : MonoBehaviour
{
    [SerializeField] private Texture2D _grabCursor;
    [SerializeField] private Texture2D _tryGrabCursor;
    [SerializeField] private Texture2D _defaultCursor;

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

    public void ObjectEntered(DragAndDropObject dragAndDropObject)
    {
        if (dragAndDropObject != _currentDragAndDropObject)
            Cursor.SetCursor(_tryGrabCursor, Vector2.zero, CursorMode.Auto);
    }

    public void ObjectExited(DragAndDropObject dragAndDropObject)
    {
        if (dragAndDropObject != _currentDragAndDropObject)
            Cursor.SetCursor(_defaultCursor, Vector2.zero, CursorMode.Auto);
    }

    public void ObjectStartDragged(DragAndDropObject dragAndDropObject)
    {
        Cursor.SetCursor(_grabCursor, Vector2.zero, CursorMode.Auto);
        _currentDragAndDropObject = dragAndDropObject;
        Observable.EveryUpdate().Subscribe(_ =>
        {
            _currentDragAndDropObject.transform.position =
                Vector3.MoveTowards(_currentDragAndDropObject.transform.position, DragPosition,
                    _dragSpeed * Time.deltaTime);

            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                Cursor.SetCursor(_defaultCursor, Vector2.zero, CursorMode.Auto);
                _currentDragAndDropObject.DragEnded();
                _currentDragAndDropObject = null;
                _disposable.Clear();
            }
        }).AddTo(_disposable);
    }

    private void OnDisable()
    {
        Cursor.SetCursor(_defaultCursor, Vector2.zero, CursorMode.Auto);
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