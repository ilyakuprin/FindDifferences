using System;
using System.IO;
using UnityEngine;

namespace _FindDifferences.Scripts.Saves
{
    public class JsonIO : MonoBehaviour
    {
        public event Action Loaded;

        private const string JsonFileName = "jsonSaveData.json";
        private const int StartLevel = 1;
        
        private SaveData _saveData;
        private string _savePath;
        
        public SaveData Data => _saveData;

        private void Start()
        {
            SetPath();
            LoadData();
            Loaded?.Invoke();
        }

        private void SetPath()
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            _savePath = Path.Combine(Application.persistentDataPath, JsonFileName);
#else
            _savePath = Path.Combine(Application.streamingAssetsPath, JsonFileName);
#endif
        }

        private void SaveData()
        {
            var json = JsonUtility.ToJson(_saveData, true);
            
            File.WriteAllText(_savePath, json);
        }

        private void LoadData()
        {
            if (!File.Exists(_savePath))
            {
                _saveData = new SaveData
                {
                    Level = StartLevel
                };
            }
            else
            {
                var json = File.ReadAllText(_savePath);
                _saveData = JsonUtility.FromJson<SaveData>(json);
            }
        }
        
        public void AddLevel()
        {
            _saveData.Level++;
            SaveData();
        }
    }
}