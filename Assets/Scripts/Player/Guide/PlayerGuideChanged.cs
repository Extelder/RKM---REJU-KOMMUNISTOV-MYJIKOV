using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class PlayerGuideChanged : MonoBehaviour
{
    [SerializeField] private string[] _hints;
    [SerializeField] private TextMeshProUGUI _hintText;
    [SerializeField] private CharacterCheckWatch _characterCheckWatch;
    [SerializeField] private TwoBoneIKConstraint _twoBoneIkConstraint;
    [SerializeField] private GameObject _time;

    [SerializeField] private KeyCode _moveKode;
    [SerializeField] private KeyCode _watchKode;


    private int i = 0;
    private bool _pressed;

    private KeyCode _currentKeyCode;

    private void Start()
    {
        _characterCheckWatch.enabled = false;
        _twoBoneIkConstraint.weight = 1;
        _time.SetActive(false);

        StartCoroutine(Guiding());
    }

    private void Update()
    {
        if (Input.GetKeyDown(_currentKeyCode))
        {
            _pressed = true;
        }
        else
        {
            _pressed = false;
        }
    }

    private IEnumerator Guiding()
    {
        _hintText.text = _hints[i];
        i++;
        PlayerPrefs.SetInt("GuideCompleate", 1);

        _currentKeyCode = _watchKode;
        yield return new WaitUntil(() => _pressed == true);
        _currentKeyCode = _moveKode;
        yield return new WaitForSeconds(0.3f);
        _hintText.text = _hints[i];
        yield return new WaitForSeconds(0.3f);
        yield return new WaitUntil(() => _pressed == true);
        yield return new WaitForSeconds(0.3f);
        _characterCheckWatch.enabled = true;
        _time.SetActive(true);

        _hintText.text = "";
    }
}