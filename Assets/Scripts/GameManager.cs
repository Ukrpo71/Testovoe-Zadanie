using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _circlePrefab;

    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private GameObject _restartButton;

    [SerializeField]
    private int _numberOfCircles = 5;
    private List<Vector2> _circlePositions;

    private int _score = 0;
    void Awake()
    {
        _score = 0;
        _circlePositions = new List<Vector2>();

        for (int i = 0; i < _numberOfCircles; i++)
        {
            SpawnCircle();
        }
    }

    private void SpawnCircle()
    {
        Vector2 spawnPosition;

        do
        {
            spawnPosition = RandomPosition();
        } while
            (isPositionUnique(spawnPosition) == false);



        Instantiate(_circlePrefab, spawnPosition, Quaternion.identity);

        _circlePositions.Add(spawnPosition);
    }

    private Vector2 RandomPosition() => new Vector2(Random.Range(-4, 4), Random.Range(-4, 4));

    private bool isPositionUnique(Vector2 randomPosition)
    {
        if (randomPosition == new Vector2(0, 0))
            return false;

        if (_circlePositions.Count == 0)
            return true;

        foreach (Vector2 position in _circlePositions)
        {
            if (randomPosition == position)
                return false;
        }

        return true;
    }

    public void CircleDestroyed()
    {
        _score++;
        UpdateScore();

        if (_score == _numberOfCircles)
            ShowRestartButton();
    }

    private void UpdateScore()
    {
        _scoreText.text = "Score: " + _score;
    }

    public void ShowRestartButton()
    {
        _restartButton.SetActive(true);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    

    
}
