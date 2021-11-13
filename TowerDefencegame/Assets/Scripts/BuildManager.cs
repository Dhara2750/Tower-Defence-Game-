using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager ins;
    void Awake() {
        if(ins != null) {
            Debug.Log("Many gameobj");
            return;
        }
        ins = this;
    }

    public GameObject standardturretprefab;
    //void Start() {
    //  turrettobuild = standardturretprefab;    
    //}
    public GameObject MissileLauncherprefab;

    private GameObject turrettobuild;
  
    public GameObject GetTurretToBuild() {
        return turrettobuild;
    }

    public void SetTurrettobuild(GameObject turret) {
        turrettobuild = turret; 
    }
}
