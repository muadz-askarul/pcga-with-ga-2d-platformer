using System.Collections.Generic;

public static class Gen{

    // Jenis Gen
    public static string[] genes = { "","G", "GS", "GW", "G2W", "G3W", "GWS", "G2WS" };
    
    // Value dari setiap Gen
    public static Dictionary<string, int> genValue = new Dictionary<string, int>()
    {
        {genes[0], 1},{genes[1], 1},{genes[2], 3},{genes[3],2},{genes[4],3},{genes[5],4},{genes[6],4},{genes[7],5}
    };



}
