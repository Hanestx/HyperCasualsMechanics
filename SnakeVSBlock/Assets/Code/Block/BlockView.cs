﻿using TMPro;
using UnityEngine;


namespace SnakeVsBlock
{
    [RequireComponent(typeof(Block))]
    public class BlockView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _view;
        private Block _block;

        
        private void Awake()
        {
            _block = GetComponent<Block>();
        }

        private void OnEnable()
        {
            _block.FillingUpdated += OnFillingUpdated;
        }

        private void OnDisable()
        {
            _block.FillingUpdated -= OnFillingUpdated;
        }

        
        private void OnFillingUpdated(int leftToFill)
        {
            _view.text = leftToFill.ToString();
        }
    }
}