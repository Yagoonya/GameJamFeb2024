using Scripts.UI;
using Scripts.UI.Menus;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts.Model
{
    public class GameSession : MonoBehaviour
    {

        [SerializeField] private RadioMenu crutch1;
        [SerializeField] private PlayerUI UI;

        [SerializeField] private PlayerData _data;
        public PlayerData Data => _data;


        //public void Awake()
        //{
        //    if (IsSessionExit())
        //    {
        //        Destroy(gameObject);
        //    }
        //    else
        //    {
        //        DontDestroyOnLoad(this);
        //    }

        //}
        private void Start()
        {
            crutch1.Close();
        }
        public void GameOver()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("GAMEOVER");
        }
        public void GameWin()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("GAMEWIN");
        }

        public void AddSound(string song)
        {
            Data.Collection.Add(song);
            UI.UnlockUIElement(song);
        }
        //private bool IsSessionExit()
        //{
        //    var sessions = FindObjectsOfType<GameSession>();
        //    foreach (var session in sessions)
        //    {
        //        if (session != this) return true;
        //    }
        //    return false;
        //}
    }
}