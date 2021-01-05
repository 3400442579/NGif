using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Gif.Components;

namespace Example
{
	class ExampleMain
	{
		[STAThread]
		static void Main(string[] args)
		{
			/* create Gif */
			//you should replace filepath
			string[] imageFilePaths = new string[] { @"C:\Users\jxw\Desktop\gif\c\01a.png", @"C:\Users\jxw\Desktop\gif\c\01d.png", @"C:\Users\jxw\Desktop\gif\c\01c.png" };
			string outputFilePath = @"C: \Users\jxw\Desktop\gif\c\test.gif";
			AnimatedGifEncoder e = new AnimatedGifEncoder();
            
          
            e.Start();
			e.SetDelay(500);
			e.SetTransparent(Color.Transparent);
			//-1:no repeat,0:always repeat
			e.SetRepeat(0);
			for (int i = 0, count = imageFilePaths.Length; i < count; i++ ) 
			{
				e.AddFrame( Image.FromFile( imageFilePaths[i] ) );
			}
			e.Finish();
			e.Output(outputFilePath);

			/* extract Gif */
			string outputPath = "c:\\";
			GifDecoder gifDecoder = new GifDecoder();
			gifDecoder.Read( "c:\\test.gif" );
			for ( int i = 0, count = gifDecoder.GetFrameCount(); i < count; i++ ) 
			{
				Image frame = gifDecoder.GetFrame( i );  // frame i
				frame.Save( outputPath + Guid.NewGuid().ToString() + ".png", ImageFormat.Png );
			}
		}
	}
}
