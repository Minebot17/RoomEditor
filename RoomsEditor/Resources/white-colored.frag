#version 120
varying vec2 texcoord;
varying vec4 color;
uniform sampler2D texture;
void main() {
    vec4 original = texture2D(texture, texcoord);
    float brigness = (original.r + original.g + original.b)/3.0;
    gl_FragColor = color * brigness;
}