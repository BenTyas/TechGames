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
		}
		
		public void Dispose()
		{
			textureInfo.Dispose();
		}
		
		public void Update(float deltaTime)
		{	
			
			min.X = sprite.Position.X;
			min.Y = sprite.Position.Y;
			max.X = sprite.Position.X+50;
			max.Y = sprite.Position.Y+55;
			box.Min = min;
			box.Max = max;
			
			if (!dead)
			{
				num = rnd.Next(1, 40);
				if (num == 3)
				{
					num2 = rnd.Next(1, 4);
				}
				if (num2 == 1)
				{
					sprite.Position = new Vector2(sprite.Position.X + 1, sprite.Position.Y);
				} else if (num2 == 2)
				{
					sprite.Position = new Vector2(sprite.Position.X - 1, sprite.Position.Y);
		
				} else if (num2 == 3)
				{
					sprite.Position = new Vector2(sprite.Position.X, sprite.Position.Y + 1);
				} 
				else
				{
					sprite.Position = new Vector2(sprite.Position.X, sprite.Position.Y - 1);
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
			sprite.Position = new Vector2(rnd.Next(0, 1271), rnd.Next(0, 794));
		}
	}
	
}

