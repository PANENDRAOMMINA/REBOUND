using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Upgrade_System : MonoBehaviour
{
    public Upgrade_attributes[] upgrades = new Upgrade_attributes[2];
    public int length = 5;

    public TMP_Text orbcount_text;

    private Sphere _sphere;

    public TMP_Text Force_Cost_Text;
    public TMP_Text Laser_Cost_Text;

    public int increase_force_index;

    private void Awake()
    {
        _sphere = FindObjectOfType<Sphere>();
    }

    public void Update()
    {
        var v1 = "COST : " + upgrades[0].cost + " ORBS";
        Laser_Cost_Text.text = v1;

        var v2 = "COST : " + upgrades[1].cost + " ORBS";
        Force_Cost_Text.text = v2;

        var v3 = "ORBS : " + _sphere.orb_count;
        orbcount_text.text = v3;
    }


    public void Upgrade_Laser_radius()
    {
        if(upgrades[0].upgrade_point<3&&_sphere.orb_count>=upgrades[0].cost)
        {
            upgrades[0].upgrade_point++;
            upgrades[0].levelup_slider.value += 0.33f;
            _sphere.orb_count -= upgrades[0].cost;
            upgrades[0].cost++;
            FindObjectOfType<Shoot_Laser>().length += 2;
        }
         
    }

    public void Upgrade_Force_Radius()
    {
        if(upgrades[1].upgrade_point< 3&&_sphere.orb_count>= upgrades[1].cost)
        {
            upgrades[1].upgrade_point++;
            upgrades[1].levelup_slider.value += 0.33f;
            _sphere.orb_count -= upgrades[1].cost;
            upgrades[1].cost++;
            FindObjectOfType<Sphere>().Force_index += increase_force_index;
        }
    }

}
