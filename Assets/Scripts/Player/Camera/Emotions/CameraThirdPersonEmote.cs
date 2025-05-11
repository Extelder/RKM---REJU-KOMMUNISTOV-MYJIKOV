using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class CameraThirdPersonEmote : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private string[] _animNames;
    [SerializeField] private CameraThirdPerson _cameraThirdPerson;
    private CompositeDisposable _disposable = new CompositeDisposable();

    public enum CustomKeys
    {
        Anim1 = KeyCode.Alpha1,
        Anim2 = KeyCode.Alpha2,
        Anim3 = KeyCode.Alpha3,
        Anim4 = KeyCode.Alpha4,
        Anim5 = KeyCode.Alpha5,
        Anim6 = KeyCode.Alpha6
    }

    private CustomKeys[] _keys = new[]
    {
        CustomKeys.Anim1,
        CustomKeys.Anim2,
        CustomKeys.Anim3,
        CustomKeys.Anim4,
        CustomKeys.Anim5,
        CustomKeys.Anim6
    };

    private void OnEnable()
    {
        _cameraThirdPerson.EnteredFirstPerson += PlayAnimations;
        _cameraThirdPerson.ExitedFirstPerson += StopAnimations;
    }

    private void PlayAnimations()
    {
        Observable.EveryUpdate().Subscribe(_ =>
        {
            for (int i = 0; i < _keys.Length; i++)
            {
                if (Input.GetKeyDown((KeyCode) _keys[i]))
                {
                    if (_keys[i] == CustomKeys.Anim5)
                    {
                        SteamAchivement.Instance.UnlockSuperman();
                    }
                        Debug.Log(_animNames[i]);
                    _animator.SetTrigger(_animNames[i]);
                    _animator.SetBool("IsAnimating", true);
                }
            }
        }).AddTo(_disposable);
    }

    private void StopAnimations()
    {
        _disposable.Clear();
        _animator.SetBool("IsAnimating", false);
    }

    private void OnDisable()
    {
        _cameraThirdPerson.EnteredFirstPerson -= PlayAnimations;
        _cameraThirdPerson.ExitedFirstPerson -= StopAnimations;
        _disposable.Clear();
    }
}