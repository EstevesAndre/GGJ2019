using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public float gravity;
    public int pressure;
    public int atmosphere; //0 Breathable, 1 Useless, 2 Poisonous, 3 Acidic, 4 None.
    public int temperature;
    public int water;
    public int surface;
    public bool tidalLocked;
    public int numMoons;
    public int typeSun; //Single Star, Binary Star, White Dwarf


    // Start is called before the first frame update
    void Start()
    {
        gravity = Random.Range(0.1f, 10f);
        atmosphere = Random.Range(0, 5);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int getWeightedRandom(int[] weights) {
        // Get the total sum of all the weights.
        int weightSum = 0;
        for (int i = 0; i < weights.Length; ++i)
        {
            weightSum += weights[i];
        }
    
        // Step through all the possibilities, one by one, checking to see if each one is selected.
        int index = 0;
        int lastIndex = weights.Length - 1;
        while (index < lastIndex)
        {
            // Do a probability check with a likelihood of weights[index] / weightSum.
            if (Random.Range(0, weightSum) < weights[index])
            {
                return index;
            }
    
            // Remove the last item from the sum of total untested weights and try again.
            weightSum -= weights[index++];
        }
    
        // No other item was selected, so return very last index.
        return index;
    }
}
