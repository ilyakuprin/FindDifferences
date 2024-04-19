using _FindDifferences.Scripts.Saves;
using UnityEngine;

namespace _FindDifferences.Scripts.LoadLevels
{
    public class GettingBehaviour : MonoBehaviour
    {
        public Loading Loading { get; private set; }
        public JsonIO JsonIO { get; private set; }

        public void SetLoading(Loading loading)
            => Loading = loading;

        public void SetJsonIO(JsonIO jsonIO)
            => JsonIO = jsonIO;
    }
}