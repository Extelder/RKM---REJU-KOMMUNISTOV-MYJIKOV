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
    [SerializeField] private GameObject _bell;

    [field: SerializeField] public Camera Camera { get; private set; }
    [SerializeField] private LayerMask _mask;
    [SerializeField] private float _range;
    [SerializeField] private float _dragSpeed;
    [SerializeField] private Vector3 _dragOffset;

    private DragAndDropObject _currentDragAndDropObject;

    [field: SerializeField] public static Vector3 DragPosition { get; private set; }

    private CompositeDisposable _disposable = new CompositeDisposable();

    public KPPCharacter Character { get; set; }

    public static PlayerDragAndDrop Instance { get; private set; }

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            return;
        }

        Debug.LogError("There`s one more PlayerDragAndDrop");
        Debug.Break();
    }

    private void Start()
    {
        _bell.GetComponent<Collider>().enabled = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(Camera.ScreenPointToRay(Input.mousePosition));
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
        Ray ray = Camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, _range, _mask))
        {
            if (!hit.collider.TryGetComponent<DragAndDropBarrier>(out DragAndDropBarrier DragAndDropBarrier))
                DragPosition = hit.point + _dragOffset;
        }
    }
}