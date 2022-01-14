using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
[RequireComponent(typeof(CanvasGroup))]


public class GameOverScript : MonoBehaviour
{
    
    [SerializeField] private Button _restartBtn;
    [SerializeField] private Button _exitBtn;
    [SerializeField] private Player _player;

    private CanvasGroup _gameOverGroup;

    

    private void OnEnable()
    {

        _restartBtn.onClick.AddListener(onRestartButonClick);
        _exitBtn.onClick.AddListener(onExitButtonClick);

        _player.Died += onDied;


    }

    private void OnDisable()
    {


        _restartBtn.onClick.RemoveListener(onRestartButonClick);
        _exitBtn.onClick.RemoveListener(onExitButtonClick);
        _player.Died -= onDied;
    }
  

    private void Start()
    {
        _gameOverGroup = GetComponent<CanvasGroup>();
        _gameOverGroup.alpha = 0;
    }

    private void onDied()
    {
        _gameOverGroup.alpha = 1;
        Time.timeScale = 0;

    }


    private void onRestartButonClick() {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    
    }

    private void onExitButtonClick()
    {
        Application.Quit();

    }



}
