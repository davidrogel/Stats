using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Clase que lleva a su cargo la relación del canvas con las estadisticas
/// </summary>
public class HUDStats : MonoBehaviour {

    /// <summary>
    /// Script del las estadisticas
    /// </summary>
    public StatsManager statsManagerScript;
    /// <summary>
    /// GameObject del menu
    /// </summary>
    public GameObject menu;

    /// <summary>
    /// Array de textos de los nombres de las estadisticas
    /// </summary>
    [SerializeField] Text[] textName;
    /// <summary>
    /// Array de textos de los valores de las estadisticas
    /// </summary>
    [SerializeField] Text[] textValue;
    /// <summary>
    /// Texto de los puntos a asignar
    /// </summary>
    [SerializeField] Text textPointsToAsign;

    void Start()
    {
        SetNames();
    }

    void Update()
    {
        // mostrar el valor de la estadistica
        for (int i = 0; i < statsManagerScript.stats.Length; i++)
        {
            textValue[i].text = statsManagerScript.stats[i].GetInitialValue().ToString();
        }

        // mostrar puntos a asignar
        textPointsToAsign.text = "Points To Asign: " + statsManagerScript.GetPointsToAsign().ToString();

        // mostrar el menú si esta desactivado
        if (menu.activeSelf == false)
        {
            if (Input.GetKeyDown(KeyCode.P))
                menu.SetActive(true);
        }
    }

    /// <summary>
    /// establece los nombres de las estadisticas
    /// </summary>
    void SetNames()
    {
        for (int i = 0; i < statsManagerScript.stats.Length; i++)
        {
            textName[i].text = statsManagerScript.stats[i].GetName();
        }
    }

    public void SetHUDValues()
    {
        statsManagerScript.SetValueStats();
    }

    #region botones
    /// <summary>
    /// boton para añadir un punto a cierta estadistica
    /// </summary>
    /// <param name="nameStat"></param>
    public void ButtonAdd(string nameStat)
    {
        foreach (Stat stat in statsManagerScript.stats)
        {
            if (stat.GetName() == nameStat)
            {
                if (statsManagerScript.GetPointsToAsign() > 0)
                {
                    statsManagerScript.RemovePoint();
                    stat.AddPoint();
                }
            }
        }
    }
    /// <summary>
    /// boton para quitar un punto a cierta estadistica
    /// </summary>
    /// <param name="nameStat"></param>
    public void ButtonRemove(string nameStat)
    {
        foreach (Stat stat in statsManagerScript.stats)
        {
            if (stat.GetName() == nameStat)
            {
                if (stat.GetInitialValue() > stat.GetValue())
                {
                    statsManagerScript.AddPoint();
                    stat.RemovePoint();
                }
            }
        }
    }
    #endregion
}
