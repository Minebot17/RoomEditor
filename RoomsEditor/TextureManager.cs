using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Tao.FreeGlut;
using Tao.OpenGl;
using Tao.Platform.Windows;
using static Tao.OpenGl.Gl;
using static Tao.OpenGl.Glu;
using static Tao.FreeGlut.Glut;
using static Tao.DevIl.Il;

namespace RoomsEditor {
	public static class TextureManager {
		private static Dictionary<string, uint> textureMap = new Dictionary<string, uint>();

		public static void BindTexture(string name) {
			if (textureMap[name] != 0)
				glBindTexture(GL_TEXTURE_2D, textureMap[name]);
		}

		public static void LoadAllTextures() {
			string[] textures = Directory.GetFiles("textures");
			for (int i = 0; i < textures.Length; i++)
				LoadTexture(textures[i]);
		}

		public static void LoadTexture(string path) {
			int id = 0;
			ilGenImages(1, out id);
			ilBindImage(id);
			if (ilLoadImage(path)) {
				int width = ilGetInteger(IL_IMAGE_WIDTH);
				int height = ilGetInteger(IL_IMAGE_HEIGHT);
				int bitspp = ilGetInteger(IL_IMAGE_BITS_PER_PIXEL);
				uint finishID = 0;
				switch (bitspp) {
					case 24:
						finishID = MakeGlTexture(GL_RGB, ilGetData(), width, height);
						break;
					case 32:
						finishID = MakeGlTexture(GL_RGBA, ilGetData(), width, height);
						break;
				}
				ilDeleteImages(1, ref id);
				string name = path.Substring(path.LastIndexOf("\\") + 1);
				textureMap.Add(name, finishID);
			}
			else
				Console.WriteLine(ilGetError());
		}

		private static uint MakeGlTexture(int Format, IntPtr pixels, int w, int h) {
			// идентификатор текстурного объекта
			uint texObject;
			// генерируем текстурный объект
			Gl.glGenTextures(1, out texObject);
			// устанавливаем режим упаковки пикселей 
			Gl.glPixelStorei( Gl.GL_UNPACK_ALIGNMENT, 1);
			// создаем привязку к только что созданной текстуре 
			Gl.glBindTexture( Gl.GL_TEXTURE_2D, texObject);
			// устанавливаем режим фильтрации и повторения текстуры 
			Gl.glTexParameteri( Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_NEAREST);
			Gl.glTexParameteri( Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_S, Gl.GL_REPEAT);
			Gl.glTexParameteri( Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_T, Gl.GL_REPEAT);
			Gl.glTexParameteri( Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_NEAREST);
			Gl.glTexEnvf( Gl.GL_TEXTURE_ENV, Gl.GL_TEXTURE_ENV_MODE, Gl.GL_REPLACE);
			// создаем RGB или RGBA текстуру 
			switch (Format) {
				case Gl.GL_RGB: Gl.glTexImage2D( Gl.GL_TEXTURE_2D, 0, Gl.GL_RGB, w, h, 0, Gl.GL_RGB, Gl.GL_UNSIGNED_BYTE, pixels);
					break;
				case Gl.GL_RGBA: Gl.glTexImage2D( Gl.GL_TEXTURE_2D, 0, Gl.GL_RGBA, w, h, 0, Gl.GL_RGBA, Gl.GL_UNSIGNED_BYTE, pixels);
					break;
			} // возвращаем идентификатор текстурного объекта
			return texObject;
		}
	}
}
