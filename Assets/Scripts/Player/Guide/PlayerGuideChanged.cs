using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerGuideChanged : MonoBehaviour
{
    [SerializeField] private string[] _hints;
    [SerializeField] private TextMeshProUGUI _hintText;

    [SerializeField] private KeyCode _moveKode;
    [SerializeField] private KeyCode _watchKode;


    private int i = 0;
    private bool _pressed;

    private KeyCode _currentKeyCode;

    private void Start()
    {
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

        _currentKeyCode = _moveKode;
        yield return new WaitUntil(() => _pressed == true);
        _currentKeyCode = _watchKode;
        yield return new WaitForSeconds(1);
        _hintText.text = _hints[i];
        yield return new WaitUntil(() => _pressed == true);
        _hintText.text = "Пройдите в красную дверь чтобы закончить!";
    }
}