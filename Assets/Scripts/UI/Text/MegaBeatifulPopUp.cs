using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MegaBeatifulPopUp : MonoBehaviour
{
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip[] _audioClips;
    public IEnumerator EbanutiString(string popUp, TextMeshProUGUI text, float cooldown)
    { 
        text.gameObject.SetActive(true);
        for (int i = 0; i < popUp.Length; i++)
        {
            char letter = popUp[i];
            yield return new WaitForSeconds(cooldown);
            text.text += letter;
            _source.clip = _audioClips[Random.Range(0, _audioClips.Length)];
            _source.Play();
        }
        yield return new WaitForSeconds(1);
        text.gameObject.SetActive(false);
    }
}
