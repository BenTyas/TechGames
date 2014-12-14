using System;
using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace FlappyBird
{
	public class Pickup
	{
		private  SpriteUV 	sprite;
		private  TextureInfo	textureInfo;
		private Vector2 min;
		private Vector2 max;
		private Bounds2 box;
		public bool collected;
		
		public Pickup (float startX, float startY, Scene scene)
		{
			textureInfo  = new TextureInfo("/Application/textures/gun.png");
			sprite	 		= new SpriteUV();
			sprite 			= new SpriteUV(textureInfo);	
			sprite.Quad.S 	= textureInfo.TextureSizef;
			sprite.Position = new Vector2(startX, startY);
			sprite.Visible = true;
			scene.AddChild(sprite);
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
			
			
			
		}
		public Bounds2 GetBox()
		{
			return box;
		}
		public void pickedUp()
		{
			sprite.Visible = false;
			collected = true;
		}
		
		public void setPos(float x, float y)
		{
			sprite.Position = new Vector2(x, y);
		}
		
	}
}

