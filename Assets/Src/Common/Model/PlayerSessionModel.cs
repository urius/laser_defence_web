using System;
using Src.Common.Model;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSessionModel", menuName = "Common/Model/PlayerSessionModel")]
public class PlayerSessionModel : ScriptableObject
{
    [SerializeField]
    private PlayerGlobalModel _playerGlobalModel;
    public PlayerGlobalModel PlayerGlobalModel => _playerGlobalModel;
    
    public event Action<GameState> GameStateChanged = delegate {  }; 

    public SelectedLevelData SelectedLevelData;
    public int SelectedLevelIndex => SelectedLevelData.LevelIndex;
    public LevelConfig SelectedLevelConfig => SelectedLevelData.LevelConfig;

    public GameState GameState { get; private set; } = GameState.Undefined;

    public void Reset()
    {
        SelectedLevelData = new SelectedLevelData(LevelsCollectionProvider.Instance.Levels);
        SetGameState(GameState.Undefined);
    }

    public void SetGameState(GameState state)
    {
        if (GameState == state) return;
        
        GameState = state;
        GameStateChanged(GameState);
    }

    public void ResetSelectedBoosters(bool needRefundGold)
    {
        var boosterIds = SelectedLevelData.BoosterIds;
        if (boosterIds.Length > 0)
        {
            var refundAmount = 0;
            foreach (var boosterId in boosterIds)
            {
                refundAmount += BoostersConfigProvider.GetBoosterConfigById(boosterId).Price;
            }
            if (needRefundGold)
            {
                PlayerGlobalModel.AddGold(refundAmount);
            }

            SelectedLevelData.ResetBoosters();
        }
    }

    public void SetModel(PlayerGlobalModel model)
    {
        _playerGlobalModel = model;
    }

    public void AdvanceSelectedLevel()
    {
        SelectedLevelData.AdvanceSelectedLevel();
    }
}
