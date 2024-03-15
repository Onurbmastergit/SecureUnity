using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build
{
    public string name;
    public string info;
    public int woodCost;
    public int stoneCost;
    public int metalCost;
    public int tecnologyCost;

    public Build(string name, string info, int woodCost, int stoneCost, int metalCost, int tecnologyCost)
    {
        this.name = name;
        this.info = info;
        this.woodCost = woodCost;
        this.stoneCost = stoneCost;
        this.metalCost = metalCost;
        this.tecnologyCost = tecnologyCost;
    }
}

public class BuildSystem : MonoBehaviour
{
    public List<Build> buildList = new List<Build>();

    void Start()
    {
        //buildList.Add(new Build());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
