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
			
						
			scene.AddChild(sprite);
		}	
		
		public void Dispose()
		{
			textureInfo.Dispose();
		}
		
		public void Update(float deltaTime)
		{			
			
			
			
		}
	}
}

