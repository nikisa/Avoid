using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public Text recordText;

    public Text recordTextEnd;
    public Text timeTextEnd;

    bool _hasLevelStarted = false;
    bool _isGamePlaying = false;
    bool _isGameOver = false;
    bool _hasLevelFinished = false;

    public bool HasLevelStarted { get { return _hasLevelStarted; } set { _hasLevelStarted = value; } }
    public bool IsGamePlaying { get { return _isGamePlaying; } set { _isGamePlaying = value; } }
    public bool IsGameOver { get { return _isGameOver; } set { _isGameOver = value; } }
    public bool HasLevelFinished { get { return _hasLevelFinished; } set { _hasLevelFinished = value; } }

    public float delay = 1f;

    public UnityEvent startLevelEvent;
    public UnityEvent playLevelEvent;
    public UnityEvent endLevelEvent;

    Timer _timer;
    Player _player;

    private void Awake() {
        float record = GetRecord();

        _timer = Object.FindObjectOfType<Timer>().GetComponent<Timer>();
        _player = Object.FindObjectOfType<Player>().GetComponent<Player>();
    }

    void Start() {
            StartCoroutine("RunGameLoop"); 
    }

    IEnumerator RunGameLoop() {
        yield return StartCoroutine("StartLevelRoutine");
        yield return StartCoroutine("PlayLevelRoutine");
        yield return StartCoroutine("EndLevelRoutine");
    }

    IEnumerator StartLevelRoutine() {

        _timer.started = false;
        

        recordText.text = GetRecord().ToString("f2");
        _player.playerInputEnabled = false;

        while (!_hasLevelStarted) {
            yield return null;
        }

        if (startLevelEvent != null) {
            startLevelEvent.Invoke();
        }
    }

    IEnumerator PlayLevelRoutine() {
        _player.playerInputEnabled = true;
        _timer.started = true;
        _isGamePlaying = true;
        

        yield return new WaitForSeconds(delay);

        if (playLevelEvent != null) {
            playLevelEvent.Invoke();
        }

        while (!_isGameOver) {
            _isGameOver = isWinner();

            timeTextEnd.text = _timer.t.ToString("f2");
            recordTextEnd.text = GetRecord().ToString("f2");

            yield return null;
        }
        yield return null;
    }

    IEnumerator EndLevelRoutine() {

        _timer.started = false;
        
        
        _player.playerInputEnabled = false;
        

        if (endLevelEvent != null) {
            endLevelEvent.Invoke();
        }

        while (!_hasLevelFinished) {
            yield return null;
        }
        setRecord(_timer.t);
        Restart();
    }

    public void Restart() {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void PlayLevel() {
        _hasLevelStarted = true;
    }


    bool isWinner() {
        return _timer.finished;
    }

    public static float GetRecord() {
        return PlayerPrefs.GetFloat("record", 1000);
    }

    public static bool setRecord(float time) {
        float record = GetRecord();
        if (time < record) {
            PlayerPrefs.SetFloat("record", time);
            PlayerPrefs.Save();
            return true;
        }
        else {
            return false;
        }
    }
}
