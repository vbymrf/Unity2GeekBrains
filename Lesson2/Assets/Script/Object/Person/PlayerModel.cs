using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ObjectScene { 
public class PlayerModel : BaseObjectScene
    {
        #region  Управление персонажем
       
        //Управление перемещением
        public float _fSpeedMopve;

        private float _fMouseX = 0;
        private float _fMouseY = 0;
        private float _fKeyX = 0;
        private float _fKeyY = 0;
        private Quaternion _qOriginalRotation;
        private Quaternion _qX;
        private Quaternion _qY;
        private Vector3 _vMove;
        private GameObject _gPlayer;
        private GameObject _gCamera;
        private Rigidbody _kRigiBody;
        #endregion
        protected override void Awake()
        {
            base.Awake();
            _gPlayer = GameObject.FindGameObjectWithTag("Player");
            _gCamera = GameObject.FindGameObjectWithTag("MainCamera");

            _kRigiBody = _gPlayer.GetComponent<Rigidbody>();
            _qOriginalRotation = _gCamera.transform.rotation;
           
        }
        public void MovePlayer(Vector3 movement)
         {
            _kRigiBody.MovePosition(transform.localPosition + movement);
         }
        public void JumpPlayer()
        {

        }
        public void RotationPlayer(Quaternion X, Quaternion Y)
        {
            _gCamera.transform.localRotation = _qOriginalRotation * Y;
            _gPlayer.transform.localRotation = _qOriginalRotation * X;
        }

}
}
