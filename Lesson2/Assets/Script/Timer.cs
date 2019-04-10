using System;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectScene
{
    public sealed class Timer
    {
        DateTime _start; //Время включения таймера
        float _elapsed = -1;// Подсчитываемое время
        private TimeSpan _duration;//Временные промежутки
        public void Start(float elapsed)
        {
            _elapsed = elapsed;
            _start = DateTime.Now;
            _duration = TimeSpan.Zero;
        }
        public void Update()
        {
            if (_elapsed > 0)
            {
                _duration = DateTime.Now - _start;
                if (_duration.TotalSeconds > _elapsed)
                {
                    _elapsed = 0;
                }
            }
            else if (_elapsed == 0)
            {
                _elapsed = -1;
            }
        }
        public bool IsEvent()
        {
            return _elapsed == 0;
        }
    }

}

