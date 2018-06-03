#version 120
varying vec2 texcoord;
varying vec4 color;
void main() {
    texcoord = vec2(gl_MultiTexCoord0);
    color = gl_Color;
	gl_Position = gl_ModelViewProjectionMatrix * gl_Vertex;
}