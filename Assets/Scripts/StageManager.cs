using UnityEngine;
using System.IO;

public class StageManager : MonoBehaviour
{
    [SerializeField] private string jsonFileName = "stageData.json";
    [SerializeField] private string prefabPath = "Cubes/Prefabs/";

    private void Start()
    {
        LoadAndCreateStage(1);
    }

    public void LoadAndCreateStage(int stageID)
    {
        // MapDataフォルダからJSONを読み込む場合
        string jsonPath = Path.Combine(Application.dataPath, "MapData", jsonFileName);

        string jsonContent = File.ReadAllText(jsonPath);
        
        // JSONをパース
        StageData stageData = JsonUtility.FromJson<StageData>(jsonContent);
        
        // 指定されたステージIDのステージを探す
        Stage targetStage = stageData.stages.Find(s => s.stageID == stageID);
        if (targetStage == null) return;

        // ステージ内の各ポイントについて処理
        foreach (var point in targetStage.points)
        {
            CreateInstrument(point);
        }
    }

    private void CreateInstrument(Point point)
    {
        // デバッグログを追加
        Debug.Log($"Trying to load prefab: {prefabPath + point.instrument.name}");

        // Prefabをロード
        GameObject prefab = Resources.Load<GameObject>(prefabPath + point.instrument.name);
        if (prefab == null)
        {
            Debug.LogError($"Prefab not found: {point.instrument.name}");
            Debug.LogError($"Full path attempted: Resources/{prefabPath + point.instrument.name}");
            return;
        }

        // Prefabをインスタンス化
        Vector3 position = new Vector3(
            point.position.x,
            point.position.y,
            point.position.z
        );
        
        Vector3 rotation = new Vector3(
            point.instrument.rotation.x,
            point.instrument.rotation.y,
            point.instrument.rotation.z
        );

        GameObject instance = Instantiate(
            prefab,
            position,
            Quaternion.Euler(rotation)
        );

        // タグの代わりにBounceSettingsを使用
        if (!string.IsNullOrEmpty(point.instrument.BouncePower))
        {
            var bounceSettings = instance.AddComponent<BounceSettings>();
            float bounceForce = GetBounceForce(point.instrument.BouncePower);
            bounceSettings.SetBounceForce(bounceForce);
        }

        // SEを設定
        if (!string.IsNullOrEmpty(point.instrument.SEName))
        {
            var audioSource = instance.GetComponent<AudioSource>();
            if (audioSource != null)
            {
                // SEをロードして設定
                AudioClip se = Resources.Load<AudioClip>("SE/" + point.instrument.SEName);
                if (se != null)
                {
                    audioSource.clip = se;
                }
            }
        }

        // 楽器の音程を設定（必要な場合）
        // if (!string.IsNullOrEmpty(point.instrument.pitch))
        // {
        //     var instrumentComponent = instance.GetComponent<InstrumentController>(); // 仮の楽器コンポーネント
        //     if (instrumentComponent != null)
        //     {
        //         instrumentComponent.SetPitch(point.instrument.pitch);
        //     }
        // }
    }

    private float GetBounceForce(string bouncePowerType)
    {
        // 文字列から跳ね返り力の値に変換
        return bouncePowerType switch
        {
            "NoBounce" => 0f,
            "LowBounce" => 5f,
            "MediumBounce" => 7.5f,
            "HighBounce" => 10f,
            "SuperBounce" => 15f,
            _ => 5f // デフォルト値
        };
    }
} 