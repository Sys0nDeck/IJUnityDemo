using TMPro;
using UnityEngine;

namespace FallingCubes
{
    public class SpawnerUI<T> : SpawnerView<T> where T : MonoBehaviour
    {
        [SerializeField] private TMP_Text _createCountText;
        [SerializeField] private TMP_Text _spawnCountText;
        [SerializeField] private TMP_Text _activeCountText;

        protected override void OnActiveEntitiesChanged(int value)
        {
            _activeCountText.text = value.ToString();
        }

        protected override void OnCreateEntitiesChanged(int value)
        {
            _createCountText.text = value.ToString();
        }

        protected override void OnSpawnEntitiesChanged(int value)
        {
            _spawnCountText.text = value.ToString();
        }
    }
}


