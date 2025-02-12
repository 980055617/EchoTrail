using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionView : MonoBehaviour
{
    private void Start()
    {
        
    }

    public void PlaySE(string objectName)
    {
        switch (objectName)
        {
            case "3C":
                SoundManager.Instance.PlaySE(SoundManager.SEData.SETYPE.EnemyDash);
                break;
            case "3D":
                SoundManager.Instance.PlaySE(SoundManager.SEData.SETYPE.Button);
                break;
            default:
                Debug.Log("対応するSEがありません: " + objectName);
                break;
        }
    }
}
