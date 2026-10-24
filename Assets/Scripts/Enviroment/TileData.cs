using System;

namespace Enviroment
{
    [Serializable]
    public class TileData
    {
        public int x {get;private set;}
        public int y { get; private set; }
        public string tileName  { get; private set; }
        public TileData(int x, int y, string tileName)
        {
            this.x = x;
            this.y = y;
            this.tileName = tileName;
        }
    }
}