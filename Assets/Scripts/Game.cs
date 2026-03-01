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
    
    public bool IsPlaying = false;
    
    void Start()
    {
        UI.ShowStartScreen();
    }

    public void Update()
    {
        UI.ShowTime();
    }

    public void OnStartButtonClicked()
    {
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
    }

    public void OnPlayAgainButtonClicked()
    {
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
    }

}
