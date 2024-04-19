using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _FindDifferences.Scripts.UI
{
    public class View : MonoBehaviour
    {
        [field: SerializeField] public Canvas Victory { get; private set; }
        [field: SerializeField] public Canvas Defeat { get; private set; }
        [field: SerializeField] public TextMeshProUGUI Level { get; private set; }
        [field: SerializeField] public Button DefeatButton { get; private set; }
        [field: SerializeField] public Button VictoryButton { get; private set; }
    }
}