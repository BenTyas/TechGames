using System;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace FlappyBird
{
	public class Background
	{	
		//Private variables.
		private SpriteUV 	sprite;
		private TextureInfo	textureInfo;
		private float		width;
		private Vector2 min;
		private Vector2 max;
		private Bounds2 box;
		
		
		//Public functions.
		public Background (Scene scene)
		{
			
			
			sprite	= new SpriteUV();
			
			textureInfo  		= new TextureInfo("/Application/textures/background.png");
			//Left
			sprite				= new SpriteUV(textureInfo);
			sprite.Quad.S 	= textureInfo.TextureSizef;
			
			
			//Get sprite bounds.
			Bounds2 b = sprite.Quad.Bounds2();
			width     = b.Point10.X;
			
			min.X = sprite.Position.X;
			min.Y = sprite.Position.Y;
			max.X = sprite.Position.X + width;
			max.Y = sprite.Position.Y + 794;
			box.Min = min;
			box.Max = max;
			
			scene.AddChild(sprite);
		}	
		
		public void Dispose()
		{
			textureInfo.Dispose();
		}
		
		public Bounds2 GetBox()
		{
			return box;
		}
		
		public void Update(float deltaTime)
		{			
			
			
			
		}
	}
}

