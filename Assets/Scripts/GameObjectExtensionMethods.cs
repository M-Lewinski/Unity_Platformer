using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Assets.Scripts
{
    public static class GameObjectExtensionMethods
    {
        public static void ChangeRendererColor(this GameObject gameObject, Color colorChange)
        {
            SpriteRenderer SpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            if (SpriteRenderer != null)
            {
                SpriteRenderer.color = colorChange;
            }
            else
            {
                Tilemap tilemap = gameObject.GetComponent<Tilemap>();
                tilemap.color = colorChange;
            }
        }
    }
}
