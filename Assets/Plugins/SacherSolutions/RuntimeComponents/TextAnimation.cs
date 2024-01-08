using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace SacherSolutions.UI
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class TextAnimation : MonoBehaviour
    {
        [SerializeField] private List<string> frames;
        [SerializeField] private float timeBetweenFrames;

        private TextMeshProUGUI _targetText;
        private int _frameIndex;

        private void Awake()
        {
            _targetText = GetComponent<TextMeshProUGUI>();
        }

        private void Start()
        {
            _frameIndex = 0;
            InvokeRepeating(nameof(DisplayNextFrame), 0f, timeBetweenFrames);
        }

        void DisplayNextFrame()
        {
            _targetText.text = frames[_frameIndex];
            _frameIndex = (_frameIndex + 1) % frames.Count;
        }
    }
}
