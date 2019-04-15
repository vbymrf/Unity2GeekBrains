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

        public bool _IsGrounded = false;
        #endregion
        protected override void Awake()
        {
            base.Awake();
            _gPlayer = GameObject.FindGameObjectWithTag("Player");
            _gCamera = GameObject.FindGameObjectWithTag("MainCamera");

            _kRigiBody = _gPlayer.GetComponent<Rigidbody>();
            _qOriginalRotation = _gCamera.transform.rotation;
           
        }

        //private void FixedUpdate()
        //{
            
        //}

        public void MovePlayer(Vector3 movement)
         {//???  Персонаж падает под землю если не использовать физику (под мостом). По физике не залазиет на подьем
            //_kRigiBody.AddForce(transform.TransformDirection(movement * 100));// По физике
            //_kRigiBody.MovePosition(transform.position + transform.TransformDirection(movement));//Непонятно почему вектор перемещения глобальный, не зависит от RigiBody или gameobject вращения и как помогает TransformDirection           
           _gPlayer.transform.Translate(movement);
            //Debug.Log("V.x=" + _kRigiBody.velocity.x);
            //Debug.Log("V.y=" + _kRigiBody.velocity.y);
            //Debug.Log("V.z=" + _kRigiBody.velocity.z);

        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Grounded") _IsGrounded = true;
           
        }
        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.tag == "Grounded") _IsGrounded = false;
           
        }
        public void JumpPlayer(Vector3 JumpForce)
        {
            //Debug.Log(_IsGrounded);// Через некоторое время методы OnCollision перестанут работать. Если не запускается Uodate
            if (_IsGrounded)
                _kRigiBody.AddForce((JumpForce*50), ForceMode.Impulse);
        }
        public void RotationPlayer(Quaternion X, Quaternion Y)
        {
            _gCamera.transform.localRotation = _qOriginalRotation * Y;
            _kRigiBody.transform.localRotation = _qOriginalRotation * X;
        }

}
}
