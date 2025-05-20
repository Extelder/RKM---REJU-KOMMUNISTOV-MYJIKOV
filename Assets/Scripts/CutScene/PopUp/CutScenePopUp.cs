using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CutScenePopUp : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMesh;

    private string _text;
    private float _rate;

    private bool _durationSetted;


    public void SetDuration(float duration)
    {
        _rate = duration / _text.Length;
        _durationSetted = true;
    }

    public void ShowPopUp(string text)
    {
        StopAllCoroutines();

        _textMesh.text = "";
        _durationSetted = false;
        _text = text;

        StartCoroutine(ShowingPopUp());
    }

    public void ClearPopUp()
    {
        StopAllCoroutines();
        _textMesh.text = "";
        _durationSetted = false;
    }

    private IEnumerator ShowingPopUp()
    {
        yield return new WaitUntil(() => _durationSetted);
        for (int i = 0; i < _text.Length; i++)
        {
            _textMesh.text += _text[i];
            yield return new WaitForSeconds(_rate);
        }
    }
}