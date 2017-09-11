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

        public static Vector2 Rotate2D(this GameObject gameObject, float degrees, Vector2 vector)
        {
            Vector3 vector3D = Quaternion.AngleAxis(degrees, -Vector3.forward) * vector;
            return new Vector2(vector3D.x,vector3D.y);
        }

    }
}
