using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public int selectedVolumeView = 100;
    public int selectedVolume = 10;
    public Text selectedVolumeText;
    public Text selectedScreenMode;
    public AudioMixer audioMixer;
    public List<ResItem> resolutions = new List<ResItem>();
    public int selectedResolutions;
    public Text resolutionLabel;

    public static OptionsMenu instance;
    
    //Singleton
    private void Awake() {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }
    
    
    public void Start()
    {
        selectedVolumeView = PlayerPrefs.GetInt("currentSound");
        selectedResolutions = PlayerPrefs.GetInt("currentResolution");
        
        selectedVolumeView = 100;
        selectedVolumeText.text = selectedVolumeView.ToString();
        selectedVolume = 8;
    }
    
    private void Update()
    {
        selectedVolumeText.text = selectedVolumeView.ToString();
    }
    
    public void ResolutionLeft()
    {
        selectedResolutions--;
        if (selectedVolume < 0)
        {
            selectedVolume = 0;
        }
        
        UpdateResLabel();
    }
    
    public void ResolutionRight()
    {
        selectedResolutions++;
        if (selectedVolume < resolutions.Count -1)
        {
            selectedVolume = resolutions.Count -1;
        }
        
        UpdateResLabel();
    }
    
    public void UpdateResLabel()
    {
        resolutionLabel.text = resolutions[selectedResolutions].horizonal.ToString() + " X " + resolutions[selectedResolutions].vertical.ToString();
    }
    
    public void ApplyResolution()
    {
        SaveSystem();
        Screen.SetResolution(resolutions[selectedResolutions].horizonal, resolutions[selectedResolutions].vertical, FullScreenMode.FullScreenWindow);
    }
   
    public void VolumeLeft()
    {
        selectedVolumeView--;
        selectedVolume--;
        
        audioMixer.SetFloat("Volume", selectedVolume);
        if (selectedVolume < -70)
        {
            selectedVolume = 80;
        }
        
        if (selectedVolumeView < 0)
        {
            selectedVolumeView = 0;
        }
    }
    
    public void VolumeRight()
    {
        selectedVolumeView++;
        selectedVolume++;
        
        audioMixer.SetFloat("Volume", selectedVolume);
        if (selectedVolume > 20)
        {
            selectedVolume = 20;
        }
        if (selectedVolumeView > 80)
        {
            selectedVolumeView = 80;
        }
        
    }
    
    public void ScreenLeft(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
        selectedScreenMode.text = "Windowed";
    }
    
    public void ScreenRight(bool isFullScreen)
    {
        Screen.fullScreen = !isFullScreen;
        selectedScreenMode.text = "Fullscreen";
    }
    
    [System.Serializable]
    public class ResItem
    {
        public int horizonal, vertical;
    }

    public void SaveSystem()
    {
        PlayerPrefs.SetInt("currentResolution", selectedResolutions);
        PlayerPrefs.SetInt("currentSound", selectedVolumeView);
        PlayerPrefs.Save();
    }
    
}


