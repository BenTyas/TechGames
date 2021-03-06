using System;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace FlappyBird
{
	public class Bird
	{
		//Private variables.
		private static SpriteUV 	sprite;
		private static TextureInfo	textureInfo;
		private static int			pushAmount = 100;
		private static float		yPositionBeforePush;
		private static bool			rise;
		private static float		angle;
		private static bool			alive;
		private Vector2 min;
		private Vector2 max;
		private Bounds2 box;
		public Vector2 playerMovement;
		public Vector2 playerRotation;
		public bool dead;
		public int health;
		
		public bool Alive { get{return alive;} set{alive = value;} }
		
		//Accessors.
		//public SpriteUV Sprite { get{return sprite;} }
		
		//Public functions.
		public Bird (Scene scene)
		{
			textureInfo  = new TextureInfo("/Application/textures/bird.png");
			
			sprite	 		= new SpriteUV();
			sprite 			= new SpriteUV(textureInfo);	
			sprite.Quad.S 	= textureInfo.TextureSizef;
			sprite.Position = new Vector2(Director.Instance.GL.Context.GetViewport().Width/2,Director.Instance.GL.Context.GetViewport().Height/2);
			//sprite.Pivot 	= new Vector2(0.5f,0.5f);
			angle = 0.0f;
			rise  = false;
			alive = true;
			health = 100;
			min = new Vector2(0,0);
			max = new Vector2(0,0);
			box = new Bounds2(min, max);
			dead = false;
			
			//Add to the current scene.
			scene.AddChild(sprite);
		}
		
		public void Dispose()
		{
			textureInfo.Dispose();
		}
		
		public void Update(float deltaTime)
		{	
		
			
				min.X = sprite.Position.X - (sprite.TextureInfo.TextureSizef.X/2);
				min.Y = sprite.Position.Y - (sprite.TextureInfo.TextureSizef.Y/2);
				max.X = sprite.Position.X + (sprite.TextureInfo.TextureSizef.X/2);  
				max.Y = sprite.Position.Y + (sprite.TextureInfo.TextureSizef.Y/2);
				box.Min = min;
				box.Max = max;
				angle = -(float)FMath.Atan2(playerRotation.X, playerRotation.Y);
				sprite.Angle = angle - 45.555f;
				sprite.CenterSprite();
			
		}	
		
		public void Up(bool down)
		{
			if (down)
			sprite.Position = new Vector2(sprite.Position.X, sprite.Position.Y + 3f);
		}
		public void Down(bool down)
		{
			if (down)
			sprite.Position = new Vector2(sprite.Position.X, sprite.Position.Y - 3f);
		}
		public void Left(bool down)
		{
			if (down)
			sprite.Position = new Vector2(sprite.Position.X - 3f, sprite.Position.Y);
		}
		public void Right(bool down)
		{
			if (down)
			sprite.Position = new Vector2(sprite.Position.X + 3f, sprite.Position.Y);
		}
		public Vector2 GetPos()
		{
			return sprite.Position;
		}
		public Bounds2 GetBox()
		{
			return box;
		}
		
		public Bounds2 GetBox2()
		{
			min.X = sprite.Position.X - (sprite.TextureInfo.TextureSizef.X/2) - 50;
			min.Y = sprite.Position.Y - (sprite.TextureInfo.TextureSizef.Y/2) - 50;
			max.X = sprite.Position.X + (sprite.TextureInfo.TextureSizef.X/2) + 50;  
			max.Y = sprite.Position.Y + (sprite.TextureInfo.TextureSizef.Y/2) + 50;
			box.Min = min;
			box.Max = max;
			return box;
		}
		
		public float getAngle()
		{
			return angle;
		}
		public Vector2 getTexInfo()
		{
			return sprite.TextureInfo.TextureSizef;
		}
		
		public void setPos(float x, float y)
		{
			sprite.Position = new Vector2(x, y);
		}
	}
}

