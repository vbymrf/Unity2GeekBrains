using UnityEngine;
namespace ObjectScene.Controller
{
    /// <summary>
    /// Контроллер, который отвечает за управлением Игрока
    /// </summary>
    public class InputController : BaseController
    {
        #region Фонарик
        private bool _isActiveFlashlight = false;
        private bool _isSelectWeapons = true;
        private int _indexWeapons = 0;
        #endregion

        #region  Управление персонажем
        //Управление камерой мышью
        public float _fSensitiveX = 10f;
        public float _fSensitiveY = 10f;
        public float _fMaxRotationY = 60;//Ограничение поворота по вертикали
        public float _fMinRotationY = -60;
        public float _fMaxRotationX = 360;//Ограничение поворота по горизонтали
        public float _fMinRotationX = -360;
        //Управление перемещением
        public float _fSpeedMove=5;

        private float _fMouseX=0;
        private float _fMouseY=0;
        private float _fKeyHorizontal=0;
        private float _fKeyVertical = 0;
      
        private Quaternion _qX;
        private Quaternion _qY;
        private Vector3 _vMove;
        private GameObject _gPlayer;       
        private Rigidbody _kRigiBody;

        private PlayerModel _kPlayer;
        #endregion

        private void Awake()
        {
            _gPlayer = GameObject.FindGameObjectWithTag("Player");           
            _kPlayer= _gPlayer.GetComponent<PlayerModel>();
            _kRigiBody =_gPlayer.GetComponent<Rigidbody>();
            
            if(_kRigiBody) _kRigiBody.freezeRotation = true;//не даем вращаться  обьекту
        }


        public void FixedUpdate()
        {
            #region Управление персонажем
            //Вращение мышью
            _fMouseX = _fMouseX+ Input.GetAxis("Mouse X") *_fSensitiveX;
            _fMouseY = _fMouseY+ Input.GetAxis("Mouse Y")*_fSensitiveY;
            //Debug.Log("Y1=" + Input.GetAxisRaw("Mouse Y"));
            //Debug.Log("X1=" + Input.GetAxisRaw("Mouse X"));
            //Debug.Log("Y=" + Input.GetAxis("Mouse Y"));
            //Debug.Log("X=" + Input.GetAxis("Mouse X"));
            _fMouseX = _fMouseX % 360;
            _fMouseY = _fMouseY % 360;
           _fMouseY = Mathf.Clamp(_fMouseY, _fMinRotationY, _fMaxRotationY);
           _fMouseX = Mathf.Clamp(_fMouseX, _fMinRotationX, _fMaxRotationX);
            //Debug.Log("Y=" + _fMouseY);
            //Debug.Log("X=" + _fMouseX);
            _qX = Quaternion.AngleAxis(_fMouseX, Vector3.up);
            _qY = Quaternion.AngleAxis(_fMouseY, Vector3.left);

            _kPlayer.RotationPlayer(_qX, _qY);//Поворачиваем игрока мышью

            //Перемещение песонажа
            _fKeyHorizontal = Input.GetAxisRaw("Horizontal");
            _fKeyVertical = Input.GetAxisRaw("Vertical");
            //Debug.Log("X=" + Input.GetAxis("Mouse X"));
            _vMove.Set(_fKeyHorizontal, 0f, _fKeyVertical);
            _vMove = _vMove.normalized * _fSpeedMove * Time.deltaTime;
            _kPlayer.MovePlayer(_vMove);
            //_kRigiBody.MovePosition()


            #endregion


            if (Input.GetKeyDown(KeyCode.F))//Включениеи выключение фонарика
            {
                _isActiveFlashlight = !_isActiveFlashlight;
                if (_isActiveFlashlight)
                {
                    Main.Instance.GetFlashlightController.On();
                }
                else
                {
                    Main.Instance.GetFlashlightController.Off();
                }
            }
           
                // Меняем оружие по нажатию клавиш
                if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                _indexWeapons = 0;
                _isSelectWeapons = false;
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                _indexWeapons = 1;
                _isSelectWeapons = false;
            }
            // Меняем оружие колесиком        
            if (_isSelectWeapons) return;
            if (Main.Instance.GetManagerObject.GetWeaponsList[_indexWeapons])
            {
                // Передаем в контроллер стрельбы чем и из чего стрелять
                Main.Instance.GetWeaponsController.On(Main.Instance.GetManagerObject.GetWeaponsList[_indexWeapons], Main.Instance.GetManagerObject.GetAmmunitionList[_indexWeapons]);
            }
            _isSelectWeapons = true;
        }
    }

}
