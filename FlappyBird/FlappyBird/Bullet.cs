using System;
using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace FlappyBird
{
	public class Bullet
	{
		//Private variables.
		private static SpriteUV 	sprite;
		private static TextureInfo	textureInfo;
		private static bool shoot;
		private static Vector2 StartPos;
		private Vector2 min;
		private Vector2 max;
		private Bounds2 box;
		private Vector2 direction;
		private Vector2 origin;
		private int speed = 10;
		public int ammo = 40;
		
		
		public Bullet (Scene scene)
		{
			textureInfo  = new TextureInfo("/Application/textures/bullet.png");
			
			sprite	 		= new SpriteUV();
			sprite 			= new SpriteUV(textureInfo);	
			sprite.Quad.S 	= textureInfo.TextureSizef;
			min = new Vector2(0,0);
			max = new Vector2(0,0);
			box = new Bounds2(min, max);
			shoot = false;
			//Add to the current scene.
			scene.AddChild(sprite);
		}
		
		public void Dispose()
		{
			textureInfo.Dispose();
		}
		
		public void Update(float deltaTime)
		{			
			if (shoot)
			{
				sprite.Position = new Vector2 (sprite.Position.X + direction.X*speed, sprite.Position.Y + direction.Y*speed);
				
				if (Vector2.Distance(sprite.Position, origin) > 400)
				{
					shoot = false;
					sprite.Position = new Vector2(-500,-500);
				}
			}
			
			min.X = sprite.Position.X;
			min.Y = sprite.Position.Y;
			max.X = sprite.Position.X+5;
			max.Y = sprite.Position.Y+13;
			box.Min = min;
			box.Max = max;
			
		}	
		
		public void Shoot(Vector2 Pos, float angle, bool mGun)
		{
			if (!shoot)
			{
				if (mGun && ammo >= 0)
				{
					speed = 40;
					ammo--;
				}
				else
				{
					ammo = 0;
					speed = 10;
				}
				
				
				sprite.Position = new Vector2 (Pos.X + 11, Pos.Y - 8);
				origin = Pos;
				direction = Vector2FromAngle(angle - 44f, true);
				sprite.RotationNormalize = direction;
				sprite.Visible = true;
				shoot = true;
			}
		}
		public Bounds2 GetBox()
		{
			return box;
		}
		
		public static Vector2 Vector2FromAngle(float angle, bool normalize = true)
		{
		    Vector2 vector = new Vector2((float)FMath.Cos(angle), (float)FMath.Sin(angle));
		    if (vector != Vector2.Zero && normalize) //Basic math to find out the vector from the angle
		        vector.Normalize();
		    return vector;
		}
	}
}


