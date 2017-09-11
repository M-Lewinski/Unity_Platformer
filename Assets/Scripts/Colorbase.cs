using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    [System.Serializable]
    public class Colorbase
    {
        public Color colorPlayer;
        public Color colorBlock;
        public Color colorWheel;
        public ColorId colorId;
        
        public Colorbase(Color colorPlayer, Color colorBlock, ColorId colorId)
        {
            this.colorPlayer = colorPlayer;
            this.colorBlock = colorBlock;
            this.colorId = colorId;
        }

        public Colorbase(Color colorPlayer, Color colorBlock, Color colorWheel, ColorId colorId)
        {
            this.colorPlayer = colorPlayer;
            this.colorBlock = colorBlock;
            this.colorWheel = colorWheel;
            this.colorId = colorId;
        }
    }

    public enum ColorId
    {
        Red,
        Blue,
        Green,
        Yellow
    } 
}
