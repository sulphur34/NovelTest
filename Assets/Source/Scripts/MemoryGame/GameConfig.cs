using MemoryGame.UI;
using UnityEngine;

namespace MemoryGame
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "GameConfig")]
    public class GameConfig : ScriptableObject
    {
        [field: SerializeField] public PairButton PairButtonPrefab { get; private set; }
        [field: SerializeField] public Sprite[] OpenSprites { get; private set; }
        [field: SerializeField] public int PairsCount { get; private set; }
        [field: SerializeField] public int AttemptsNumber { get; private set; }
    }
}