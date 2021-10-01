﻿using System;
using UnityEngine;
using UnityEngine.UI;

namespace FastHand
{
    public class DisplayEndGame
    {
        private Text _finishGameLabel;
        public DisplayEndGame(GameObject endGame)
        {
            _finishGameLabel = endGame.GetComponentInChildren<Text>();
            _finishGameLabel.text = String.Empty;
        }
        public void GameOver(string name)
        {
            _finishGameLabel.text = $"Вы проиграли. Вас убил {name}";
        }
    }
}