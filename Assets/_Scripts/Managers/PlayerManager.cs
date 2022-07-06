using System;
using Controllers;
using Data;
using Events;
using Keys;
using UnityEngine;

namespace Managers
{
    public class PlayerManager : MonoBehaviour
    {
        #region Veriables

        [Space(15)] [Header("Data")]

        #region Public_Veriables

        public PlayerData Data;

        #endregion

        #region Private_Veriables

        #endregion

        #region SerializeField_Veriables

        [Space] [SerializeField] private PlayerMovementData movementController;
        [SerializeField] private PlayerPhysicsController physicsController;

        [SerializeField] private PlayerAnimationController animationController;

        #endregion

        #endregion

        private void Awake()
        {
            Data = _getPlayerData();
        }

        private PlayerData _getPlayerData() => Resources.Load<CD_Player>("Data/Player").Data;

        #region Subscribe

        private void OnEnable()
        {
            SubscribeEvent();
        }

        private void SubscribeEvent()
        {
            InputEvents.Instance.onInputTaken += ActiveteMovement;
            InputEvents.Instance.onInputReleased += OnDeactiveMovement;
            InputEvents.Instance.onInputDragged += OnInputDragged;
            CoreGameEvents.Instance.OnPlay += OnPlay;
            CoreGameEvents.Instance.OnReset += OnReset;
            CoreGameEvents.Instance.OnLevelFailed += OnLevelFailed;
            CoreGameEvents.Instance.onStageAreaReached += OnStageAreaReached;
            CoreGameEvents.Instance.onStageSuccessful += OnStageSuccessful;
        }
        private void UnsubscribeEvent()
        {
            InputEvents.Instance.onInputTaken -= ActiveteMovement;
            InputEvents.Instance.onInputReleased -= OnDeactiveMovement;
            InputEvents.Instance.onInputDragged -= OnInputDragged;
            CoreGameEvents.Instance.OnPlay -= OnPlay;
            CoreGameEvents.Instance.OnReset -= OnReset;
            CoreGameEvents.Instance.OnLevelFailed -= OnLevelFailed;
            CoreGameEvents.Instance.onStageAreaReached -= OnStageAreaReached;
            CoreGameEvents.Instance.onStageSuccessful -= OnStageSuccessful;
        }
        private void OnDisable()
        {
            UnsubscribeEvent();
        }

        #endregion
        private void OnPlay()
        {
            
        }
        private void OnReset()
        {
        }

        private void OnDeactiveMovement()
        {
        }

        private void ActiveteMovement()
        {
        }

        private void OnInputDragged(HorizontalInputParams arg0)
        {
        }
        
        private void OnStageSuccessful()
        {
           
        }

        private void OnStageAreaReached()
        {
         
        }

        private void OnLevelFailed()
        {
            
        }

    }
}