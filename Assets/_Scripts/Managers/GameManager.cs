using Enums;
using Events;
using Extensions;
using Keys;
using UnityEngine;


namespace Managers
{
    public class GameManager : MonoSingleton<GameManager>
    {
        #region Veriables

        #region Public_Veriables

        [Space(15)] public GameStates States;

        #endregion

        #region Private_Veriables

        #endregion

        #region SerializeField_Veriables

        #endregion

        #endregion

       private void Awake()
        {
           
            Application.targetFrameRate = 60;
        }

        #region Subscribe

        private void OnEnable()
        {
            SubscribeEvent();
        }

        private void SubscribeEvent()
        {
            CoreGameEvents.Instance.OnChangeGameStates += OnChangeGameStates;
            CoreGameEvents.Instance.OnSaveGame += OnOnSaveGame;
        }


        private void UnsubscribeEvent()
        {
            CoreGameEvents.Instance.OnChangeGameStates -= OnChangeGameStates;
            CoreGameEvents.Instance.OnSaveGame -= OnOnSaveGame;
        }

        private void OnDisable()
        {
            UnsubscribeEvent();
        }

        #endregion

        private void OnChangeGameStates(GameStates newStates)
        {
            States = newStates;
        }

        private void OnOnSaveGame(SaveDataParams saveDataParams)
        {
            if (saveDataParams.Level != null)
            {
                Debug.LogWarning(saveDataParams.Level);
                ES3.Save("Level", saveDataParams.Level);
            }

            if (saveDataParams.Coin != null) ES3.Save("Coin", saveDataParams.Coin);
            if (saveDataParams.SFX != null) ES3.Save("SFX", saveDataParams.SFX);
            if (saveDataParams.VFX != null) ES3.Save("VFX", saveDataParams.VFX);
            if (saveDataParams.Haptic != null) ES3.Save("Haptic", saveDataParams.Haptic);
        }
    }
}