using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public IntVariable hpHacha;
    public IntVariable dañoHacha;
    public IntVariable gastoPorGolpe;
    public IntVariable lvlHacha;

    public TextMeshProUGUI hpHachaTxt, dañohachaTxt, gastoPorGolpeTxt, lvlHachaTxt;

    private void Update()
    {
        hpHachaTxt.text = "HP Hacha " + hpHacha.valor.ToString();
        dañohachaTxt.text = "Daño Hacha " + dañoHacha.valor.ToString();
        gastoPorGolpeTxt.text = "Gasto por Golpe " + gastoPorGolpe.valor.ToString();
        lvlHachaTxt.text = "LVL Hacha " + lvlHacha.valor.ToString();
    }


}
