using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static Tao.OpenGl.Gl;

namespace RoomsEditor.Shaders {
	class ShaderProgram {
		private int programID;

		public ShaderProgram() {
			programID = glCreateProgramObjectARB();
		}

		public ShaderProgram addFragment(byte[] data) {
			return add(data, GL_FRAGMENT_SHADER_ARB);
		}

		public ShaderProgram addVertex(byte[] data) {
			return add(data, GL_VERTEX_SHADER_ARB);
		}

		public ShaderProgram add(byte[] data, int shaderType) {
			int shaderID = glCreateShaderObjectARB(shaderType);
			string[] file = Encoding.UTF8.GetString(data).Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
			int lenght = Encoding.UTF8.GetString(data).Length + 1;
			file[0] += '\n';

			glShaderSourceARB(shaderID, 1, file, ref lenght);
			glCompileShaderARB(shaderID);

			int param;
			glGetObjectParameterivARB(shaderID, GL_OBJECT_COMPILE_STATUS_ARB, out param);
			if (param == GL_FALSE) { 
				StringBuilder builder = new StringBuilder();
				builder.Capacity = 999999;
				int hz;
				glGetShaderInfoLog(shaderID, 99999, out hz, builder);
				throw new Exception("Shader compilation error!\n" + builder.ToString());
			}

			glAttachObjectARB(programID, shaderID);
			return this;
		}

		public ShaderProgram compile() {
			glLinkProgramARB(programID);

			int link_ok;
			glGetProgramiv(programID, GL_LINK_STATUS, out link_ok);

			if (link_ok == 0) {
				int maxLength;
				int length;
				glGetProgramiv(programID, GL_INFO_LOG_LENGTH, out maxLength);
				StringBuilder builder = new StringBuilder();
				builder.Capacity = 999999;
				glGetProgramInfoLog(programID, maxLength, out length, builder);
				throw new Exception(builder.ToString());
			}
			return this;
		}

		public void start() {
			glUseProgramObjectARB(programID);
		}

		public void stop() {
			glUseProgramObjectARB(0);
		}

		public int getUniform(String name) {
			return glGetUniformLocationARB(programID, name);
		}
	}
}
