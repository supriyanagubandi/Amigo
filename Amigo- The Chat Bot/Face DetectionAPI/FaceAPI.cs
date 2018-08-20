using Microsoft.ProjectOxford.Common.Contract;
using Microsoft.ProjectOxford.Face;
using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Amigo__The_Chat_Bot.FaceDetectionAPI
{
    public class FaceAPI
    {

        private static readonly IFaceServiceClient faceServiceClient = new FaceServiceClient(" de8f185564df452c81a44b814ed71a37", " https://westcentralus.api.cognitive.microsoft.com/face/v1.0");
        public static async Task<string> UploadAndDetectFaces(string imageFilePath)
        {
            string result = "";
             
            try
            {
                var requiredFaceAttributes = new FaceAttributeType[] {
                    FaceAttributeType.Age,
                    FaceAttributeType.Gender,
                    FaceAttributeType.Smile,
                    FaceAttributeType.Emotion,
                    FaceAttributeType.FacialHair,
                    FaceAttributeType.HeadPose,
                    FaceAttributeType.Accessories,
                    FaceAttributeType.Hair,
                    FaceAttributeType.Glasses,
                    FaceAttributeType.Makeup,

                };
                using (WebClient webClient = new WebClient())
                {

                    using (Stream imageFileStream = webClient.OpenRead(imageFilePath))
                    {

                        var faces = await faceServiceClient.DetectAsync(imageFileStream, true, true, returnFaceAttributes: requiredFaceAttributes);

                        var faceAttributes = faces.Select(face => face.FaceAttributes);

                        float maxVal = 0;

                        float angry = 0, fear = 0, contempt = 0, disgust = 0, happiness = 0, neutral = 0, sadness = 0, surprise = 0;
                        var faceEmotions = faces.Select(face => face.FaceAttributes.Emotion);

                        faceAttributes.ToList().ForEach(f =>

                           { 
                               maxVal = Math.Max(
                                      Math.Max(
                                          Math.Max(f.Emotion.Anger, f.Emotion.Contempt), Math.Max(f.Emotion.Disgust, f.Emotion.Fear)
                                          ),
                                      Math.Max(
                                          Math.Max(f.Emotion.Happiness, f.Emotion.Neutral), Math.Max(f.Emotion.Sadness, f.Emotion.Surprise)));

                               
                                   angry = f.Emotion.Anger; fear = f.Emotion.Fear; contempt = f.Emotion.Contempt; disgust = f.Emotion.Disgust;
                                   happiness = f.Emotion.Happiness;
                                   neutral = f.Emotion.Neutral; sadness = f.Emotion.Sadness; surprise = f.Emotion.Surprise;


                                   if (angry.Equals(maxVal))
                                       result += /*$" You are  { maxVal* 100}%*/ "Angry";
                                   else if (fear.Equals(maxVal))
                                       result += /*$" You are { maxVal * 100}% */"Fear";
                                   else if (contempt.Equals(maxVal))
                                       result += /*$" You are { maxVal * 100}%*/ "Contempt";
                                   else if (disgust.Equals(maxVal))
                                       result += /*$" You are { maxVal * 100}%*/"Disgust";
                                   else if (happiness.Equals(maxVal))
                                       result += /*$" You are { maxVal * 100}%*/ "Happy";
                                   else if (neutral.Equals(maxVal))
                                       result += /*$" You are { maxVal * 100}% */"Neutral";
                                   else if (sadness.Equals(maxVal))
                                       result += /*$" You are { maxVal * 100}% */"Sadness";
                                   else if (surprise.Equals(maxVal))
                                       result += /*$" You are { maxVal * 100}% */"Surprise";
                                   else
                                       result = "Sorry !!!";
                                   result += Environment.NewLine + Environment.NewLine;

                               }

                 
                                    
                                    );
                       



                        //  result += $"    {f.Emotion.Anger }{Environment.NewLine}{Environment.NewLine} Age: {f.Age.ToString()}  Years {Environment.NewLine}{Environment.NewLine} Gender: {f.Gender} {Environment.NewLine}{Environment.NewLine} Glasses : {f.Glasses}{Environment.NewLine}{Environment.NewLine}lipmakeup : {f.Makeup.LipMakeup}{Environment.NewLine}{Environment.NewLine}  eyemakeup : {f.Makeup.EyeMakeup}{Environment.NewLine}{Environment.NewLine} Bald : {f.Hair.Bald}{Environment.NewLine}{Environment.NewLine}  moustache : {f.FacialHair.Moustache}{Environment.NewLine}{Environment.NewLine}   Beard {f.FacialHair.Beard}    ");

                        // result = maxVal.ToString();
                        return result;
                    }

                }
            }
            catch (Exception ex)
            {
                //result += ex;
                result += " can't define" + ex;
                return result;
            }
        }
    }
}