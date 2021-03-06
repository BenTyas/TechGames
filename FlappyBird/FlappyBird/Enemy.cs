using System;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace FlappyBird
{
	public class Enemy
	{
		private  SpriteUV 	sprite;
		private  TextureInfo	textureInfo;
		Random rnd = new Random();
		int num, num2;
		private Vector2 min;
		private Vector2 max;
		private Bounds2 box;
		public bool dead;
		public float speed;
		public Enemy (float startX, float startY, Scene scene)
		{
			textureInfo  = new TextureInfo("/Application/textures/monster.png");
			dead = false;
			sprite	 		= new SpriteUV();
			sprite 			= new SpriteUV(textureInfo);	
			sprite.Quad.S 	= textureInfo.TextureSizef;
			sprite.Position = new Vector2(startX, startY);
			min = new Vector2(0,0);
			max = new Vector2(0,0);
			box = new Bounds2(min, max);
			//Add to the current scene.
			scene.AddChild(sprite);
			speed = 1;
		}
		
		public void Dispose()
		{
			textureInfo.Dispose();
		}
		
		public void Update(float deltaTime)
		{	
			
			min.X = sprite.Position.X - (sprite.TextureInfo.TextureSizef.X/2);
			min.Y = sprite.Position.Y- (sprite.TextureInfo.TextureSizef.Y/2);
			max.X = sprite.Position.X+ (sprite.TextureInfo.TextureSizef.X/2);
			max.Y = sprite.Position.Y+ (sprite.TextureInfo.TextureSizef.Y/2);
			box.Min = min;
			box.Max = max;
			sprite.CenterSprite();
			if (!dead)
			{
				num = rnd.Next(1, 100);
				if (num == 3)
				{
					num2 = rnd.Next(1, 5);
				}
				if (num2 == 1)
				{
					sprite.Position = new Vector2(sprite.Position.X + speed, sprite.Position.Y);
					sprite.Angle = 300f;
				} else if (num2 == 2)
				{
					sprite.Position = new Vector2(sprite.Position.X - speed, sprite.Position.Y);
					sprite.Angle = 900f;
				} else if (num2 == 3)
				{
					sprite.Position = new Vector2(sprite.Position.X, sprite.Position.Y + speed);
					sprite.Angle = 0f;
				} 
				else
				{
					sprite.Position = new Vector2(sprite.Position.X, sprite.Position.Y - speed);
					sprite.Angle = 600f;
				}
				
				if (sprite.Position.X > 1271 - sprite.TextureInfo.TextureSizef.X) //Hits Right edge
				{
					num2 = 2; //Change direction
				}
				if (sprite.Position.X < 0)//Hits left edge
				{
					num2 = 1; //Change direction
				}
				if (sprite.Position.Y > 794 - sprite.TextureInfo.TextureSizef.Y) //Hits top
				{
					num2 = 4; //Change direction
				}
				if (sprite.Position.Y < 0) //Hits bottom
				{
					num2 = 3;
				}
				
		
			} else
			{
				sprite.Visible = false;
			}
		}	
		public Bounds2 GetBox()
		{
			return box;
		}
		public void setPos()
		{
			int num = rnd.Next(0,3);
			if (num == 0)
			sprite.Position = new Vector2(rnd.Next(1271, 1371), rnd.Next(0, 794));
			else if (num == 1)
			sprite.Position = new Vector2(rnd.Next(-100, 0), rnd.Next(0, 794));
			else if (num == 2)
			sprite.Position = new Vector2(rnd.Next(0, 1271), rnd.Next(794, 900));
			else
			sprite.Position = new Vector2(rnd.Next(0, 1271), rnd.Next(-100, 0));

		}
		public void setInvis()
		{
			sprite.Visible = false;
		}
	}
	
}

