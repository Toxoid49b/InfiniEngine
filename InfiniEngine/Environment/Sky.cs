using System;
using UnityEngine;
using InfiniEngine;

namespace InfiniEngine.Environment {

    public class Sky {

        private Gradient nightDayColor;

        private float maxIntensity = 3f;
        private float minIntensity = 0f;
        private float minPoint = -0.2f;

        private float maxAmbient = 1f;
        private float minAmbient = 0f;
        private float minAmbientPoint = -0.2f;

        private Gradient nightDayFogColor;
        private AnimationCurve fogDensityCurve;
        private float fogScale = 1f;

        private float dayAtmosphereThickness = 0.4f;
        private float nightAtmosphereThickness = 0.87f;

        private Vector3 dayRotateSpeed;
        private Vector3 nightRotateSpeed;

        private float skySpeed = 1;

        private Light mainLight;
        private Skybox sky;
        private Material skyMat;

        public Sky(Gradient nightDayColorGradient, float maxSunIntensity, float minSunIntensity, float minSunPoint, float maxAmbientLightIntensity, float minAmbientLightIntensity, float minAmbientLightPoint, Gradient fogColor, AnimationCurve fogDensity, float fogThickness, float dayAtmosThickness, float nightAtmosThickness, float skySpeedScale, Light sunLight, Skybox proceduralSky, Material skyMaterial) {

            //First, register with the world events
            World.GetActiveWorld().OnTimeChange += new WorldTimeChangeEventHandler(Sky_OnTimeChange);



        }

        void Sky_OnTimeChange(object sender, EventArgs e) {

            

        }

    }

}
