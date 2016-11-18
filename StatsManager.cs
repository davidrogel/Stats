using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Clase que lleva a su cargo las estadisticas del jugador
/// </summary>
[RequireComponent(typeof(HUDStats))]
public class StatsManager : MonoBehaviour
{
    /// <summary>
    /// Array de estadisticas
    /// </summary>
    public Stat[] stats;

    /// <summary>
    /// cantidad de puntos a asignar
    /// </summary>
    int pointsToAsign;

    /// <summary>
    /// mostrar por consola las estadisticas
    /// </summary>
    #region Console
    public bool seeInConsole;
    WaitForSeconds wait = new WaitForSeconds(1);

    IEnumerator SeeInConsole()
    {
        yield return wait;
        if (seeInConsole)
        {
            foreach (Stat stat in stats)
            {
                print(stat.GetName() + " " + stat.GetValue());
            }
        }
        StartCoroutine(SeeInConsole());
    }
    #endregion

    void Start () {
        StartCoroutine(SeeInConsole());

        SetValueStats();
    }
	
	public int GetPointsToAsign()
    {
        return pointsToAsign;
    }
    // añade un punto
    public void AddPoint()
    {
        pointsToAsign++;
    }
    // quita un punto
    public void RemovePoint()
    {
        pointsToAsign--;
    }

    /// <summary>
    /// Nos de vuelve el valor de la estadistica pedida. Si la estadistica no existe devuelve 0
    /// </summary>
    public float GetValorEstadistica(string nombreStat)
    {
        float value = 0;        
        foreach(Stat stat in stats)
        {
            if(stat.GetName() == nombreStat)
            {
                value = stat.GetValue();
            }
        }
        return value;
    }
    // inicializa los valores iniciales de las estadisticas y los puntos a asignar por defecto
    public void SetValueStats()
    {
        foreach (Stat stat in stats)
        {
            stat.SetFinalValue(stat.GetInitialValue());
        }
        pointsToAsign = 10;
    }
}
