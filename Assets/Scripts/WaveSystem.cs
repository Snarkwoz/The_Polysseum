using UnityEngine;
using UnityEngine.UI;

public class WaveSystem : MonoBehaviour
{
    public GameObject box_enemy;
    // public GameObject another_enemy_maybe;
    private string wavecounter = "1";
    public Text counter;

    void Update()
    {
        counter.text = wavecounter;

        // generate_wave()
        
        // spawn in enemies
        // if more than x enemies, stop spawning

        // if list is empty and all enemies defeated, start again
    }

    private void generate_wave()
    {
        if (wavecounter == "1")
        {
            
            //wave.Add(stuff);
        }
    }
    
}
