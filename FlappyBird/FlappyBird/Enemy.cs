using System;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace FlappyBird
{
	public class Enemy
	{
		private static SpriteUV 	sprite;
		private static TextureInfo	textureInfo;
		
		public Enemy (Scene scene)
		{
			textureInfo  = new TextureInfo("/Application/textures/monster.png");
			
			sprite	 		= new SpriteUV();
			sprite 			= new SpriteUV(textureInfo);	
			sprite.Quad.S 	= textureInfo.TextureSizef;
			sprite.Position = new Vector2(Director.Instance.GL.Context.GetViewport().Width/2,Director.Instance.GL.Context.GetViewport().Height/2);

			//Add to the current scene.
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

