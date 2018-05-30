#version 120
varying vec2 texcoord;
varying vec4 color;
uniform sampler2D texture;
uniform float procent;

void main() {
    vec4 original = texture2D(texture, texcoord);
    float d = (original.r + original.b + original.g)/3.0;
    if (procent < texcoord.y)
        gl_FragColor = vec4(d, d, d, color.a);
    else
        gl_FragColor = original * color;
}