using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChanger : SingletonComponent<ColorChanger>
{
    public static Color THEME_COLOR { get; private set; }
    //public static Color PANELS_COLOR { get; private set; }

    private Color _lightTheme;
    /*private Color _lightPanelsTheme;
    private Color _lightSettingsPanelTheme;*/

    private Color _darkTheme;
    /*private Color _darkPanelsTheme;
    private Color _darkSettingsPanelTheme;*/

    private bool isDark;

    [SerializeField]
    private List<GameObject> _panels;

    void Awake()
    {
        EventManager.Instance.colorChange.AddListener(ChangeColor);

        _lightTheme = new Color(0.8301887f, 0.8301887f, 0.8301887f);

        _darkTheme = new Color(0.1226415f, 0.1226415f, 0.1226415f);

        _panels = new List<GameObject>();
        for (int i = 0; i < this.transform.childCount; i++)
        {
            _panels.Add(this.transform.GetChild(i).gameObject);
        }

        isDark = false;
        if (PlayerPrefs.HasKey("ThemeColor"))
        {
            isDark = PlayerPrefs.GetInt("ThemeColor") == 1;
        }
        PlayerPrefs.SetInt("ThemeColor", isDark ? 1 : 0);
        print(PlayerPrefs.GetInt("ThemeColor") == 1);

        if (isDark)
            THEME_COLOR = _darkTheme;
        else
            THEME_COLOR = _lightTheme;

        SetColor();
    }
    private void SetColor()
    {
        Image panelImage;
        for (int i = 0; i < _panels.Count; i++)
            if (_panels[i].TryGetComponent<Image>(out panelImage))
            {
                panelImage.color = new Color (THEME_COLOR.r, THEME_COLOR.g, THEME_COLOR.b, panelImage.color.a);
            }
        Camera.main.backgroundColor = new Color(THEME_COLOR.r, THEME_COLOR.g, THEME_COLOR.b, Camera.main.backgroundColor.a);
    }
    public void ChangeColor()
    {
        isDark = !isDark;

        PlayerPrefs.SetInt("ThemeColor", isDark ? 1 : 0);

        if (isDark)
            THEME_COLOR = _darkTheme;
        else
            THEME_COLOR = _lightTheme;
        SetColor();
        
        print(PlayerPrefs.GetInt("ThemeColor") == 1);
    }
}
