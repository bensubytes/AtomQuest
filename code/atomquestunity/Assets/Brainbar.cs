using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Brainbar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxBrain(int knowledge)
    {
        slider.maxValue = knowledge;
        slider.value = knowledge;
    }

    public void SetBrain(int knowledge)
    {
        slider.value = knowledge;
    }
}
