using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [SerializeField] AudioSource _bgmAudioSource;
    [SerializeField] AudioSource _seAudioSource;
    [SerializeField] List<BGMData> _bgmSoundDatas;
    [SerializeField] List<SEData> _seSoundDatas;

    BGMData _currentBGM;

    [Range(0, 1)] public float masterVolume = 1;
    [Range(0, 1)] public float bgmMasterVolume = 1;
    [Range(0, 1)] public float seMasterVolume = 1;

    /// <summary>
    /// BGMを流すメソッド
    /// </summary>
    /// <param name="bgm">呼びたいBGM</param>
    public void PlayBGM(BGMData.BGMTYPE bgm)
    {
        BGMData data = _bgmSoundDatas.Find(data => data.bgm == bgm);
        _bgmAudioSource.clip = data.audioClip;
        _bgmAudioSource.volume = data.volume * bgmMasterVolume * masterVolume;
        _bgmAudioSource.loop = true;
        _bgmAudioSource.Play();
        _currentBGM = data;
    }

    public void StopBGM()
    {
        _bgmAudioSource.Stop();
    }


    /// <summary>
    /// 音量調整
    /// </summary>
    public void AdjustmentBGM()
    {
        _bgmAudioSource.volume = _currentBGM.volume * bgmMasterVolume * masterVolume;
    }

    /// <summary>
    /// SEを流すメソッド
    /// </summary>
    /// <param name="se"></param>
    public void PlaySE(SEData.SETYPE se)
    {
        SEData data = _seSoundDatas.Find(data => data.se == se);
        _seAudioSource.volume = data.volume * seMasterVolume * masterVolume;
        _seAudioSource.PlayOneShot(data.audioClip);
    }

    [System.Serializable]
    public class BGMData
    {
        public enum BGMTYPE
        {
            //ここの部分がラベルになる
            Title = 0,
            StageSelect = 1,
            Result = 2,
            IngemeNormal = 3
        }

        public BGMTYPE bgm;
        public AudioClip audioClip;
        [Range(0, 1)] public float volume = 1f;
    }

    [System.Serializable]
    public class SEData
    {
        public enum SETYPE
        {
            //ここの部分がラベルになる
            Button = 0,
            SlotMove = 1,
            UseAbility = 2,
            StartCountDown = 3,
            GameStart = 4,
            FnishCountDown = 5,
            GameFinish = 6,
            Result = 7,
            PlayerMove = 8,
            Bringback = 9,
            PickUp = 10,
            Damage = 11,
            EnemyDash = 12,
            EnemyMove = 13,
            EnemyDetection = 14,
            ButtonHover = 15,
            AttackTree = 16
        }

        public SETYPE se;
        public AudioClip audioClip;
        [Range(0, 1)] public float volume = 1f;
    }
}
