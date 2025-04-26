using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class Loading : MonoBehaviour
{
    [SerializeField] private GameObject _pressKeyHint;
    [SerializeField] private Ease _moveEase;
    [SerializeField] private GameObject _lift;
    [SerializeField] private float _moveTime;
    [SerializeField] private float _moveTimeSpread;

    private int _currentSceneIndex;

    private AsyncOperation _asyncOperation;

    private Vector3 _startLiftPosition;

    private bool _animationsEnded;

    private Tween _firstMove;
    private Tween _secondMove;

    private void Start()
    {
        _startLiftPosition = _lift.transform.position;
        StopAllCoroutines();
        _currentSceneIndex = PlayerPrefs.GetInt("CurrentScene", 0);
        StartCoroutine(LoadingScene());
    }

    private IEnumerator LoadingScene()
    {
        yield return new WaitForSeconds(1f);
        _asyncOperation = SceneManager.LoadSceneAsync(_currentSceneIndex);
        _asyncOperation.allowSceneActivation = false;

        _firstMove = _lift.transform.DOMove(_startLiftPosition - _lift.transform.TransformDirection(Vector3.right) * 20,
                _moveTime - Random.Range(-_moveTimeSpread, _moveTimeSpread))
            .OnComplete(() => { StartCoroutine(WaitingForSecondMove()); })
            .SetEase(_moveEase);

        yield return new WaitUntil(() => _animationsEnded == true);
        _pressKeyHint.SetActive(true);
    }

    private IEnumerator WaitingForSecondMove()
    {
        yield return new WaitForSeconds(Random.Range(0.5f, 2));
        _secondMove = _lift.transform.DOMove(
                _startLiftPosition - _lift.transform.TransformDirection(Vector3.right) * 50,
                _moveTime - Random.Range(-_moveTimeSpread, _moveTimeSpread))
            .OnComplete(() => { _animationsEnded = true; })
            .SetEase(_moveEase);
    }

    private void Update()
    {
        if (Input.anyKeyDown && _pressKeyHint.activeSelf)
        {
            _asyncOperation.allowSceneActivation = true;
        }
    }

    private void OnDisable()
    {
        _firstMove?.Kill();
        _secondMove?.Kill();
    }
}