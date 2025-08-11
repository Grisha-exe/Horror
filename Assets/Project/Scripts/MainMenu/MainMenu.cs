using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Project.Scripts.MainMenu
{
    public class MainMenu : MonoBehaviour

    {
        [SerializeField] private string _gameSceneName = "GameScene";

        public void OnPlayButton()
        {
            if (!string.IsNullOrEmpty(_gameSceneName))
            {
                SceneManager.LoadScene(_gameSceneName);
                return;
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