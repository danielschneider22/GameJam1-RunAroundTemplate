using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireCharge : MonoBehaviour
{

    public int numCharges;
    public GridLayoutGroup gridLayout;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl) && numCharges > 0)
        {
            gridLayout.transform.GetChild(numCharges - 1).gameObject.SetActive(false);
            foreach (GameObject a in GameObject.FindGameObjectsWithTag("Missile"))
            {
                a.GetComponent<HomingMissile>().missileLastTime = 0;
            }
            numCharges -= 1;
        }
    }
}
