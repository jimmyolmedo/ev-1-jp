using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public IntVariable hpHacha;
    public IntVariable da�oHacha;
    public IntVariable gastoPorGolpe;
    public IntVariable lvlHacha;

    public TextMeshProUGUI hpHachaTxt, da�ohachaTxt, gastoPorGolpeTxt, lvlHachaTxt;

    private void Update()
    {
        hpHachaTxt.text = "HP Hacha " + hpHacha.valor.ToString();
        da�ohachaTxt.text = "Da�o Hacha " + da�oHacha.valor.ToString();
        gastoPorGolpeTxt.text = "Gasto por Golpe " + gastoPorGolpe.valor.ToString();
        lvlHachaTxt.text = "LVL Hacha " + lvlHacha.valor.ToString();
    }


}
