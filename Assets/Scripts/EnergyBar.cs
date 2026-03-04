using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    public Slider slider;

    void Update()
    {
        slider.value = GameManager.Instance.levelTime;
    }
}
