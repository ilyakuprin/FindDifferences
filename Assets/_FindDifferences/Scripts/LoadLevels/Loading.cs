using _FindDifferences.Scripts.Saves;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace _FindDifferences.Scripts.LoadLevels
{
    public class Loading : MonoBehaviour
    {
        [SerializeField] private JsonIO _jsonIO;

        private GameObject _level;

        private void OnEnable()
            => _jsonIO.Loaded += LoadLevel;

        private void OnDisable()
            => _jsonIO.Loaded -= LoadLevel;

        private void LoadLevel()
        {
            //тут можно сделать загрузку следующего уровня: var lvl = "Level" + _jsonIO.Data.Level.ToString();

            Addressables.InstantiateAsync("Level1").Completed += prefab =>
            {
                _level = prefab.Result;
                if (_level.TryGetComponent<GettingBehaviour>(out var gettingBehaviour))
                {
                    gettingBehaviour.SetLoading(this);
                    gettingBehaviour.SetJsonIO(_jsonIO);
                }
            };
        }

        public void LoadNextLevel()
        {
            if (_level == null) return;

            _jsonIO.AddLevel();
            Addressables.ReleaseInstance(_level);
            _level = null;
            LoadLevel();
        }
    }
}