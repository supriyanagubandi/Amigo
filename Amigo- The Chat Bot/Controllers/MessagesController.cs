using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.Bot.Connector;
using Newtonsoft.Json;
using Microsoft.Bot.Builder.Dialogs;

namespace Amigo__The_Chat_Bot
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            ConnectorClient connector = new ConnectorClient(new Uri(activity.ServiceUrl));
            if (activity.Type == ActivityTypes.Message) 
            {
               
                if (activity.Attachments == null || activity.Attachments.Count == 0)
                {
                    await Conversation.SendAsync(activity, () => new Amigo_Luis());

                }
                else
                {
                    string imageUrl = activity.Attachments[0].ContentUrl;
                    string mess = await FaceDetectionAPI.FaceAPI.UploadAndDetectFaces(imageUrl);
                    Activity reply = activity.CreateReply(mess);
                    activity.Text = mess;
                    await Conversation.SendAsync(activity, () => new Amigo_Luis());
                 }
            }
            else
            {
                await HandleSystemMessage(activity);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        private async Task HandleSystemMessage(Activity message)
        {
            if (message.Type == ActivityTypes.DeleteUserData)
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == ActivityTypes.ConversationUpdate)
            {
                
                if (message.MembersAdded.Any(o => o.Id == message.Recipient.Id))
                {
                    //Welcome Message to the User
                    ConnectorClient client = new ConnectorClient(new Uri(message.ServiceUrl));
                    // bot replies first
                    Activity reply = message.CreateReply();
                    reply.Text = "Hai   \U0001F44B" + Environment.NewLine + Environment.NewLine + "I am Amigo  \U0001F64B" + Environment.NewLine + Environment.NewLine + "Your new pal   \U0001F471 ";
                    await client.Conversations.ReplyToActivityAsync(reply);
                  
                }
            }
            else if (message.Type == ActivityTypes.ContactRelationUpdate)
            {
                // Handle add/remove from contact lists
                // Activity.From + Activity.Action represent what happened
            }
            else if (message.Type == ActivityTypes.Typing)
            {
                // Handle knowing tha the user is typing
            }
            else if (message.Type == ActivityTypes.Ping)
            {
            }

            
        }
    }
}