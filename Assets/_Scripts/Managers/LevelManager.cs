using System;
using Controllers;
using Data;
using Events;
using Extensions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Managers
{
    public class LevelManager : MonoSingleton<LevelManager>
    {
        #region Veriables

        #region Public_Veriables

        [Space(15)] [Header("Data")] public Level Data;
        [HideInInspector] public int levelID => _levelID;

        #endregion

        #region Private_Veriables

        [Space(15)] [ShowInInspector]private int _levelID;

        #endregion

        #region SerializeField_Veriables

        [SerializeField] private LevelClearLoaderController Levelcontroller;
        [SerializeField] private Transform LevelHolder;
        #endregion

        #endregion

        #region Subscribe

        private void OnEnable()
        {
            Subscribe();
        }

        private void Subscribe()
        {
            CoreGameEvents.Instance.OnLevelInitialize += OnLevelInitialize;
            CoreGameEvents.Instance.OnClearActiveLevel += OnClearActiveLevel;
        }


        private void UnSubscribe()
        {
            CoreGameEvents.Instance.OnClearActiveLevel -= OnClearActiveLevel;
            CoreGameEvents.Instance.OnLevelInitialize -= OnLevelInitialize;
        }

        private void OnDisable()
        {
            UnSubscribe();
        }

        #endregion

        private void Awake()
        {
            _levelID = _getActiveLevel();
            Data = _getLevelData();
        }

        private void Start()
        {
            OnLevelInitialize();
        }

        private Level _getLevelData()
        {
            var newLevelData = _levelID % Resources.Load<LevelList>("Data/LevelList").Levels.Count;
            return Resources.Load<LevelList>("Data/LevelList").Levels[newLevelData];
        }

        private int _getActiveLevel()
        {
            if (!ES3.FileExists()) return 0;
            return ES3.KeyExists("Level") ? ES3.Load<int>("Level") : 0;
        }

        private void OnClearActiveLevel()
        {
            Levelcontroller.ClearActiveLevel(LevelHolder);
        }

        private void OnLevelInitialize()
        {
            var newLevelData = _levelID % Resources.Load<LevelList>("Data/LevelList").Levels.Count;
            Levelcontroller.InitialzedLevel(newLevelData,LevelHolder);
        }
    }
}