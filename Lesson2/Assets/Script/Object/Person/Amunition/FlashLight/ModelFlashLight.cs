using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
// Привязать к любому родительскому обьекту с имеющимся Light фонариком
[RequireComponent (typeof(Light))] //Если не окажется на нем, будет добавлен компанет
/// <summary>
/// Модель фонарика. К ней в нарушение MVC привязано представление (???). Т.к. отвязка не имеет смысла и усложняет переносимость кода.
/// </summary>
public class ModelFlashLight : MonoBehaviour
{
    private List <Light> _kLight=new List<Light>(); //Компанеты освещения от фонарика

    public bool Enable=true;//Включен ли фонарик
    public float _fEnergyAmount=10f;//Заряд фонарика
    public float _fMaxEnergyAmount = 10f;//Максимальный заряд фонарика
    public float _fRechargeAmount=0.5f;//К-т перезарядки, пока он выключен       

    private void Awake()
    {
        GetComponentsInChildren<Light>(true,_kLight);    //Привязка Light на дочерних обьектах
        _kLight.Add(GetComponent<Light>());       //Привязка на обьекте   
        
    }
   
    public void On()
    {
        foreach (Light l in _kLight) l.enabled = true;
        Enable = true;        
    }
    public void Off()
    {   
        foreach(Light l in _kLight) l.enabled = false;
        Enable = false;
    }
}
