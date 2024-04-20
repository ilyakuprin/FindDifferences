using System;
using System.IO;
using UnityEngine;

namespace _FindDifferences.Scripts.Saves
{
    public class JsonIO : MonoBehaviour
    {
        public event Action Loaded;
        
        private SaveData _saveData;
        
        public SaveData Data => _saveData;

        private void Start()
        {
            LoadData();
            Loaded?.Invoke();
        } 

        private void LoadData()
            => _saveData = JsonUtility.FromJson<SaveData>(
                File.ReadAllText(Application.streamingAssetsPath + "/Saves.json"));

        private void SaveData()
            => File.WriteAllText(
                Application.streamingAssetsPath + "/Saves.json", JsonUtility.ToJson(_saveData));

        public void AddLevel()
        {
            _saveData.Level++;
            SaveData();
        }
    }
}