using System;
using UnityEngine;
using UnityEngine.UI;

namespace _FindDifferences.Scripts.Difference
{
    [Serializable]
    public struct Difference
    {
        public Button Button1;
        [Space]
        public Image Image2;
        public Button Button2;
    }

    public class DifferenceView : MonoBehaviour
    {
        [SerializeField] private Transform _image1;
        [SerializeField] private Transform _image2;

        [SerializeField] private Difference[] _differenceButton;

        public int CountDifference => _differenceButton.Length;

        public Difference GetDifference(int index)
            => _differenceButton[index];

        private void OnValidate()
        {
            if (_differenceButton.Length != 0 || _image1 == null || _image2 == null) return;

            _differenceButton = new Difference[_image1.childCount];

            for (var i = 0; i < _differenceButton.Length; i++)
            {
                _differenceButton[i].Button1 = _image1.GetChild(i).GetComponent<Button>();

                _differenceButton[i].Image2 = _image2.GetChild(i).GetComponent<Image>();
                _differenceButton[i].Button2 = _image2.GetChild(i).GetComponent<Button>();
            }
        }
    }
}
