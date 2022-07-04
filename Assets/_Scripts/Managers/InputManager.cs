using System;
using Data;
using Events;
using Keys;
using UnityEngine;
using UnityEngine.EventSystems;

// EventSystem.current.IsPointerOverGameObject() UI ELEMANLARINA DOkUNMA KONTROLÜ
namespace Managers
{
    public class InputManager : MonoBehaviour
    {
        #region Veriables

        #region Public_Veriables

        [Space(15)] [Header("Data")] public InputData Data;

        #endregion

        #region Private_Veriables

        private bool _isTouching;
        private float _currentVelocity;
        private Vector2? _mousePosition;
        private Vector3 _moveVector;

        #endregion

        #region SerializeField_Veriables

        [SerializeField] private bool isReadyForTouch, isFirstTimeTouchTaken;

        #endregion

        #endregion

        private void Awake()
        {
            Data = getInputData();
        }

        private InputData getInputData() => Resources.Load<CD_Input>("Data/Input").InputData;

        #region Subscribe

        private void OnEnable()
        {
            Subscribe();
        }

        private void Subscribe()
        {
            InputEvents.Instance.onInputDragged += OnInputDragged;
            InputEvents.Instance.onInputReleased += OnInputReleased;
            InputEvents.Instance.onInputTaken += OnInputTaken;
            InputEvents.Instance.onFirstTimeTouchTaken += OnFirstTimeTouchTaken;
            CoreGameEvents.Instance.OnReset += OnReset;
        }


        private void UnSubscribe()
        {
            InputEvents.Instance.onInputDragged -= OnInputDragged;
            InputEvents.Instance.onInputReleased -= OnInputReleased;
            InputEvents.Instance.onInputTaken -= OnInputTaken;
            InputEvents.Instance.onFirstTimeTouchTaken -= OnFirstTimeTouchTaken;
            CoreGameEvents.Instance.OnReset -= OnReset;
        }

        private void OnDisable()
        {
            UnSubscribe();
        }

        #endregion

        private void OnReset()
        {
        }

        private void OnFirstTimeTouchTaken()
        {
        }

        private void OnInputTaken()
        {
        }

        private void OnInputReleased()
        {
        }

        private void OnInputDragged(HorizontalInputParams horizontalInputParams)
        {
        }

        private void Update()
        {
            if (!isReadyForTouch) return;

            if (Input.GetMouseButtonUp(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                _isTouching = false;
                InputEvents.Instance.onInputReleased?.Invoke();
            }


            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                _isTouching = true;
                InputEvents.Instance.onInputTaken?.Invoke();
                if (!isFirstTimeTouchTaken)
                {
                    isFirstTimeTouchTaken = true;
                    InputEvents.Instance.onFirstTimeTouchTaken?.Invoke();
                }

                _mousePosition = Input.mousePosition;
            }

            if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                if (_isTouching)
                {
                    if (_mousePosition != null)
                    {
                        Vector2 mouseDeltaPos = (Vector2)Input.mousePosition - _mousePosition.Value;
            
            
                        if (mouseDeltaPos.x > Data.HorizontalInputSpeed)
                            _moveVector.x = Data.HorizontalInputSpeed / 10f * mouseDeltaPos.x;
                        else if (mouseDeltaPos.x < -Data.HorizontalInputSpeed)
                            _moveVector.x = -Data.HorizontalInputSpeed / 10f * -mouseDeltaPos.x;
                        else
                            _moveVector.x = Mathf.SmoothDamp(_moveVector.x, 0f, ref _currentVelocity,
                                Data.ClampSpeed);
            
                        _mousePosition = Input.mousePosition;
            
                        InputEvents.Instance.onInputDragged?.Invoke(new HorizontalInputParams()
                        {
                            XValue = _moveVector.x,
                            ClampValues = new Vector2(Data.Clamp.x, Data.Clamp.y)
                        });
                    }
                }
            }
        }
    }
}