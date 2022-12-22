using UnityEngine;

[CreateAssetMenu(menuName = "Configs/GUIPrefabsConfig", fileName = "GUIPrefabsConfig")]
public class GUIPrefabsConfig : ScriptableObject
{
    //game
    public GameObject TurretActionsPrefab;
    public GameObject TurretRadiusPrefab;
    public GameObject TurretSelectionPrefab;
    public GameObject UpgradePSPrefab;
    public GameObject PathLinePrefab;
    public GameObject FlyingTextPrefab;
    public GameObject ExplosionGoalPrefab;
    public GameObject HpBarPrefab;
    public GameObject GeneralInfoPanelPrefab;

    public GameObject WinPopupPrefab;
    public GameObject LosePopupPrefab;
    public GameObject SettingsPopupPrefab;
}
