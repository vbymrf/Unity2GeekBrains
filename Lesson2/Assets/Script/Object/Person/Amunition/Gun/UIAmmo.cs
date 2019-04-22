using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ObjectScene.Controller;
namespace ObjectScene {
    public class UIAmmo : MonoBehaviour
    {
        private WeaponsController _kWeaponsController;

        private void Awake()
        {
            _kWeaponsController = Main.Instance.GetWeaponsController;
        }
    }
}