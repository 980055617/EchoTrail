using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField]
    PlayerCollisionPresenter _playerCollisionPresenter;

    SoundManager.SEData.SETYPE se;
    
    void OnCollisionEnter(Collision collision)
    {
        var seName = collision.gameObject.GetComponent<ObjectModel>().instrument_seName;
        se = (SoundManager.SEData.SETYPE)Enum.Parse(typeof(SoundManager.SEData.SETYPE), "seName");
        SoundManager.Instance.PlaySE(se);
    }
}
