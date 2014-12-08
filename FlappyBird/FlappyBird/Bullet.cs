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
		
		public Bullet (Scene scene)
		{
			textureInfo  = new TextureInfo("/Application/textures/bullet.png");
			
			sprite	 		= new SpriteUV();
			sprite 			= new SpriteUV(textureInfo);	
			sprite.Quad.S 	= textureInfo.TextureSizef;
	
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
				sprite.Position = new Vector2 (sprite.Position.X, sprite.Position.Y + 5);
				
				if (sprite.Position.Y > StartPos.Y + 150)
				{
					shoot = false;
					sprite.Position = new Vector2(-500,-500);
				}
			}
			
		}	
		
		public void Shoot(Vector2 Pos)
		{
			if (!shoot)
			{
				StartPos = new Vector2(Pos.X+20,Pos.Y+40);
				sprite.Position = new Vector2(Pos.X+20,Pos.Y+40);
				shoot = true;
			}
		}
	}
}


