using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GameObject shipPrefab;
    public GameObject spaceStationPrefab;
    public Transform shipStartPosition;
    public Transform spaceStationStartPosition;
    public GameObject currentShip {  get; private set; }
    public GameObject currentSpaceStation { get; private set; }
    public SmoothFollow cameraFollow;

    public GameObject inGameUI;
    public GameObject pausedUI;
    public GameObject gameOverUI;
    public GameObject mainMenuUI;

    public bool gameIsPlaying { get; private set; }
    public AsteroidSpawner asteriodSpawner;
    public bool paused;
    

    private void Start()
    {
        ShowMainMenu();
    }

    void ShowUI(GameObject newUI)
    {
        GameObject[] allUI = {inGameUI, pausedUI,  gameOverUI, mainMenuUI};

        foreach (GameObject UIToHide in allUI)
        {
            UIToHide.SetActive(false);
        }

        newUI.SetActive(true);
    }

    public void ShowMainMenu()
    {
        ShowUI(mainMenuUI);
        gameIsPlaying = false;
        asteriodSpawner.spawnAsteroid = false;
    }

    public void StartGame()
    {
        ShowUI(inGameUI);
        gameIsPlaying = true;
        if (currentShip != null)
        {
            Destroy(currentShip);
        }

        if (currentSpaceStation != null)
        {
            Destroy(currentSpaceStation);
        }

        currentShip = Instantiate(shipPrefab);
        currentShip.transform.position = shipStartPosition.position;
        currentShip.transform.rotation = shipStartPosition.rotation;

        currentSpaceStation = Instantiate(spaceStationPrefab);
        currentSpaceStation.transform.position = spaceStationStartPosition.position;
        currentSpaceStation.transform.rotation = spaceStationStartPosition.rotation;

        cameraFollow.target = currentShip.transform;
        asteriodSpawner.spawnAsteroid = true;
        asteriodSpawner.target = currentSpaceStation.transform;
    }

    public void GameOver()
    {
        ShowUI(gameOverUI);
        gameIsPlaying = false;
        if (currentShip != null)
        {
            Destroy(currentShip);
        }
        if (currentSpaceStation != null)
        {
            Destroy(currentSpaceStation);
        }

        asteriodSpawner.spawnAsteroid = false;
        asteriodSpawner.DestroyAllAsteroids();
    }

    public void SetPaused(bool paused)
    {
        inGameUI.SetActive(!paused);
        pausedUI.SetActive(paused);

        if (paused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}
