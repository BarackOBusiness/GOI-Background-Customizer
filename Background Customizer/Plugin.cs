using BepInEx;
using BepInEx.Configuration;
using UnityEngine;
using UnityEngine.SceneManagement;

using System;
using System.Linq;

namespace Background_Customizer
{
    [BepInPlugin("GOI.plugins.BackgroundMod", "Background Customizer", PluginInfo.PLUGIN_VERSION)]
    public class BackgroundCustomizer : BaseUnityPlugin
    { // Creating all of the config entries
        private GradientColorKey[] TutoColorKey; private GradientColorKey[] ChimColorKey; private GradientColorKey[] SlideColorKey; private GradientColorKey[] FurniColorKey; private GradientColorKey[] OrangeColorKey; private GradientColorKey[] AnvilColorKey; private GradientColorKey[] BucketColorKey; private GradientColorKey[] IceColorKey; private GradientColorKey[] CreditsColorKey;

        ConfigEntry<bool> Enabled;
        ConfigEntry<Color> Tut1; ConfigEntry<Color> Tut2; ConfigEntry<Color> Tut3; ConfigEntry<Color> TutSun; ConfigEntry<Color> TutFog; ConfigEntry<float> TutExposure; ConfigEntry<float> TutSaturation; ConfigEntry<float> TutContrast;
        ConfigEntry<Color> Chim1; ConfigEntry<Color> Chim2; ConfigEntry<Color> Chim3; ConfigEntry<Color> ChimSun; ConfigEntry<Color> ChimFog; ConfigEntry<float> ChimExposure; ConfigEntry<float> ChimSaturation; ConfigEntry<float> ChimContrast;
        ConfigEntry<Color> Slide1; ConfigEntry<Color> Slide2; ConfigEntry<Color> Slide3; ConfigEntry<Color> SlideSun; ConfigEntry<Color> SlideFog; ConfigEntry<float> SlideExposure; ConfigEntry<float> SlideSaturation; ConfigEntry<float> SlideContrast;
        ConfigEntry<Color> Furni1; ConfigEntry<Color> Furni2; ConfigEntry<Color> Furni3; ConfigEntry<Color> FurniSun; ConfigEntry<Color> FurniFog; ConfigEntry<float> FurniExposure; ConfigEntry<float> FurniSaturation; ConfigEntry<float> FurniContrast;
        ConfigEntry<Color> Orange1; ConfigEntry<Color> Orange2; ConfigEntry<Color> Orange3; ConfigEntry<Color> OrangeSun; ConfigEntry<Color> OrangeFog; ConfigEntry<float> OrangeExposure; ConfigEntry<float> OrangeSaturation; ConfigEntry<float> OrangeContrast;
        ConfigEntry<Color> Anvil1; ConfigEntry<Color> Anvil2; ConfigEntry<Color> Anvil3; ConfigEntry<Color> AnvilSun; ConfigEntry<Color> AnvilFog; ConfigEntry<float> AnvilExposure; ConfigEntry<float> AnvilSaturation; ConfigEntry<float> AnvilContrast;
        ConfigEntry<Color> Bucket1; ConfigEntry<Color> Bucket2; ConfigEntry<Color> Bucket3; ConfigEntry<Color> BucketSun; ConfigEntry<Color> BucketFog; ConfigEntry<float> BucketExposure; ConfigEntry<float> BucketSaturation; ConfigEntry<float> BucketContrast;
        ConfigEntry<Color> Ice1; ConfigEntry<Color> Ice2; ConfigEntry<Color> Ice3; ConfigEntry<Color> IceSun; ConfigEntry<Color> IceFog; ConfigEntry<float> IceExposure; ConfigEntry<float> IceSaturation; ConfigEntry<float> IceContrast;
        ConfigEntry<Color> Credits1; ConfigEntry<Color> Credits2; ConfigEntry<Color> Credits3; ConfigEntry<Color> CreditsSun; ConfigEntry<Color> CreditsFog; ConfigEntry<float> CreditsExposure; ConfigEntry<float> CreditsSaturation; ConfigEntry<float> CreditsContrast;

        ConfigEntry<bool> ApplySky;

        void Awake()
        {
            // Binding all of the configuration, pretty self explanatory, and pretty monotonous...
            try {
                SceneManager.sceneLoaded += OnSceneLoaded;

                Enabled = Config.Bind("", "User Agreement", false, new ConfigDescription("By clicking this checkbox you hereby agree that any ass configurations you use that lower visibility, hurt peoples eyes, or cannot be displayed correctly on certain hardware is your responsibility and by using said configurations that speedrun.com moderators may reject any runs using them at their discretion.", null, new ConfigurationManagerAttributes { Order = 1 }));
                ApplySky = Config.Bind("", "Apply settings", false, "Click this to update your sky settings without having to restart and climb back up to see what's changed in higher areas");
                
                Tut1 = Config.Bind("1 Tutorial Sky", "Tutorial sky color 1", new Color(0.9254902f, 0.9647059f, 0.5882353f), "The lowest color in the gradient for the sky at tutorial.");
                Tut2 = Config.Bind("1 Tutorial Sky", "Tutorial sky color 2", new Color(0.5372549f, 0.6392157f, 0.2980392f), "The middle color in the gradient for the sky at tutorial.");
                Tut3 = Config.Bind("1 Tutorial Sky", "Tutorial sky color 3", new Color(0.1372549f, 0.4196078f, 0.3960784f), "The highest color in the gradient for the sky at tutorial.");
                TutSun = Config.Bind("1 Tutorial Sky", "Tutorial sun color", new Color(1f, 0.9262295f, 0.7352941f), "The color of the sun at tutorial, affects foreground.");
                TutFog = Config.Bind("1 Tutorial Sky", "Tutorial fog color", new Color(0.2627451f, 0.3529412f, 0.3333333f), "The color of the fog at tutorial, affects background objects.");
                TutExposure = Config.Bind("1 Tutorial Sky", "Tutorial exposure", -0.75f, "The exposure at tutorial, affects sky and background objects.");
                TutSaturation = Config.Bind("1 Tutorial Sky", "Tutorial Saturation", 0.9f, "The saturation at tutorial, affects sky.");
                TutContrast = Config.Bind("1 Tutorial Sky", "Tutorial Contrast", 1.3f, "The contrast at tutorial, affects sky and background.");

                Chim1 = Config.Bind("2 Chimney Sky", "Chimney sky color 1", new Color(0.9254902f, 0.9647059f, 0.5882353f), "The lowest color in the gradient for the sky at chimney.");
                Chim2 = Config.Bind("2 Chimney Sky", "Chimney sky color 2", new Color(0.5372549f, 0.6392157f, 0.2980392f), "The middle color in the gradient for the sky at chimney.");
                Chim3 = Config.Bind("2 Chimney Sky", "Chimney sky color 3", new Color(0.1372549f, 0.4196078f, 0.3960784f), "The highest color in the gradient for the sky at chimney.");
                ChimSun = Config.Bind("2 Chimney Sky", "Chimney sun color", new Color(1f, 0.9262295f, 0.7352941f), "The color of the sun at chimney, affects foreground.");
                ChimFog = Config.Bind("2 Chimney Sky", "Chimney fog color", new Color(0.2627451f, 0.3529412f, 0.3333333f), "The color of the fog at chimney, affects background objects.");
                ChimExposure = Config.Bind("2 Chimney Sky", "Chimney exposure", -1.26f, "The exposure at chimney, affects sky and background objects.");
                ChimSaturation = Config.Bind("2 Chimney Sky", "Chimney Saturation", 0.9f, "The saturation at chimney, affects sky and background.");
                ChimContrast = Config.Bind("2 Chimney Sky", "Chimney Contrast", 1.2f, "The contrast at chimney, affects sky and background.");

                Slide1 = Config.Bind("3 Slide Sky", "Slide sky color 1", new Color(0.6969827f, 0.8525698f, 0.875f), "The lowest color in the gradient for the sky at slide.");
                Slide2 = Config.Bind("3 Slide Sky", "Slide sky color 2", new Color(0f, 0.6109431f, 0.8308824f), "The middle color in the gradient for the sky at slide.");
                Slide3 = Config.Bind("3 Slide Sky", "Slide sky color 3", new Color(0f, 0.321691f, 0.625f), "The highest color in the gradient for the sky at slide.");
                SlideSun = Config.Bind("3 Slide Sky", "Slide sun color", new Color(1f, 1f, 1f), "The color of the sun at slide, affects foreground.");
                SlideFog = Config.Bind("3 Slide Sky", "Slide fog color", new Color(0.4426903f, 0.5603867f, 0.6764706f), "The color of the fog at slide, affects background objects.");
                SlideExposure = Config.Bind("3 Slide Sky", "Slide exposure", 0.5f, "The exposure at slide, affects sky and background objects.");
                SlideSaturation = Config.Bind("3 Slide Sky", "Slide Saturation", 1f, "The saturation at slide, affects sky and background.");
                SlideContrast = Config.Bind("3 Slide Sky", "Slide Contrast", 1.1f, "The contrast at slide, affects sky and background.");

                Furni1 = Config.Bind("4 Furniture Sky", "Furniture sky color 1", new Color(0.6969827f, 0.8525698f, 0.875f), "The lowest color in the gradient for the sky at furniture.");
                Furni2 = Config.Bind("4 Furniture Sky", "Furniture sky color 2", new Color(0f, 0.6109431f, 0.8308824f), "The middle color in the gradient for the sky at furniture.");
                Furni3 = Config.Bind("4 Furniture Sky", "Furniture sky color 3", new Color(0f, 0.321691f, 0.625f), "The highest color in the gradient for the sky at furniture.");
                FurniSun = Config.Bind("4 Furniture Sky", "Furniture sun color", new Color(1f, 1f, 1f), "The color of the sun at furniture, affects foreground.");
                FurniFog = Config.Bind("4 Furniture Sky", "Furniture fog color", new Color(0.4431373f, 0.5607843f, 0.6745098f), "The color of the fog at furniture, affects background objects.");
                FurniExposure = Config.Bind("4 Furniture Sky", "Furni exposure", -0.51f, "The exposure at furniture, affects sky and background objects.");
                FurniSaturation = Config.Bind("4 Furniture Sky", "Furni Saturation", 1.1f, "The saturation at furniture, affects sky and background.");
                FurniContrast = Config.Bind("4 Furniture Sky", "Furni Contrast", 1.1f, "The contrast at furniture, affects sky and background.");

                Orange1 = Config.Bind("5 Orange Sky", "Orange sky color 1", new Color(0.9705882f, 0.5447993f, 0.2644016f), "The lowest color in the gradient for the sky at orange hell.");
                Orange2 = Config.Bind("5 Orange Sky", "Orange sky color 2", new Color(0.9044118f, 0.6902801f, 0.5492665f), "The middle color in the gradient for the sky at orange hell.");
                Orange3 = Config.Bind("5 Orange Sky", "Orange sky color 3", new Color(0.5528398f, 0.6491991f, 0.6764706f), "The highest color in the gradient for the sky at orange hell.");
                OrangeSun = Config.Bind("5 Orange Sky", "Orange hell sun color", new Color(1f, 0.7387424f, 0.4448276f), "The color of the sun at orange hell, affects foreground.");
                OrangeFog = Config.Bind("5 Orange Sky", "Orange fog color", new Color(0.4264706f, 0.3323962f, 0.4121972f), "The color of the fog at orange hell, affects background objects.");
                OrangeExposure = Config.Bind("5 Orange Sky", "Orange exposure", 0f, "The exposure at orange hell, affects sky and background objects.");
                OrangeSaturation = Config.Bind("5 Orange Sky", "Orange Saturation", 1.3f, "The saturation at orange hell, affects sky and background.");
                OrangeContrast = Config.Bind("5 Orange Sky", "Orange Contrast", 1f, "The contrast at orange hell, affects sky and background.");

                Anvil1 = Config.Bind("6 Anvil Sky", "Anvil sky color 1", new Color(0.9551932f, 0.6931034f, 1f), "The lowest color in the gradient for the sky at anvil.");
                Anvil2 = Config.Bind("6 Anvil Sky", "Anvil sky color 2", new Color(0.2724138f, 0.3901115f, 1f), "The middle color in the gradient for the sky at anvil.");
                Anvil3 = Config.Bind("6 Anvil Sky", "Anvil sky color 3", new Color(0f, 0f, 0f), "The highest color in the gradient for the sky at anvil.");
                AnvilSun = Config.Bind("6 Anvil Sky", "Anvil sun color", new Color(0.6898174f, 0.5622897f, 0.872f), "The color of the sun at anvil, affects foreground.");
                AnvilFog = Config.Bind("6 Anvil Sky", "Anvil fog color", new Color(0.2470588f, 0.3568628f, 0.909804f), "The color of the fog at anvil, affects background objects.");
                AnvilExposure = Config.Bind("6 Anvil Sky", "Anvil exposure", 0f, "The exposure at anvil, affects sky and background objects.");
                AnvilSaturation = Config.Bind("6 Anvil Sky", "Anvil Saturation", 1.1f, "The saturation at anvil, affects sky and background.");
                AnvilContrast = Config.Bind("6 Anvil Sky", "Anvil Contrast", 0.9f, "The contrast at anvil, affects sky and background.");

                Bucket1 = Config.Bind("7 Bucket Sky", "Bucket sky color 1", new Color(0.9551932f, 0.6931034f, 1f), "The lowest color in the gradient for the sky at bucket.");
                Bucket2 = Config.Bind("7 Bucket Sky", "Bucket sky color 2", new Color(0.2724138f, 0.3901115f, 1f), "The middle color in the gradient for the sky at bucket.");
                Bucket3 = Config.Bind("7 Bucket Sky", "Bucket sky color 3", new Color(0f, 0f, 0f), "The highest color in the gradient for the sky at bucket.");
                BucketSun = Config.Bind("7 Bucket Sky", "Bucket sun color", new Color(0.5120224f, 0.3770449f, 0.647f), "The color of the sun at bucket, affects foreground.");
                BucketFog = Config.Bind("7 Bucket Sky", "Bucket fog color", new Color(0.2666667f, 0.3843138f, 0.9882354f), "The color of the fog at bucket, affects background objects.");
                BucketExposure = Config.Bind("7 Bucket Sky", "Bucket exposure", 0f, "The exposure at bucket, affects sky and background objects.");
                BucketSaturation = Config.Bind("7 Bucket Sky", "Bucket Saturation", 1.1f, "The saturation at bucket, affects sky and background.");
                BucketContrast = Config.Bind("7 Bucket Sky", "Bucket Contrast", 1.2f, "The contrast at bucket, affects sky and background.");

                Ice1 = Config.Bind("8 Ice and Tower Sky", "Ice sky color 1", new Color(0f, 0.2482648f, 0.734f), "The lowest color in the gradient for the sky at ice cliff.");
                Ice2 = Config.Bind("8 Ice and Tower Sky", "Ice sky color 2", new Color(0.1161765f, 0.1389922f, 0.4264706f), "The middle color in the gradient for the sky at ice cliff.");
                Ice3 = Config.Bind("8 Ice and Tower Sky", "Ice sky color 3", new Color(0f, 0f, 0f), "The highest color in the gradient for the sky at ice cliff.");
                IceSun = Config.Bind("8 Ice and Tower Sky", "Ice sun color", new Color(0.5068966f, 0.7389452f, 1f), "The color of the sun at ice cliff and tower, affects foreground.");
                IceFog = Config.Bind("8 Ice and Tower Sky", "Ice fog color", new Color(0.120891f, 0.1704635f, 0.3161765f), "The color of the fog at ice cliff and tower, affects background objects.");
                IceExposure = Config.Bind("8 Ice and Tower Sky", "Ice exposure", 0f, "The exposure at ice cliff and tower, affects sky and background objects.");
                IceSaturation = Config.Bind("8 Ice and Tower Sky", "Ice Saturation", 1f, "The saturation at ice cliff and tower, affects sky.");
                IceContrast = Config.Bind("8 Ice and Tower Sky", "Ice Contrast", 1.6f, "The contrast at ice cliff and tower, affects sky and background.");

                Credits1 = Config.Bind("9 Space Sky", "Space sky color 1", new Color(0f, 0.1492858f, 0.44f), "The lowest color in the gradient for the sky in space.");
                Credits2 = Config.Bind("9 Space Sky", "Space sky color 2", new Color(0f, 0f, 0f), "The middle color in the gradient for the sky in space.");
                Credits3 = Config.Bind("9 Space Sky", "Space sky color 3", new Color(0f, 0f, 0f), "The highest color in the gradient for the sky in space.");
                CreditsSun = Config.Bind("9 Space Sky", "Space sun color", new Color(0.1690636f, 0.2728952f, 0.3897059f), "The color of the sun in space, affects foreground.");
                CreditsFog = Config.Bind("9 Space Sky", "Space fog color", new Color(0f, 0f, 0f), "The color of the fog in space, affects background objects.");
                CreditsExposure = Config.Bind("9 Space Sky", "Space exposure", 0f, "The exposure in space, affects sky and background objects.");
                CreditsSaturation = Config.Bind("9 Space Sky", "Space Saturation", 1f, "The saturation in space, affects sky.");
                CreditsContrast = Config.Bind("9 Space Sky", "Space Contrast", 1.68f, "The contrast in space, affects sky and background.");

            } catch (Exception ex) { Debug.LogException(ex); }
            // Plugin startup logging
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
        }

        void Update()
        {
            try {
                // Checks to make sure the user agreement is enabled and that the sky parameters need to be updated (the apply button was clicked)
                // This should never run without ConfigurationManager as configuration file changes don't get updated ingame so there's no reason for an update ingame.
                if (ApplySky.Value && Enabled.Value)
                {
                    // Since both tutorial and chimney sky are both named "SwampSky" in the game hierarchy, we have to separate them to customize them individually
                    GameObject[] SwampSkies = (from o in UnityEngine.Object.FindObjectsOfType<GameObject>() where o.name == "SwampSky" select o).ToArray<GameObject>();

                    // Uses the SkyLoader function defined below to "cleanly" apply 
                    SkyLoader(TutoColorKey, SwampSkies[0].GetComponent<ColorSet>(), Tut1, Tut2, Tut3, TutSun, TutFog, TutExposure, TutSaturation, TutContrast);
                    SkyLoader(ChimColorKey, SwampSkies[1].GetComponent<ColorSet>(), Chim1, Chim2, Chim3, ChimSun, ChimFog, ChimExposure, ChimSaturation, ChimContrast);
                    SkyLoader(SlideColorKey, GameObject.Find("BlueSky").GetComponent<ColorSet>(), Slide1, Slide2, Slide3, SlideSun, SlideFog, SlideExposure, SlideSaturation, SlideContrast);
                    SkyLoader(FurniColorKey, GameObject.Find("BlueSky (2)").GetComponent<ColorSet>(), Furni1, Furni2, Furni3, FurniSun, FurniFog, FurniExposure, FurniSaturation, FurniContrast);
                    SkyLoader(OrangeColorKey, GameObject.Find("Sunset").GetComponent<ColorSet>(), Orange1, Orange2, Orange3, OrangeSun, OrangeFog, OrangeExposure, OrangeSaturation, OrangeContrast);
                    SkyLoader(AnvilColorKey, GameObject.Find("Twilight").GetComponent<ColorSet>(), Anvil1, Anvil2, Anvil3, AnvilSun, AnvilFog, AnvilExposure, AnvilSaturation, AnvilContrast);
                    SkyLoader(BucketColorKey, GameObject.Find("Twilight (2)").GetComponent<ColorSet>(), Bucket1, Bucket2, Bucket3, BucketSun, BucketFog, BucketExposure, BucketSaturation, BucketContrast);
                    SkyLoader(IceColorKey, GameObject.Find("SpaceSky").GetComponent<ColorSet>(), Ice1, Ice2, Ice3, IceSun, IceFog, IceExposure, IceSaturation, IceContrast);
                    SkyLoader(CreditsColorKey, GameObject.Find("CreditsSky").GetComponent<ColorSet>(), Credits1, Credits2, Credits3, CreditsSun, CreditsFog, CreditsExposure, CreditsSaturation, CreditsContrast);
                    ApplySky.Value = false;
                    // Sets the enabled value to false because it's a button, you click it to apply something, if it was enabled continously that would be a dysfunctional button.
                    // Hopefully whoever is reading this will understand better than the people who ask why the "apply settings" button doesn't stay enabled 
                }
            } catch (Exception ex) { Debug.LogException(ex); }
        }

        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            try
            {
                // Whenever the mian scene is loaded (default scene, but also loads on other maps) create the colorkeys and set parameters down below.
                if (scene.name == "Mian")
                {
                    TutoColorKey = new GradientColorKey[3];
                    ChimColorKey = new GradientColorKey[3];
                    SlideColorKey = new GradientColorKey[3];
                    FurniColorKey = new GradientColorKey[3];
                    OrangeColorKey = new GradientColorKey[3];
                    AnvilColorKey = new GradientColorKey[3];
                    BucketColorKey = new GradientColorKey[3];
                    IceColorKey = new GradientColorKey[3];
                    CreditsColorKey = new GradientColorKey[3];

                    GameObject[] SwampSkies = (from o in UnityEngine.Object.FindObjectsOfType<GameObject>() where o.name == "SwampSky" select o).ToArray<GameObject>();

                    if (Enabled.Value)
                    {
                        SkyLoader(TutoColorKey, SwampSkies[0].GetComponent<ColorSet>(), Tut1, Tut2, Tut3, TutSun, TutFog, TutExposure, TutSaturation, TutContrast);
                        SkyLoader(ChimColorKey, SwampSkies[1].GetComponent<ColorSet>(), Chim1, Chim2, Chim3, ChimSun, ChimFog, ChimExposure, ChimSaturation, ChimContrast);
                        SkyLoader(SlideColorKey, GameObject.Find("BlueSky").GetComponent<ColorSet>(), Slide1, Slide2, Slide3, SlideSun, SlideFog, SlideExposure, SlideSaturation, SlideContrast);
                        SkyLoader(FurniColorKey, GameObject.Find("BlueSky (2)").GetComponent<ColorSet>(), Furni1, Furni2, Furni3, FurniSun, FurniFog, FurniExposure, FurniSaturation, FurniContrast);
                        SkyLoader(OrangeColorKey, GameObject.Find("Sunset").GetComponent<ColorSet>(), Orange1, Orange2, Orange3, OrangeSun, OrangeFog, OrangeExposure, OrangeSaturation, OrangeContrast);
                        SkyLoader(AnvilColorKey, GameObject.Find("Twilight").GetComponent<ColorSet>(), Anvil1, Anvil2, Anvil3, AnvilSun, AnvilFog, AnvilExposure, AnvilSaturation, AnvilContrast);
                        SkyLoader(BucketColorKey, GameObject.Find("Twilight (2)").GetComponent<ColorSet>(), Bucket1, Bucket2, Bucket3, BucketSun, BucketFog, BucketExposure, BucketSaturation, BucketContrast);
                        SkyLoader(IceColorKey, GameObject.Find("SpaceSky").GetComponent<ColorSet>(), Ice1, Ice2, Ice3, IceSun, IceFog, IceExposure, IceSaturation, IceContrast);
                        SkyLoader(CreditsColorKey, GameObject.Find("CreditsSky").GetComponent<ColorSet>(), Credits1, Credits2, Credits3, CreditsSun, CreditsFog, CreditsExposure, CreditsSaturation, CreditsContrast);
                        GameObject.Find("CloudSystems/Stratus").GetComponent<FogVolume>()._AmbientColor = new Color(0.55f, 0.75f, 0.9f, 1f);
                    }
                }
            }
            catch (Exception ex) { Debug.LogException(ex); }
        }

        void SkyLoader(GradientColorKey[] Key, ColorSet SkySet, ConfigEntry<Color> One, ConfigEntry<Color> Two, ConfigEntry<Color> Three, ConfigEntry<Color> Sun, ConfigEntry<Color> Fog, ConfigEntry<float> Exposure, ConfigEntry<float> Saturation, ConfigEntry<float> Contrast)
        {
            /* Here are all of the parameters for a ColorSet in Getting Over It, sky color is set by key which is loaded with the colors specified in config 
            and further parameters go into the others. */
            Key[0].color = One.Value; Key[1].color = Two.Value; Key[2].color = Three.Value;
            Key[0].time = SkySet.sky.colorKeys[0].time; Key[1].time = SkySet.sky.colorKeys[1].time; Key[2].time = SkySet.sky.colorKeys[2].time;
            SkySet.sky.colorKeys = Key;
            SkySet.sun = Sun.Value;
            SkySet.fog = Fog.Value;
            SkySet.exposure = Exposure.Value;
            SkySet.saturation = Saturation.Value;
            SkySet.contrast = Contrast.Value;
        }
    }
}
