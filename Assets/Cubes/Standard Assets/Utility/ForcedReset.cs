using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class ForcedReset : MonoBehaviour
{
    private void Update()
    {
        // "ResetObject" ボタンが押されたらシーンをリセット
        if (CrossPlatformInputManager.GetButtonDown("ResetObject"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
