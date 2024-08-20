using UnityEngine;
using UnityEngine.UI;

public class SettingsPanel : MonoBehaviour {
    [SerializeField] AudioSource MainAudioSource;
    [SerializeField] Slider volumeSlider;
    [SerializeField] GameObject settingsPanel;

    private void Start() {
        settingsPanel = gameObject;
    }

    private void Update() {
        MainAudioSource.volume = volumeSlider.value;
    }

    public void ToggleSettingPanel() {
        settingsPanel.SetActive(!settingsPanel.activeSelf);
    }
}
