using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private string _gameSceneName = "GameScene";

        public void OnPlayButton()
        {
            if (!string.IsNullOrEmpty(_gameSceneName))
            {
                SceneManager.LoadScene(_gameSceneName);
            }
            else
            {
                Debug.LogWarning("Game Scene not found");
            }
        }

        public void OnExitButton()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}