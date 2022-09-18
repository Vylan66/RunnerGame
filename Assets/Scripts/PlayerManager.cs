using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; }
    public PlayerHealthBar PlayerHealthBar { get; private set; }
    [SerializeField] public Text ScoreText;
    public int PlayerScore { get; set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
        PlayerHealthBar = GetComponentInChildren<PlayerHealthBar>();
        ScoreText = GetComponentInChildren<Text>();
    }
}