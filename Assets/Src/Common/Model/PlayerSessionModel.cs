﻿using System;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSessionModel", menuName = "Common/Model/PlayerSessionModel")]
public class PlayerSessionModel : ScriptableObject
{
    public static PlayerSessionModel Instance { get; private set; }
    public static PlayerGlobalModel Model => Instance.PlayerGlobalModel;

    [SerializeField]
    private PlayerGlobalModel _playerGlobalModel;
    public PlayerGlobalModel PlayerGlobalModel => _playerGlobalModel;

    public bool SaveGoldFlag = false;

    public SelectedLevelData SelectedLevelData;
    public int SelectedLevelIndex => SelectedLevelData.LevelIndex;
    public LevelConfig SelectedLevelConfig => SelectedLevelData.LevelConfig;

    public void Reset()
    {
        SelectedLevelData = new SelectedLevelData(LevelsCollectionProvider.Instance.Levels);
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

    private void OnEnable()
    {
        Instance = this;
    }
}
