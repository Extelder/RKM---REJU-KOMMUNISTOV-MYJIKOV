using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class KrakenHealth : Health
{
    [SerializeField] private Animator _krakenAnimator;
    [SerializeField] private SoundSilenceVolume _soundSilenceVolume;
    
    public override void Death()
    {
        _krakenAnimator.SetTrigger("Dead");
        _soundSilenceVolume.SilenceVolume();
    }
}
