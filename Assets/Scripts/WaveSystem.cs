using UnityEngine;
using UnityEngine.UI;

public class WaveSystem : MonoBehaviour
{
    public GameObject box_enemy;
    // public GameObject another_enemy_maybe;
    private int wavecounter = 5;
    private string wave_display;
    public Text counter;

    void Update()
    {
        wave_display = wavecounter.ToString();
        counter.text = wave_display;

        // start_wave();

        // 
    }

    private void start_wave()
    {
        if (wavecounter == 1)
        {
            //wave.Add(stuff);
            // spawn in enemies
            // if more than x enemies, stop spawning

            // if list is empty and all enemies defeated, start again
        }
    }
}
