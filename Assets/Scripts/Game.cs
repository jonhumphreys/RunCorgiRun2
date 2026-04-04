using UnityEngine;

public class Game : MonoBehaviour
{
    public UI UI;
    public GameTimer GameTimer;
    public BeerPlacer BeerPlacer;
    public BonePlacer BonePlacer;
    public PillPlacer PillPlacer;
    public MoonshinePlacer MoonshinePlacer;
    public PoopPlacer PoopPlacer;
    public Corgi Corgi;
    public Music Music;
    public Sounds Sounds;
    
    public bool IsPlaying = false;
    
    void Start()
    {
        UI.ShowStartScreen();
        Music.PlayMenuMusic();
    }

    public void Update()
    {
        UI.ShowTime();
    }

    public void OnStartButtonClicked()
    {
        Sounds.PlayPoopSound();
        UI.HideStartScreen();
        InitializeGame();
    }

    private void InitializeGame()
    {
        GameTimer.StartTimer(GameParameters.GameDurationInSeconds,
            OnTimerFinished);
        StartPlacers();
        IsPlaying = true;
        ScoreKeeper.ResetScore();
        UI.SetScoreText(0);
        Corgi.Reset();
        Music.PlayGameMusic();
    }

    public void OnPlayAgainButtonClicked()
    {
        Sounds.PlayPoopSound();
        UI.HideGameOverScreen();
        InitializeGame();
    }

    private void StartPlacers()
    {
        BeerPlacer.StartPlacing();
        BonePlacer.StartPlacing();
        PillPlacer.StartPlacing();
        MoonshinePlacer.StartPlacing();
    }
    
    private void StopPlacers()
    {
        BeerPlacer.StopPlacing();
        BonePlacer.StopPlacing();
        PillPlacer.StopPlacing();
        MoonshinePlacer.StopPlacing();
        PoopPlacer.CleanUpPlacedObjects();
    }

    public void OnTimerFinished()
    {
        UI.ShowGameOverScreen();
        IsPlaying = false;
        StopPlacers();
        //Sounds.StopAllSounds();
        Music.PlayMenuMusic();
    }

}
