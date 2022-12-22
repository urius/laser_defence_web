using UnityEngine;

[CreateAssetMenu(menuName = "Configs/UIPrefabsConfig", fileName = "UIPrefabsConfig")]
public class UIPrefabsConfig : ScriptableObject
{
    public static UIPrefabsConfig Instance { get; private set; }
    private void OnEnable()
    {
        Instance = this;
    }

    //main screen
    public GameObject MainMenuScreenPrefab;
    public GameObject SelectLevelScreenPrefab;
    public GameObject SelectLevelItemContainerPrefab;
    public GameObject SelectLevelItemPrefab;
    public GameObject SelectLevelItemSelectionPrefab;
    public GameObject BoostersScreenPrefab;
    public GameObject BoosterItemPrefab;

    public GameObject SettingsForStartScreenPrefab;
    public GameObject SpecialThanksPrefab;
}
