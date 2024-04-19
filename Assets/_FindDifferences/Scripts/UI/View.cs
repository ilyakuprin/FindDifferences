using UnityEngine;

namespace _FindDifferences.Scripts.UI
{
    public class View : MonoBehaviour
    {
        [field: SerializeField] public Canvas Victory { get; private set; }
        [field: SerializeField] public Canvas Defeat { get; private set; }
    }
}