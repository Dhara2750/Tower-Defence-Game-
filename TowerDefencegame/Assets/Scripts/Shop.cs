using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;
    void Start() {
        buildManager = BuildManager.ins; 
    }
    public void purchasestandardturret() {
        Debug.Log("Selected Standard Turret");
        buildManager.SetTurrettobuild(buildManager.standardturretprefab);
    }
    public void MissileLauncher() {
        Debug.Log("Missile Launcher");
        buildManager.SetTurrettobuild(buildManager.MissileLauncherprefab);
    }
}
