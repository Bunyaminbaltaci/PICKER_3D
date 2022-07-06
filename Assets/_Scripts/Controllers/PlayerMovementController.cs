using Data;
using Managers;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Controllers
{
    public class PlayerMovementController : MonoBehaviour
    {
        #region Veriables

        #region Public_Veriables

        [Space(15)]
        [Header("Data")]

        #endregion

        #region Private_Veriables

        [ShowInInspector]
        public PlayerMovementData _movementData;

        [ShowInInspector] private bool _isReadyToMove, _isReadyToPlay;
        [ShowInInspector] private float _inputValue;
        [ShowInInspector] private Vector2 _clampValues;

        #endregion

        #region SerializeField_Veriables

        [SerializeField] private PlayerManager manager;
        [SerializeField] private new Rigidbody rigidbody;

        #endregion

        #endregion
    }
}