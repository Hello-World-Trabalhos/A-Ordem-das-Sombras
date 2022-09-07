using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderValueShower : MonoBehaviour
{
    private Text enemySliderCount;
    private Slider enemySlider;

    void Start()
    {
        enemySliderCount = gameObject.transform.Find("EnemiesSliderCount").GetComponent<Text>();
        enemySlider = gameObject.transform.Find("EnemySlider").GetComponent<Slider>();

        enemySlider.minValue = ScenarioGeneratiorViewerConstants.MIN_ENEMIES_AMMOUNT;
        enemySlider.maxValue = ScenarioGeneratiorViewerConstants.MAX_ENEMIES_AMMOUNT;
    }

    public void UpdateEnemySliderCount(float sliderValue)
    {
        if (enemySliderCount != null && enemySliderCount.text != null)
        {
            enemySliderCount.text = sliderValue.ToString();
        }
    }
}
