using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Transform playerSpawnTransform;
    public List<PlayerController> players;
    public List<AIController> enemies;
    public List<RoomManager> rooms;
    RoomManager lvlBuild;
    public GameObject TitleScreen;
    public GameObject PauseScreen;
    public GameObject GameOverScreen;
    public GameObject GameplayScreen;
    public GameObject OptionsScreen;
    public GameObject CreditsScreen;
    public GameObject WinScreen;
    public GameObject pconPFab;
    public GameObject ppawnPFab;
    public RoomManager rManager;
    public AudioSource ambient;
    public enum GameStates { TitleScreen, StartGame, GameplayScreen, OptionsScreen, PauseMenu, GameOverScreen, WinScreen, Credits, Quit}
    public GameStates currentState;
    private float lastTimeStateChange;
    public float WinScore;

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        ambient = GetComponent<AudioSource>();
        ActivateTitleScreen();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeState(currentState);
        if (currentState != GameStates.GameplayScreen)
        {
            ambient.Pause();
        }
        rManager = GetComponent<RoomManager>();
        ChangingMenus();
    }
    public void ChangeState(GameStates newState)
    {
        currentState = newState;
        lastTimeStateChange = Time.time;
    }
    public void SpawnPlayer()
    {
        GameObject newPCon = Instantiate(pconPFab, Vector3.zero, Quaternion.identity) as GameObject;
        GameObject newPPawn = Instantiate(ppawnPFab, playerSpawnTransform.position, playerSpawnTransform.rotation) as GameObject;
        PlayerController newCon = newPCon.GetComponent<PlayerController>();
        Pawn newPawn = newPPawn.GetComponent<Pawn>();
        newCon.pawn = newPawn;
        newPawn.controller = newCon;
    }
    public void DeactivateAllScreens()
    {
        TitleScreen.SetActive(false);
        GameplayScreen.SetActive(false);
        PauseScreen.SetActive(false);
        OptionsScreen.SetActive(false);
        GameOverScreen.SetActive(false);
        CreditsScreen.SetActive(false);
        WinScreen.SetActive(false);
    }
    public void ActivateTitleScreen()
    {
        ChangeState(GameStates.TitleScreen);
        DeactivateAllScreens();
        TitleScreen.SetActive(true);
    }
    public void ActivateGameplayScreen()
    {
        ChangeState(GameStates.GameplayScreen);
        DeactivateAllScreens();
        GameplayScreen.SetActive(true);
    }
    public void ActivateOptionsScreen()
    {
        ChangeState(GameStates.OptionsScreen);
        DeactivateAllScreens();
        OptionsScreen.SetActive(true);
    }
    public void ActivatePauseScreen()
    {
        ChangeState(GameStates.PauseMenu);
        DeactivateAllScreens();
        PauseScreen.SetActive(true);
    }
    public void ActivateGameOverScreen()
    {
        ChangeState(GameStates.GameOverScreen);
        DeactivateAllScreens();
        GameOverScreen.SetActive(true);
    }
    public void ActivateCreditsScreen()
    {
        ChangeState(GameStates.Credits);
        DeactivateAllScreens();
        CreditsScreen.SetActive(true);
    }
    public void ActivateWinScreen()
    {
        ChangeState(GameStates.WinScreen);
        DeactivateAllScreens();
        WinScreen.SetActive(true);
    }
    public void LoadGame()
    {
        if(players.Count == 0)
        {
            SpawnPlayer();
            rManager.GenerateLevel();
            ambient.Play();
            ChangeState(GameStates.GameplayScreen);
        }
        else
        {
            ResumeGame();
        }
    }
    public void QuitGame()
    {
        ChangeState(GameStates.Quit);
        Application.Quit();
    }
    public void ResumeGame()
    {
        ChangeState(GameStates.GameplayScreen);
        ambient.UnPause();
    }
    public void ChangingMenus()
    {
        switch (currentState)
        {
            case GameStates.StartGame:
                LoadGame();
                break;
            case GameStates.TitleScreen:
                ActivateTitleScreen();
                Time.timeScale = 0;
                break;
            case GameStates.GameplayScreen:
                ActivateGameplayScreen();
                Time.timeScale = 1;
                if (Input.GetKeyDown(KeyCode.P))
                {
                    ChangeState(GameStates.PauseMenu);
                }
                if(GameManager.FindObjectOfType<PlayerController>().score == WinScore)
                {
                    ChangeState(GameStates.WinScreen);
                }
                break;
            case GameStates.PauseMenu:
                ActivatePauseScreen();
                Time.timeScale = 0;
                break;
            case GameStates.OptionsScreen:
                ActivateOptionsScreen();
                Time.timeScale = 0;
                break;
            case GameStates.GameOverScreen:
                ActivateGameOverScreen();
                break;
            case GameStates.Credits:
                ActivateCreditsScreen();
                Time.timeScale = 0;
                break;
            case GameStates.WinScreen:
                ActivateWinScreen();
                Time.timeScale = 0;
                break;
            case GameStates.Quit:
                QuitGame();
                break;
        }
    }
}
