using System;
using System.Collections.Generic;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;
using Sce.PlayStation.HighLevel.UI;
	
namespace FlappyBird
{
	public class AppMain
	{
		private static Sce.PlayStation.HighLevel.GameEngine2D.Scene 	gameScene;
		private static Sce.PlayStation.HighLevel.UI.Scene 				uiScene;
		private static Sce.PlayStation.HighLevel.UI.Label				scoreLabel;
		//private static Sce.PlayStation.HighLevel.GameEngine2D.Base.Camera2D camara;
		private static Obstacle[]	obstacles;
		private static Bird			bird;
		private static Bullet bullet;
		private static Background background;
		private static Camera2D cam;
		
		public static void Main (string[] args)
		{
			Initialize();
			
			//Game loop
			bool quitGame = false;
			while (!quitGame) 
			{
				Update ();
				
				Director.Instance.Update();
				Director.Instance.Render();
				UISystem.Render();
				
				Director.Instance.GL.Context.SwapBuffers();
				Director.Instance.PostSwap();
			}
			
			//Clean up after ourselves.
			bird.Dispose();
			foreach(Obstacle obstacle in obstacles)
				obstacle.Dispose();
		background.Dispose();
			
			Director.Terminate ();
		}

		public static void Initialize ()
		{
			//Set up director and UISystem.
			Director.Initialize ();
			UISystem.Initialize(Director.Instance.GL.Context);
			
			//Set game scene
			gameScene = new Sce.PlayStation.HighLevel.GameEngine2D.Scene();
			cam = gameScene.Camera as Camera2D;	
			cam.SetViewFromWidthAndCenter(1024, new Vector2((float)1024, (float)768) / 2.0f);
			

			//Set the ui scene.
			uiScene = new Sce.PlayStation.HighLevel.UI.Scene();
			Panel panel  = new Panel();
			panel.Width  = Director.Instance.GL.Context.GetViewport().Width;
			panel.Height = Director.Instance.GL.Context.GetViewport().Height;
			scoreLabel = new Sce.PlayStation.HighLevel.UI.Label();
			scoreLabel.HorizontalAlignment = HorizontalAlignment.Center;
			scoreLabel.VerticalAlignment = VerticalAlignment.Top;
			scoreLabel.SetPosition(
				Director.Instance.GL.Context.GetViewport().Width/2 - scoreLabel.Width/2,
				Director.Instance.GL.Context.GetViewport().Height*0.1f - scoreLabel.Height/2);
			scoreLabel.Text = "0";
			panel.AddChildLast(scoreLabel);
			uiScene.RootWidget.AddChildLast(panel);
			UISystem.SetScene(uiScene);
			
			background = new Background(gameScene);
			
			//Create the flappy douche
			bird = new Bird(gameScene);
			bullet = new Bullet(gameScene);
			
			//Run the scene.
			Director.Instance.RunWithScene(gameScene, true);
		}
		
		public static void Update()
		{
			if (Input2.GamePad0.Up.Down && bird.GetPos().Y < 744)
			bird.Up(true);
			if (Input2.GamePad0.Down.Down && bird.GetPos().Y > 0)
			bird.Down(true);
			
			if (Input2.GamePad0.Left.Down && bird.GetPos().X > 0)
			bird.Left(true);
			if (Input2.GamePad0.Right.Down && bird.GetPos().X < 1238)
			bird.Right(true);
					
			if (Input2.GamePad0.Cross.Down)
			bullet.Shoot(bird.GetPos());
			
			bullet.Update(0.0f);
			bird.Update(0.0f);			
			background.Update(0.0f);
			
			cam.SetViewX( new Vector2(Director.Instance.GL.Context.GetViewport().Width*0.5f,0.0f), bird.GetPos());
			
			
			//Determine whether the player tapped the screen
			var touches = Touch.GetData(0);
			//If tapped, inform the bird					
		}
		
		public static bool Collision(Bounds2 box, Bounds2 box2)
		{
			if (box.Overlaps(box2))
		    {	
				return true;
			}
			return false;
		}
		
	}
}

