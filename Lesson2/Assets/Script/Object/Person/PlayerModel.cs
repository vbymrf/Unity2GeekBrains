using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ObjectScene { 
public class PlayerModel : BaseObjectScene
    {
        public float _fDistanceFeet=1;//Расстояние до земли от центра персонажа

        private Quaternion _qOriginalRotation;
        private RaycastHit[] _rmJumpCollision;
        
        private GameObject _gPlayer;
        private GameObject _gCamera;
        private Rigidbody _kRigiBody;

        public bool _IsGrounded = false;
        
        protected override void Awake()
        {
            base.Awake();
            _gPlayer = GameObject.FindGameObjectWithTag("Player");
            _gCamera = GameObject.FindGameObjectWithTag("MainCamera");
            

            _kRigiBody = _gPlayer.GetComponent<Rigidbody>();
            _qOriginalRotation = _gCamera.transform.rotation;

            _fDistanceFeet = 1;//Задаем расстояние. На которое быдем искать землю под ногами.

    }

     
        public void MovePlayer(Vector3 movement)
         {//???  Персонаж падает под землю если не использовать физику (под мостом). По физике не залазиет на подьем
            _gPlayer.transform.Translate(movement);

            //_kRigiBody.AddForce(transform.TransformDirection(movement * 100));// По физике
            //_kRigiBody.MovePosition(transform.position + transform.TransformDirection(movement));//Непонятно почему вектор перемещения глобальный, не зависит от RigiBody или gameobject вращения и как помогает TransformDirection           
          
            //Debug.Log("V.x=" + _kRigiBody.velocity.x);
            //Debug.Log("V.y=" + _kRigiBody.velocity.y);
            //Debug.Log("V.z=" + _kRigiBody.velocity.z);

        }
        //private void OnCollisionEnter(Collision collision)  //Проблематично определять землю без обьекта ног. Т.е. коллизии должны искаться на ногах, а не модели персонажа целиком
        //{
        //    if (collision.gameObject.tag == "Grounded") _IsGrounded = true;
           
        //}
        //private void OnCollisionExit(Collision collision)
        //{
        //    if (collision.gameObject.tag == "Grounded") _IsGrounded = false;
           
        //}
        public void JumpPlayer(Vector3 JumpForce)
        {
            //Debug.Log(_IsGrounded);
           // Physics2D.LinecastAll
            _rmJumpCollision = Physics.RaycastAll(transform.position, Vector3.down, _fDistanceFeet);
            int n = 0;
            foreach (RaycastHit r in _rmJumpCollision)
            {
                if (r.transform.tag == "Grounded")  n++;               
            }
            if (n > 0) _IsGrounded = true;
            else _IsGrounded = false;

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
