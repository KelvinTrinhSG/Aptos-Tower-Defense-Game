using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class OptionsUI : MonoBehaviour
{
    [SerializeField] private SoundManager soundManager;
    [SerializeField] private MusicManager musicManager;
    private TextMeshProUGUI soundVolumeText;
    private TextMeshProUGUI musicVolumeText;
    private void Awake()
    {
        soundVolumeText = transform.Find("soundVolumnText").GetComponent<TextMeshProUGUI>();
        musicVolumeText = transform.Find("musicVolumnText").GetComponent<TextMeshProUGUI>();

        transform.Find("soundIncreaseBtn").GetComponent<Button>().onClick.AddListener(() => {
            soundManager.IncreaseVolumn();
            UpdateText();
        });
        transform.Find("soundDecreaseBtn").GetComponent<Button>().onClick.AddListener(() => {
            soundManager.DecreaseVolumn();
            UpdateText();
        });
        transform.Find("musicIncreaseBtn").GetComponent<Button>().onClick.AddListener(() => {
            musicManager.IncreaseVolumn();
            UpdateText();
        });
        transform.Find("musicDecreaseBtn").GetComponent<Button>().onClick.AddListener(() => {
            musicManager.DecreaseVolumn();
            UpdateText();
        });
        transform.Find("mainMenuBtn").GetComponent<Button>().onClick.AddListener(() => {
            ResourceBoost.Instance.ResetBoostValue();
            Time.timeScale = 1f;
            GameSceneManager.Load(GameSceneManager.Scene.MainMenuAptos);
        });
    }

    private void Start()
    {
        UpdateText();
        gameObject.SetActive(false);
    }
    private void UpdateText() {
        soundVolumeText.SetText(Mathf.RoundToInt(soundManager.GetVolume() * 10).ToString());
        musicVolumeText.SetText(Mathf.RoundToInt(musicManager.GetVolume() * 10).ToString());
    }

    public void ToggleVisible() {
        gameObject.SetActive(!gameObject.activeSelf);
        if (gameObject.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else {
            Time.timeScale = 1f;
        }
    }
}
