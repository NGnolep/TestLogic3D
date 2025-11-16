using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class AmmoUIManager : MonoBehaviour
{
    public static AmmoUIManager Instance;

    public TextMeshProUGUI ammoText;

    void Awake() => Instance = this;

    public void UpdateAmmo(int ammo)
    {
        ammoText.text = "Ammo: " + ammo;
    }
}
